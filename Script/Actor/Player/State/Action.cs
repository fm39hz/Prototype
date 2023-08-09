using GameSystem.Component.FiniteStateMachine;

namespace Actor.Player;

public partial class Action : DynamicState
{
	public override void _Ready()
	{
		base._Ready();
		Object.InputManager.ActionKeyPressed += SetCondition;
		Object.Sheet.AnimationFinished += ResetCondition;
	}

	public void SetCondition()
	{
		base.SetCondition(true);
	}

	public override void ResetCondition()
	{
		base.ResetCondition();
		Object.IsMoveable = true;
	}

	public override void RunningState(double delta)
	{
		base.RunningState(delta);
		Object.Velocity = Object.InputManager.TopDownVector(Object.Information.GetDirectionAsVector()) * MaxSpeed;
	}
}