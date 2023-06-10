using System;
using Godot;
using Component.Object.Dynamic;

namespace Component.Manager;
	public partial class InputManager : Node{
		[Signal] public delegate void MovementKeyPressedEventHandler(bool IsPressed);
		[Signal] public delegate void DashKeyPressedEventHandler();
		private Player CurrentPlayer{get; set;}
		public override void _Ready(){
			try{
				CurrentPlayer = GetOwner<Player>();
				}
			catch(NullReferenceException InputMustInPlayer){
				GD.Print("InputManager phải được đặt trong Player");
				throw InputMustInPlayer;
				}
			}
		public override void _UnhandledKeyInput(InputEvent @event){
			if (@event is InputEventKey keyEscape){
				if (keyEscape.IsPressed() && keyEscape.Keycode == Key.Escape){
					GetTree().Quit();
					}
				}
			}
		public override void _PhysicsProcess(double delta){
			var _up = Input.IsActionPressed("ui_up");
			var _down = Input.IsActionPressed("ui_down");
			var _left = Input.IsActionPressed("ui_left");
			var _right = Input.IsActionPressed("ui_right");
				if (Input.IsActionJustPressed("ui_dash")){
					EmitSignal(SignalName.DashKeyPressed);
					CurrentPlayer.CanMove = false;
					}
				if (CurrentPlayer.CanMove){
					if (_up || _down || _left || _right){
						EmitSignal(SignalName.MovementKeyPressed, true);
						}
					else if (!_up && !_down && !_left && !_right){
						EmitSignal(SignalName.MovementKeyPressed, false);
						}
					}
			}
		public Vector2 GetPlayerMovementVector(Vector2 inputVector){
			if (CurrentPlayer.CanMove){
				inputVector = Input.GetVector("ui_left", "ui_right", "ui_up", "ui_down");
				}
			return inputVector;
			}
		}
