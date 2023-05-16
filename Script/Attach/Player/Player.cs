using Godot;
using System;
using Management.InputManager;

namespace Game.Object.Dynamic{
	public partial class Player : DynamicObject{
		public PlayerInputManager InputManager{get; private set;}
		public override void _EnterTree(){
			base._EnterTree();
				try{
					var _scene = GetParent();
					InputManager = GetFirstChildOfType<PlayerInputManager>();
					}
				catch (InvalidCastException e){
					GD.Print(e.Message);
					}
				catch (NullReferenceException e){
					GD.Print(e.Message);
					}
			}
		}
	}