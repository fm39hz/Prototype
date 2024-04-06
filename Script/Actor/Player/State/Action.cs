using System.IO;
using GameSystem.Core.Component.FiniteStateMachine;
using GameSystem.Core.Component.InputManagement;
using GameSystem.Core.Object.Root.Concrete;
using Prototype.GameSystem.Component.FiniteStateMachine;

namespace Attach.PlayerState;

public partial class Action : StaticState, IControllableState
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
		Target.InputHandler.ActionKeyPressed += SetCondition;
		Target.SpriteSheet.AnimationFinished += ResetCondition;
	}

	public void SetCondition()
	{
		Condition = true;
	}

	public void ResetCondition()
	{
		Target.Information.IsMoveable = true;
	}

	public override void RunningState(double delta)
	{
		base.RunningState(delta);
		Target.Body.Velocity = ((IDirectionalInput)Target.InputHandler).GetMovementVector(Target.Information.Direction.AsVector) *
							MaxSpeed;
	}

    public void SetCondition(bool condition)
    {
    }
}