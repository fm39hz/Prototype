using Godot;
using System;
using Controll;
using Component.Animation;
using Component.StateMachine;

namespace Game.Object.Player{
	public partial class Player : CharacterBody2D{
		private bool isCollided;
		private StateMachine PlayerSMC;
		private SheetComponent Sheet;
		private PlayerInputManager InputManager;
		public override void _Ready(){
			try{
				Sheet = GetChild<SheetComponent>(0);
				PlayerSMC = GetChild<StateMachine>(2);
				InputManager = GetParent().GetChild<PlayerInputManager>(2);
				}
			catch (InvalidCastException e){
				GD.Print(e.Message);
				}
			catch (NullReferenceException e){
				GD.Print(e.Message);
				}
			foreach (State target in PlayerSMC.States){
				InputManager.MovementKeyPressed += target.SetCondition;
				InputManager.DashKeyPressed += target.SetCondition;
				}
			}
		public override void _PhysicsProcess(double delta){
			var currentState = PlayerSMC.Current.ToDynamic();
			var Frame = currentState.Frame;
			Velocity = InputManager.GetPlayerMovementVector(Velocity) * currentState.MovingSpeed;
				Frame.GetDirection(Velocity);
				Sheet.RunAnimation(Frame, FrameInfo.GetRelativeResponseTime(delta), currentState.IsLoop);
			isCollided = MoveAndSlide();
			}
		}
	public partial class PlayerState : DynamicState{
		}
	}