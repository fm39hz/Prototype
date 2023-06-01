using Component.FiniteStateMachine;

public partial class Idle : DynamicState{
	public override void _Ready(){
		base._Ready();
		var _inputManager = OwnerObjected.PlayerInputManager;
		_inputManager.MovementKeyPressed += this.SetCondition;
		_inputManager.DashKeyPressed += this.ResetCondition;
		}
	public override void SetCondition(bool condition){
		if (!this.Initialized){
			return;
			}
		Condition = !condition;
		}
	}