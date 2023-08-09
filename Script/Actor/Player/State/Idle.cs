using GameSystem.Component.FiniteStateMachine;

namespace Actor.Player;

public partial class Idle : DynamicState
{
	public override void _Ready()
	{
		base._Ready();
		var _inputManager = Object.InputManager;
		_inputManager.MovementKeyPressed += SetCondition;
		_inputManager.ActionKeyPressed += ResetCondition;
	}

	public override void SetCondition(bool condition)
	{
		if (!IsInitialized)
		{
			return;
		}

		Condition = !condition;
	}
}