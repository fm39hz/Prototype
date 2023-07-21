using Godot;
using System;
using GameSystem.Data.Instance;
using GameSystem.Component.Animation;
using GameSystem.Component.FiniteStateMachine;
using GameSystem.Component.Manager;

namespace GameSystem.Component.Object;
	[GlobalClass]
	/// <summary>
	/// Object động, có State Machine & Animation
	/// </summary>
	public partial class DynamicObject : BaseObject{
		/// <summary>
		/// Điều kiện quyết định đối tượng có được di chuyển hay không
		/// </summary>
		public bool IsMoveable { get; set; } = true;
		/// <summary>
		/// Kiểm soát signal từ input
		/// </summary>
		public InputManager ObjectInputManager { get; protected set; }
		/// <summary>
		/// Sprite Sheet của đối tượng
		/// </summary>
		public SpriteSheet Sheet { get; protected set; }
		/// <summary>
		/// State Machine của đối tượng
		/// </summary>
		public StateMachine ObjectiveStateMachine { get; protected set; }
		/// <summary>
		/// Metadata, chứa thông tin về State ID, hướng nhìn của object, Animation có loop hay không,...
		/// </summary>
		public ObjectData Metadata { get; protected set; }
		[Export] public bool FourDirectionAnimation { get; protected set; } = true;
		public override void _EnterTree(){
			try{
				this.Sheet = GetFirstChildOfType<SpriteSheet>();
				this.ObjectInputManager = GetFirstChildOfType<InputManager>();
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
					IsFourDirection = this.FourDirectionAnimation
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
			ActiveAnimation();
			this.IsCollided = MoveAndSlide();
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
		protected void ActiveAnimation(){
			try {
				var _state = this.ObjectiveStateMachine.CurrentState as DynamicState;
				var _frame = _state.Frame;
					this.Sheet.Animate(_frame, Metadata);
				}
			catch (NullReferenceException CurrentStateMissing){
				GD.Print("Không thể tìm thấy State hiện tại của đối tượng: \'" + this.Name + "\'");
				throw CurrentStateMissing;
				}
			}
		}
