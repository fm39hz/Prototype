using GameSystem.Component.Manager;
using GameSystem.Component.Object.Composition;
using GameSystem.Component.Object.Compositor;
using GameSystem.Utils;

namespace Actor;

public partial class PlayerBody : Creature
{
	/// <summary>
	/// Manage the Input Signal
	/// </summary>
	public InputManager InputManager { get; protected set; }

	public override void _EnterTree()
	{
		base._EnterTree();
		InputManager = GetParent<CreatureCompositor>().GetFirstChild<InputManager>();
	}
}