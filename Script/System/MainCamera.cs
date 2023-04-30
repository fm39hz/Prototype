using Godot;
using System;

public partial class MainCamera : Camera2D{
	Viewport mainView;
	Vector2 screenSize;
	public override void _Ready(){
		mainView = GetViewport();
		screenSize = new Vector2(Convert.ToSingle(ProjectSettings.GetSetting("display/window/size/width")), Convert.ToSingle(ProjectSettings.GetSetting("display/window/size/height")));
			mainView.SizeChanged += resizeViewport;
		}
	private void resizeViewport(){
		Vector2 newSize = DisplayServer.ScreenGetSize() / 8;
		float scaleFactor;
			if (newSize.X < screenSize.X){
				scaleFactor = screenSize.X / newSize.X;
				newSize = new Vector2(newSize.X * scaleFactor, newSize.Y * scaleFactor);
				}
			else if (newSize.Y < screenSize.Y){
				scaleFactor = screenSize.Y / newSize.Y;
				newSize = new Vector2(newSize.X * scaleFactor, newSize.Y * scaleFactor);
				}
			DisplayServer.WindowSetSize((Vector2I)newSize, 0);
		}
	}
