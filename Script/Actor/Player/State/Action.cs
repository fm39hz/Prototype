using GameSystem.Component.FiniteStateMachine;

namespace  Actor.TargetPlayer;
	public partial class Action : DynamicState{
		public override void _Ready(){
			base._Ready();
			Object.ObjectInputManager.ActionKeyPressed += this.SetCondition;
			Object.Sheet.AnimationFinished += this.ResetCondition;
			}
		public void SetCondition(){
			base.SetCondition(true);
			}
		public override void ResetCondition(){
			base.ResetCondition();
			Object.IsMoveable = true;
			}
		public override void RunningState(double delta){
			base.RunningState(delta);
			Object.Velocity = Object.ObjectInputManager.TopDownVector(Object.Metadata.GetDirectionAsVector()) * this.MovingSpeed;
			}
		}
