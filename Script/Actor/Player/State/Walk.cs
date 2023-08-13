using GameSystem.Component.FiniteStateMachine;
using Actor;
namespace Attach.PlayerState;

public partial class Walk : StaticState
{
	public new PlayerBody Target { get; set; }

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

	// public override void SetCondition(bool condition)
	// {
	// 	base.SetCondition(condition);
	// 	if (Target.Velocity.IsZeroApprox() && !StateMachine.PreviousState.IsState(this))
	// 	{
	// 		Condition = false;
	// 	}
	// }

	public override void RunningState(double delta)
	{
		base.RunningState(delta);
		Target.Velocity = Target.InputManager.TopDownVector(Target.Velocity) * MaxSpeed;
	}
}