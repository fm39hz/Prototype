using GameSystem.Component.FiniteStateMachine;
using Actor;

namespace Attach.PlayerState;

public partial class Idle : StaticState
{	public new PlayerBody Target { get; set; }

	public override void _EnterTree()
	{
		base._EnterTree();
		Target = StateMachine.GetParent<PlayerBody>();
	}
	public override void _Ready()
	{
		base._Ready();
		var _inputManager = Target.InputManager;
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