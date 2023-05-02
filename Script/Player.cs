using Godot;
using Controll;
using Component.Animation;
using Component.StateMachine;

namespace Game.Object.Player{
	public partial class Player : CharacterBody2D{
		private bool isCollided;
		private StateMachine SMC;
		private SheetComponent Sheet;
		public override void _Ready(){
			Sheet = GetChild<SheetComponent>(0);
			SMC = GetChild<StateMachine>(2);
			}
		public override void _PhysicsProcess(double delta){
			var currentState = SMC.Current.ToDynamic();
			FrameInfo Frame = currentState.Frame;
			Velocity = ControllInput.GetPlayerMovementVector(Velocity) * currentState.MovingSpeed;
				Frame.GetDirection(Velocity);
				Sheet.RunAnimation(Frame, ResponseTime.GetRelative(delta), currentState.IsLoop);
			isCollided = MoveAndSlide();
			}
		}
	public partial class PlayerState : DynamicState{
		}
	}