using GameSystem.Component.FiniteStateMachine;
using Actor;
using Godot;

namespace Attach.PlayerState;

public partial class Walk : StaticState
{
	public PlayerBody Target { get; private set; }

	public override void _EnterTree()
	{
		base._EnterTree();
		Target = StateMachine.GetParent<PlayerBody>();
	}
	public override void _Ready()
	{
		base._Ready();
		Target.InputManager.MovementKeyPressed += SetCondition;
		Target.InputManager.ActionKeyPressed += ResetCondition;
	}
	public override void RunningState(double delta)
	{
		base.RunningState(delta);
		Target.Velocity = Target.InputManager.TopDownVector(Target.Velocity) * MaxSpeed;
	}
}