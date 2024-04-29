using GameSystem.Utils.Singleton;
using Godot;

namespace Attach.GUI;

public partial class Monitoring : RichTextLabel
{
	public override void _PhysicsProcess(double delta)
	{
		Visible = GlobalStatus.Debugging();
		Text = Engine.GetFramesPerSecond() + " fps";
	}
}