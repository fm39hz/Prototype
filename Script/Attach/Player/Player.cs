using Godot;
using System;
using Management.InputManager;

namespace Game.Object.Moving{
	public partial class Player : DynamicObject{
		public PlayerInputManager InputManager{get; protected set;}
		public override void _EnterTree(){
			base._EnterTree();
				try{
					var _scene = GetParent();
					for (int i = 0; i < _scene.GetChildCount(); i++){
						if (_scene.GetChildOrNull<PlayerInputManager>(i) != null){
							InputManager = _scene.GetChild<PlayerInputManager>(i);
							}
						}
					}
				catch (InvalidCastException e){
					GD.Print(e.Message);
					}
				catch (NullReferenceException e){
					GD.Print(e.Message);
					}
			}
		public override void _PhysicsProcess(double delta){
			this.UpdateMetaData();
			var currentState = ObjectedStateMachine.CurrentState.ToDynamic();
			var Frame = currentState.Frame;
				Sheet.Animate(Frame, Metadata, GetRelativeResponseTime(delta), Metadata.IsLoopingAnimation);
			IsCollided = MoveAndSlide();
			}
		}
	}