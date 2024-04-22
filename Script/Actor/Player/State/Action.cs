using GameSystem.Component.FiniteStateMachine;
using GameSystem.Core.Component.FiniteStateMachine;
using GameSystem.Core.Component.InputManagement;
using GameSystem.Core.Object.Root.Concrete;

namespace Attach.PlayerState;

public partial class Action : StaticState, IControllableState
{
	public Player Target { get; private set; }

	public void ResetCondition()
	{
		Target.Information.IsMoveable = true;
	}

	public void SetCondition(bool condition)
	{
	}

	public override void _EnterTree()
	{
		base._EnterTree();
		Target = GetOwner<Player>();
	}

	public override void _Ready()
	{
		base._Ready();
		Target.InputHandler.ActionKeyPressed += SetCondition;
		Target.SpriteSheet.AnimationFinished += ResetCondition;
	}

	public void SetCondition()
	{
		Condition = true;
	}

	public override void RunningState(double delta)
	{
		base.RunningState(delta);
		if (Target.InputHandler is IDirectionalInput _inputHandler)
		{
			Target.Body.Velocity = _inputHandler.GetMovementVector(Target.Information.Direction.AsVector) * MaxSpeed;
		}
	}
}