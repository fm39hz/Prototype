using Component.FiniteStateMachine;
public partial class Walk : DynamicState{
	public override void _Ready(){
		base._Ready();
		OwnerObjected.PlayerInputManager.MovementKeyPressed += this.SetCondition;
		OwnerObjected.PlayerInputManager.DashKeyPressed += this.ResetCondition;
		}
	// public override void SetCondition(bool condition){
	// 	base.SetCondition(condition);
	// 	if (player.Velocity.IsZeroApprox() && !Machine.PreviousState.IsState(this)){
	// 		Condition = false;
	// 		}
	// 	}
	public override void _RunningState(double delta){
		base._RunningState(delta);
		OwnerObjected.Velocity = OwnerObjected.PlayerInputManager.GetPlayerMovementVector(OwnerObjected.Velocity) * this.MovingSpeed;
		}
	}