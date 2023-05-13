using Godot;
using System;
using Metadata.Object;
using Component.Animation;
using Component.StateMachine;

namespace Game.Object{
	/// <summary>
	/// Object động, có State Machine, có Animation
	/// </summary>
    public abstract partial class DynamicObject : CharacterBody2D{
		/// <summary>
		/// Lưu giá trị kiểm tra xem có đang collide với vật thể nào không
		/// </summary>
		/// <value></value>
        public bool IsCollided{get; protected set;} = false;
		public SpriteSheet Sheet{get; protected set;}
		public StateMachine ObjectiveStateMachine{get; protected set;}
		public DynamicMetadata Metadata{get; protected set;}
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
			catch (InvalidCastException e){
				GD.Print("Không thể cast tới Sprite Sheet");
				throw e;
				}
			catch (NullReferenceException e){
				GD.Print("Chưa có Sprite Sheet");
				throw e;
				}
			}
		public override void _Ready(){
			try{
				this.ObjectiveStateMachine = GetFirstChildOfType<StateMachine>();
				this.Metadata = new();
				}
			catch (InvalidCastException e){
				GD.Print("Không thể cast tới State Machine");
				throw e;
				}
			catch (NullReferenceException e){
				GD.Print("Chưa có State Machine");
				throw e;
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
			var State = this.ObjectiveStateMachine.CurrentState.ToDynamic();
				this.Metadata.StateID = State.ID;
				this.Metadata.IsLoopingAnimation = State.IsLoop;
					if (!this.Velocity.IsEqualApprox(Vector2.Zero)){
						this.Metadata.SetDirection(Velocity);
						}
			}
		/// <summary>
		/// Animate Sprite Sheet dựa trên thông tin lấy được từ method UpdateMetadata
		/// </summary>
		/// <param name="delta"></param>
		protected void Animation(double delta){
			var State = this.ObjectiveStateMachine.CurrentState.ToDynamic();
			var Frame = State.Frame;
				this.Sheet.Animate(Frame, Metadata, GetRelativeResponseTime(delta));
			}
        }
    }