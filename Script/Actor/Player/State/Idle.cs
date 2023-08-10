using GameSystem.Component.FiniteStateMachine;
using Actor;

namespace Attach.PlayerState;

public partial class Idle : DynamicState
{	public new Player Object { get; set; }

	public override void _EnterTree()
	{
		Object = GetOwner<Player>();
	}
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