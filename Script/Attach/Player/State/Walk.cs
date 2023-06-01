using Component.FiniteStateMachine;
public partial class Walk : DynamicState{
	public override void _Ready(){
		base._Ready();
		OwnedObject.PlayerInputManager.MovementKeyPressed += this.SetCondition;
		OwnedObject.PlayerInputManager.DashKeyPressed += this.ResetCondition;
		}
	// public override void SetCondition(bool condition){
	// 	base.SetCondition(condition);
	// 	if (player.Velocity.IsZeroApprox() && !Machine.PreviousState.IsState(this)){
	// 		Condition = false;
	// 		}
	// 	}
	public override void _RunningState(double delta){
		base._RunningState(delta);
		OwnedObject.Velocity = OwnedObject.PlayerInputManager.GetPlayerMovementVector(OwnedObject.Velocity) * this.MovingSpeed;
		}
	}