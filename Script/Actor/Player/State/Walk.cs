using GameSystem.Core.Component.FiniteStateMachine;
using GameSystem.Core.Component.InputManagement;
using GameSystem.Core.Object.Root.Concrete;
using GameSystem.Component.FiniteStateMachine;

namespace Attach.PlayerState;

public partial class Walk : StaticState, IControllableState
{
	public Player Target { get; private set; }

    public void ResetCondition()
    {
        throw new System.NotImplementedException();
    }

    public void SetCondition(bool condition)
    {
        throw new System.NotImplementedException();
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
		Target.Body.Velocity = ((IDirectionalInput)Target.InputHandler).GetMovementVector(Target.Body.Velocity) * MaxSpeed;
	}
}