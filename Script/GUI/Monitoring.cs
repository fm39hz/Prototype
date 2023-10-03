using GameSystem.Data.Global;
using Godot;

namespace Attach.GUI;
public partial class Monitoring : RichTextLabel
{
	public override void _Process(double delta)
	{
		if (GlobalStatus.GetDebugInfo())
		{
			Text = Engine.GetFramesPerSecond().ToString() + " fps";
		}
	}
}
