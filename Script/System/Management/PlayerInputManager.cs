using Godot;

namespace Management.InputManager{
	public partial class PlayerInputManager : Node{
		[Signal] public delegate void MovementKeyPressedEventHandler(bool IsPressed);
		[Signal] public delegate void DashKeyPressedEventHandler();
		public bool IsDoingSomething{get; set;}
		protected Vector2 Velocity{get; set;}
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
					this.IsDoingSomething = true;
					}
				if (!this.IsDoingSomething){
					if (_up || _down || _left || _right){
						EmitSignal(SignalName.MovementKeyPressed, true);
						}
					else if (!_up && !_down && !_left && !_right){
						EmitSignal(SignalName.MovementKeyPressed, false);
						}
					}
			}
		public Vector2 GetPlayerMovementVector(Vector2 _inputVector){
			if (!this.IsDoingSomething){
				_inputVector = Input.GetVector("ui_left", "ui_right", "ui_up", "ui_down");
				}
			Velocity = _inputVector.Normalized();
			return Velocity;
			}
		}
	}