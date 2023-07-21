using System;
using Godot;
using GameSystem.Component.Object;

namespace GameSystem.Component.Manager;
	[GlobalClass]
	public partial class InputManager : Node{
		[Signal] public delegate void MovementKeyPressedEventHandler(bool IsPressed);
		private DynamicObject Target { get; set; }
		public override void _Ready(){
			try{
				Target = GetOwner<DynamicObject>();
				}
			catch(NullReferenceException InputMustInPlayer){
				GD.Print("InputManager phải được đặt trong 1 Đối tượng DynamicObject");
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
				if (Target.IsMoveable){
					if (_up || _down || _left || _right){
						EmitSignal(SignalName.MovementKeyPressed, true);
						}
					else if (!_up && !_down && !_left && !_right){
						EmitSignal(SignalName.MovementKeyPressed, false);
						}
					}
			}
		public Vector2 TopDownVector(Vector2 inputVector){
			if (Target.IsMoveable){
				inputVector = Input.GetVector("ui_left", "ui_right", "ui_up", "ui_down");
				}
			return inputVector;
			}
		}
