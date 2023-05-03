using Godot;

namespace Management.InputManager{
	public partial class PlayerInputManager : Node{
		[Signal] public delegate void MovementKeyPressedEventHandler(bool IsPressed);
		[Signal] public delegate void DashKeyPressedEventHandler();
		public override void _UnhandledInput(InputEvent @event){
			if (@event is InputEventKey keyEscape){
				if (keyEscape.IsPressed() && keyEscape.Keycode == Key.Escape){
					GetTree().Quit();
					}
				}
			}
		public override void _PhysicsProcess(double delta){
			if (Input.IsActionJustPressed("ui_dash")){
				EmitSignal(SignalName.DashKeyPressed);
				}
			}
		public Vector2 GetPlayerMovementVector(Vector2 _inputVector){
			Vector2 Velocity = _inputVector;
				Velocity.X = Input.GetActionStrength("ui_right") - Input.GetActionStrength("ui_left");
				Velocity.Y = Input.GetActionStrength("ui_down") - Input.GetActionStrength("ui_up");
			if (Velocity != _inputVector){
				EmitSignal(SignalName.MovementKeyPressed, true);
				}
			else if (Velocity == _inputVector){
				EmitSignal(SignalName.MovementKeyPressed, false);
				}
			return Velocity.Normalized();
			}
		}
	}