using Godot;

namespace Controll{
	public static class ControllInput{
		public static Vector2 GetPlayerInput(Vector2 _inputVector){
			Vector2 Velocity = _inputVector;
				Velocity.X = Input.GetActionStrength("ui_right") - Input.GetActionStrength("ui_left");
				Velocity.Y = Input.GetActionStrength("ui_down") - Input.GetActionStrength("ui_up");
				Velocity = Velocity.Normalized();
			return Velocity;
			}
		}
	}