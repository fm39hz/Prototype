using GameSystem.Component.FiniteStateMachine;

namespace  Actor.TargetPlayer;
	public partial class Walk : DynamicState{
		public override void _Ready(){
			base._Ready();
			Object.ObjectInputManager.MovementKeyPressed += this.SetCondition;
			Object.ObjectInputManager.ActionKeyPressed += this.ResetCondition;
			}
		// public override void SetCondition(bool condition){
		// 	base.SetCondition(condition);
		// 	if (Object.Velocity.IsZeroApprox() && !StateController.PreviousState.IsState(this)){
		// 		Condition = false;
		// 		}
		// 	}
		public override void RunningState(double delta){
			base.RunningState(delta);
			Object.Velocity = Object.ObjectInputManager.TopDownVector(Object.Velocity) * this.MovingSpeed;
			}
		}
