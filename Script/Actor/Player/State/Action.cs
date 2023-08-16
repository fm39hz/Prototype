using GameSystem.Component.FiniteStateMachine;
using GameSystem.Component.Object.Compositor;
using GameSystem.Utils;

namespace Attach.PlayerState;
using Actor;

public partial class Action : StaticState
{
	public PlayerBody Target { get; private set; }

	public override void _EnterTree()
	{
		base._EnterTree();
		Target = StateMachine.GetOwner<CreatureCompositor>().GetFirstChildOfType<PlayerBody>();
	}
	public override void _Ready()
	{
		base._Ready();
		Target.InputManager.ActionKeyPressed += SetCondition;
		Target.Compositor.SpriteSheet.AnimationFinished += ResetCondition;
	}

	public void SetCondition()
	{
		base.SetCondition(true);
	}

	public override void ResetCondition()
	{
		base.ResetCondition();
		Target.Compositor.Information.IsMoveable = true;
	}

	public override void RunningState(double delta)
	{
		base.RunningState(delta);
		Target.Velocity = Target.InputManager.TopDownVector(Target.Compositor.Information.Direction.AsVector) * MaxSpeed;
	}
}