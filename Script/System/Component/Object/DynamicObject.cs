using Godot;
using System;
using Metadata.Object;
using Component.Animation;
using Component.FiniteStateMachine;

namespace Component.Object{
	/// Summary:
	/// 	Object động, có State Machine & Animation
    public abstract partial class DynamicObject : CharacterBody2D{
		/// Summary:
		/// 	Điều kiện quyết định đối tượng có được di chuyển hay không
		public bool CanMove{get; set;} = true;
		/// Summary:
		/// 	Lưu giá trị kiểm tra xem có đang collide với vật thể nào không
        public bool IsCollided{get; protected set;} = false;
		/// Summary:
		/// 	Sprite Sheet của object
		public SpriteSheet Sheet{get; protected set;}
		/// Summary:
		/// 	State Machine của object
		public StateMachine ObjectiveStateMachine{get; protected set;}
		/// Summary:
		/// 	Metadata, chứa thông tin về State ID, hướng nhìn của object, Animation có loop hay không,...
		public DynamicObjectMetadata Metadata{get; protected set;}
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
			Node parent = this.GetParent();
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
				}
			catch (InvalidCastException CannotGetSpriteSheet){
				GD.Print("Không thể cast tới Sprite Sheet");
				throw CannotGetSpriteSheet;
				}
			catch (NullReferenceException DontHaveSpriteSheet){
				GD.Print("Chưa có Sprite Sheet");
				throw DontHaveSpriteSheet;
				}
			}
		public override void _Ready(){
			try{
				this.ObjectiveStateMachine = GetFirstChildOfType<StateMachine>();
				this.Metadata = new();
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
		/// Summary:
		/// 	Cập nhật Metadata của đối tượng
		protected void UpdateMetadata(){
			try {
				var State = this.ObjectiveStateMachine.CurrentState as DynamicState;
					this.Metadata.StateID = State.ID;
					this.Metadata.IsLoopingAnimation = State.IsLoop;
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
				var State = this.ObjectiveStateMachine.CurrentState as DynamicState;
				var Frame = State.Frame;
					this.Sheet.Animate(Frame, Metadata, GetRelativeResponseTime(delta));
				}
			catch (NullReferenceException CurrentStateMissing){
				GD.Print("Không thể tìm thấy State hiện tại của đối tượng: \'" + this.Name + "\'");
				throw CurrentStateMissing;
				}
			}
        }
    }