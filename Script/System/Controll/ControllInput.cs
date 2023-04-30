namespace Controll;
	public partial class ControllInput : Node{
		public override void _UnhandledInput(InputEvent @event){
			if (@event is InputEventKey eventKey){
				if (eventKey.Pressed && eventKey.Keycode == Key.Escape){
					GetTree().Quit();
					}
				}
			}
		public static Vector2 GetPlayerMovementVector(Vector2 _inputVector, bool Controllable){
			Vector2 Velocity = _inputVector;
				if (Controllable){
					Velocity.X = Input.GetActionStrength("ui_right") - Input.GetActionStrength("ui_left");
					Velocity.Y = Input.GetActionStrength("ui_down") - Input.GetActionStrength("ui_up");
					}
			return Velocity.Normalized();
			}
		}
	