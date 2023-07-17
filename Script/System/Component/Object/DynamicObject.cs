using Godot;
using System;
using Metadata.Object;
using Component.Animation;
using Component.FiniteStateMachine;
using Component.Manager;

namespace Component.Object;
	/// <summary>
	/// Object động, có State Machine & Animation
	/// </summary>
	public abstract partial class DynamicObject : CharacterBody2D{
		/// <summary>
		/// Điều kiện quyết định đối tượng có được di chuyển hay không
		/// </summary>
		public bool CanMove{get; set;} = true;
		/// <summary>
		/// Lưu giá trị kiểm tra xem có đang collide với vật thể nào không
		/// </summary>
		public bool IsCollided{get; protected set;} = false;
		/// <summary>
		/// Lấy thông tin input của Player
		/// </summary>
		public InputManager PlayerInputManager{get; private set;}
		/// <summary>
		/// Sprite Sheet của object
		/// </summary>
		public SpriteSheet Sheet{get; protected set;}
		/// <summary>
		/// State Machine của object
		/// </summary>
		public StateMachine ObjectiveStateMachine{get; protected set;}
		/// <summary>
		/// Metadata, chứa thông tin về State ID, hướng nhìn của object, Animation có loop hay không,...
		/// </summary>
		public DynamicObjectData Metadata{get; protected set;}
		[Export] public bool IsFourDirection{get; protected set;} = true;
		/// <summary>
		/// Trả về node con đầu tiên có type T
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <returns>Node con đầu tiên có type T, hoặc null nếu không tìm thấy</returns>
		public T GetFirstChildOfType<T>() where T : Node{
			T targetChild = null;
				for (int i = 0; i < this.GetChildCount(); i++){
					if (this.GetChildOrNull<T>(i) != null){
						targetChild = this.GetChild<T>(i);
						break;
						}
					}
			return targetChild;
			}
		/// <summary>
		/// Trả về node đầu tiên có type T trong node Cha, ở cùng cấp với node hiện tại
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <returns>Node đầu tiên có type T ở cùng cấp, hoặc null nếu không tìm thấy</returns>
		public T GetFirstSiblingOfType<T>() where T : Node{
			var parent = this.GetParent();
			T targetSibling = null;
				for (int i = 0; i < parent.GetChildCount(); i++){
					if (parent.GetChildOrNull<T>(i) != null){
						targetSibling = parent.GetChild<T>(i);
						break;
						}
					}
			return targetSibling;
			}
		public override void _EnterTree(){
			try{
				this.Sheet = GetFirstChildOfType<SpriteSheet>();
				this.PlayerInputManager = GetFirstChildOfType<InputManager>();
				}
			catch (InvalidCastException CannotGetSpriteSheet){
				GD.Print("Không thể cast tới Sprite Sheet & Player Input Manager");
				throw CannotGetSpriteSheet;
				}
			catch (NullReferenceException DontHaveSpriteSheet){
				GD.Print("Chưa có Sprite Sheet & Player Input Manger");
				throw DontHaveSpriteSheet;
				}
			}
		public override void _Ready(){
			try{
				this.ObjectiveStateMachine = GetFirstChildOfType<StateMachine>();
				this.Metadata = new(){
					IsFourDirection = this.IsFourDirection
					};
				}
			catch (InvalidCastException CannotGetStateMachine){
				GD.Print("Không thể cast tới State Machine");
				throw CannotGetStateMachine;
				}
			catch (NullReferenceException DontHaveStateMachine){
				GD.Print("Chưa có State Machine");
				throw DontHaveStateMachine;
				}
			}
		public override void _PhysicsProcess(double delta){
			UpdateMetadata();
			Animation(delta);
			this.IsCollided = MoveAndSlide();
			}
		/// <summary>
		/// Trả về giá trị bằng fps * delta
		/// </summary>
		/// <param name="delta"></param>
		/// <returns>1 khi fps đạt ngưỡng lý tưởng</returns>
		protected static double GetRelativeResponseTime(double delta){
			return Performance.GetMonitor(Performance.Monitor.TimeFps) * delta;
			}
		/// <summary>
		/// Cập nhật Metadata của đối tượng
		/// </summary>
		protected void UpdateMetadata(){
			try {
				var _state = this.ObjectiveStateMachine.CurrentState as DynamicState;
					this.Metadata.StateID = _state.ID;
					this.Metadata.IsLoopingAnimation = _state.IsLoop;
						if (!this.Velocity.IsEqualApprox(Vector2.Zero)){
							this.Metadata.SetDirection(Velocity);
							}
				}
			catch (NullReferenceException CurrentStateMissing){
				GD.Print("Không thể tìm thấy State hiện tại của đối tượng: \'" + this.Name + "\'");
				throw CurrentStateMissing;
				}
			}
		/// <summary>
		/// Animate Sprite Sheet dựa trên thông tin lấy được từ method UpdateMetadata
		/// </summary>
		/// <param name="delta"></param>
		protected void Animation(double delta){
			try {
				var _state = this.ObjectiveStateMachine.CurrentState as DynamicState;
				var _frame = _state.Frame;
					this.Sheet.Animate(_frame, Metadata, GetRelativeResponseTime(delta));
				}
			catch (NullReferenceException CurrentStateMissing){
				GD.Print("Không thể tìm thấy State hiện tại của đối tượng: \'" + this.Name + "\'");
				throw CurrentStateMissing;
				}
			}
		}
