using GameSystem.Component.FiniteStateMachine;

namespace  Actor.TargetPlayer;
	public partial class Dash : DynamicState{
		public override void _Ready(){
			base._Ready();
			Object.PlayerInputManager.DashKeyPressed += this.SetCondition;
			Object.Sheet.AnimationFinished += this.ResetCondition;
			}
		public void SetCondition(){
			base.SetCondition(true);
			}
		public override void ResetCondition(){
			base.ResetCondition();
			Object.CanMove = true;
			}
		public override void RunningState(double delta){
			base.RunningState(delta);
			Object.Velocity = Object.PlayerInputManager.GetPlayerMovementVector(Object.Metadata.GetDirectionAsVector()) * this.MovingSpeed;
			}
		}
