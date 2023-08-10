using Godot;
using System;
using GameSystem.Component.Manager;
using GameSystem.Component.Object.Directional;
using GameSystem.Utility;

namespace Actor;
public partial class Player : LivingObject
{
	/// <summary>
	/// Manage the Input Signal
	/// </summary>
	public InputManager InputManager { get; protected set; }

	public override void _EnterTree()
	{
		base._EnterTree();
		InputManager = GodotNodeInteractive.GetFirstChildOfType<InputManager>(this);
	}
}
