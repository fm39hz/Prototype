using GameSystem.Component.FiniteStateMachine;
using GameSystem.Object.Root.Concrete;
using GameSystem.Object.PhysicsBody;
using System.IO;

namespace Attach.PlayerState;

public partial class Walk : StaticState
{
	public Player Target { get; private set; }

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

	protected override void RunningState(double delta)
	{
		if (Target.PhysicsBody is not Creature _target)
		{
			throw new InvalidDataException("Player Must be Creature");
		}
		base.RunningState(delta);
		_target.Velocity = Target.InputHandler.TopDownVector(_target.Velocity) * MaxSpeed;
	}
}