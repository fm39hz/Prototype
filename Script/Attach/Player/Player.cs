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
					InputManager = GetFirstSiblingOfType<PlayerInputManager>();
					}
				catch (InvalidCastException e){
					GD.Print(e.Message);
					}
				catch (NullReferenceException e){
					GD.Print(e.Message);
					}
			}
		public override void _PhysicsProcess(double delta){
			UpdateMetaData();
			var currentState = ObjectedStateMachine.CurrentState.ToDynamic();
			var Frame = currentState.Frame;
				Sheet.Animate(Frame, Metadata, GetRelativeResponseTime(delta));
			IsCollided = MoveAndSlide();
			}
		}
	}