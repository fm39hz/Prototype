using GameSystem.Component.FiniteStateMachine;
using Actor;
namespace Attach.PlayerState;

public partial class Walk : DynamicState
{
	public new Player Object { get; set; }

	public override void _EnterTree()
	{
		Object = GetOwner<Player>();
	}
	public override void _Ready()
	{
		base._Ready();
		Object.InputManager.MovementKeyPressed += SetCondition;
		Object.InputManager.ActionKeyPressed += ResetCondition;
	}

	// public override void SetCondition(bool condition)
	// {
	// 	base.SetCondition(condition);
	// 	if (Object.Velocity.IsZeroApprox() && !StateController.PreviousState.IsState(this))
	// 	{
	// 		Condition = false;
	// 	}
	// }

	public override void RunningState(double delta)
	{
		base.RunningState(delta);
		Object.Velocity = Object.InputManager.TopDownVector(Object.Velocity) * MaxSpeed;
	}
}