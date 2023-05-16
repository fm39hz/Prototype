using Godot;

namespace Management.InputManager{
	public partial class PlayerInputManager : Node{
		[Signal] public delegate void MovementKeyPressedEventHandler(bool IsPressed);
		[Signal] public delegate void DashKeyPressedEventHandler();
		public bool CanMove{private get; set;}
		public override void _UnhandledKeyInput(InputEvent @event){
			if (@event is InputEventKey keyEscape){
				if (keyEscape.IsPressed() && keyEscape.Keycode == Key.Escape){
					GetTree().Quit();
					}
				}
			}
		public override void _PhysicsProcess(double delta){
			bool _up = Input.IsActionPressed("ui_up");
			bool _down = Input.IsActionPressed("ui_down");
			bool _left = Input.IsActionPressed("ui_left");
			bool _right = Input.IsActionPressed("ui_right");
				if (Input.IsActionJustPressed("ui_dash")){
					EmitSignal(SignalName.DashKeyPressed);
					this.CanMove = false;
					}
				if (this.CanMove){
					if (_up || _down || _left || _right){
						EmitSignal(SignalName.MovementKeyPressed, true);
						}
					else if (!_up && !_down && !_left && !_right){
						EmitSignal(SignalName.MovementKeyPressed, false);
						}
					}
			}
		public Vector2 GetPlayerMovementVector(Vector2 inputVector){
			if (this.CanMove){
				inputVector = Input.GetVector("ui_left", "ui_right", "ui_up", "ui_down").LimitLength(1f);
				}
			return inputVector.Normalized();
			}
		}
	}