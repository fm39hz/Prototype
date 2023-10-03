using Godot;

namespace Attach.GUI;
public partial class Monitoring : RichTextLabel
{
	public override void _Process(double delta)
	{
		Text = Engine.GetFramesPerSecond().ToString() + " fps";
	}
}
