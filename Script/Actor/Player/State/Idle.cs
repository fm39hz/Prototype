using System;
using System.IO;
using GameSystem.Component.FiniteStateMachine;
using GameSystem.Object.PhysicsBody;
using GameSystem.Object.Root.Concrete;

namespace Attach.PlayerState;

public partial class Idle : StaticState
{
	public Player Target { get; private set; }

	public override void _EnterTree()
	{
		base._EnterTree();
		Target = GetOwner<Player>();
	}

	public override void _Ready()
	{
		base._Ready();
		var _inputManager = Target.InputHandler;
		_inputManager.MovementKeyPressed += SetCondition;
		_inputManager.ActionKeyPressed += ResetCondition;
	}

	public override void SetCondition(bool condition)
	{
		Condition = !condition;
	}

	protected override void RunningState(double delta)
	{
		if (Target.PhysicsBody is not Creature _target)
		{
			throw new InvalidDataException("Player Must be Creature");
		}
		base.RunningState(delta);
		_target.Velocity = _target.Velocity.MoveToward(Target.Information.Direction.AsVector * MaxSpeed,
			Friction * Convert.ToSingle(delta));
	}
}