using System;
using GameSystem.Core.Component.FiniteStateMachine;
using GameSystem.Core.Object.Root.Concrete;
using Prototype.GameSystem.Component.FiniteStateMachine;

namespace Attach.PlayerState;

public partial class Idle : StaticState, IControllableState
{
	public Player Target { get; private set; }

	public override void _EnterTree()
	{
		base._EnterTree();
		Target = GetOwner<Player>();
	}
    public void SetCondition(bool condition)
    {
		Condition = !condition;
    }

    public void ResetCondition()
    {
		Condition = false;
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
		Target.Body.Velocity = Target.Body.Velocity.MoveToward(Target.Information.Direction.AsVector * MaxSpeed,
			Friction * Convert.ToSingle(delta));
	}

}