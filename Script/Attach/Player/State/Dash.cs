using Component.FiniteStateMachine;
public partial class Dash : DynamicState{
	public override void _Ready(){
		base._Ready();
		OwnedObject.PlayerInputManager.DashKeyPressed += this.SetCondition;
		OwnedObject.Sheet.AnimationFinished += this.ResetCondition;
		}
	public void SetCondition(){
		base.SetCondition(true);
		}
	public override void ResetCondition(){
		base.ResetCondition();
		OwnedObject.CanMove = true;
		}
	public override void _RunningState(double delta){
		base._RunningState(delta);
		OwnedObject.Velocity = OwnedObject.PlayerInputManager.GetPlayerMovementVector(OwnedObject.Metadata.GetDirectionAsVector()) * this.MovingSpeed;
		}
	}