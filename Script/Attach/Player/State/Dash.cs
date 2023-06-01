using Component.FiniteStateMachine;
public partial class Dash : DynamicState{
	public override void _Ready(){
		base._Ready();
		OwnerObjected.PlayerInputManager.DashKeyPressed += this.SetCondition;
		OwnerObjected.Sheet.AnimationFinished += this.ResetCondition;
		}
	public void SetCondition(){
		base.SetCondition(true);
		}
	public override void ResetCondition(){
		base.ResetCondition();
		OwnerObjected.CanMove = true;
		}
	public override void _RunningState(double delta){
		base._RunningState(delta);
		OwnerObjected.Velocity = OwnerObjected.PlayerInputManager.GetPlayerMovementVector(OwnerObjected.Metadata.GetDirectionAsVector()) * this.MovingSpeed;
		}
	}