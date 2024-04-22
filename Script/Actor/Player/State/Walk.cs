using System;
using GameSystem.Component.FiniteStateMachine;
using GameSystem.Core.Component.FiniteStateMachine;
using GameSystem.Core.Component.InputManagement;
using GameSystem.Core.Object.Root.Concrete;

namespace Attach.PlayerState;

public partial class Walk : StaticState, IControllableState
{
	public Player Target { get; private set; }

	public void ResetCondition()
	{
		throw new NotImplementedException();
	}

	public void SetCondition(bool condition)
	{
		throw new NotImplementedException();
	}

	public override void _EnterTree()
	{
		base._EnterTree();
		Target = StateMachine.GetOwner<Player>();
	}

	public override void _Ready()
	{
		base._Ready();
		var _inputManager = Target.InputHandler;
		_inputManager.MovementKeyPressed += SetCondition;
		_inputManager.ActionKeyPressed += ResetCondition;
	}

	public override void RunningState(double delta)
	{
		base.RunningState(delta);
		if (Target.InputHandler is IDirectionalInput _inputHandler)
		{
			Target.Body.Velocity = _inputHandler.GetMovementVector(Target.Body.Velocity) * MaxSpeed;
		}
	}
}