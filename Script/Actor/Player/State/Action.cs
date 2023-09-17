using System.IO;
using GameSystem.Component.FiniteStateMachine;
using GameSystem.Component.Object.Composition;
using GameSystem.Component.Object.Compositor;
using GameSystem.Data.Instance;
using GameSystem.Object.Compositor.Implemented;
using GameSystem.Utils;

namespace Attach.PlayerState;

public partial class Action : StaticState
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
		base.SetCondition(true);
	}

	public override void ResetCondition()
	{
		base.ResetCondition();
		if (Target.Information is CreatureData _information)
		{
			_information.IsMoveable = true;
		}
	}

	public override void RunningState(double delta)
	{
		base.RunningState(delta);
		if (Target.Composition is not Creature _target)
		{
			throw new InvalidDataException("Player Must be Creature");
		}
		_target.Velocity = Target.InputHandler.TopDownVector(Target.Information.Direction.AsVector) *
						MaxSpeed;
	}
}