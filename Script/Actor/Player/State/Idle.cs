using System;
using GameSystem.Component.FiniteStateMachine;
using Actor;
using GameSystem.Object.Compositor;
using GameSystem.Utils;

namespace Attach.PlayerState;

public partial class Idle : StaticState
{
	public PlayerBody Target { get; private set; }

	public override void _EnterTree()
	{
		base._EnterTree();
		Target = StateMachine.GetOwner<CreatureCompositor>().GetFirstChild<PlayerBody>();
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
		Condition = !condition;
	}

	public override void RunningState(double delta)
	{
		base.RunningState(delta);
		Target.Velocity = Target.Velocity.MoveToward(Target.Compositor.Information.Direction.AsVector * MaxSpeed,
			Friction * Convert.ToSingle(delta));
	}
}