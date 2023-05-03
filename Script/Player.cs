using Godot;
using System;
using Component.Animation;
using Component.StateMachine;
using Management.InputManager;

namespace Game.Object.Player{
	public partial class Player : CharacterBody2D{
		private bool isCollided;
		private StateMachine PlayerSMC;
		public SpriteSheet Sheet;
		public PlayerInputManager InputManager;
		public override void _EnterTree(){
			try{
				Sheet = GetChild<SpriteSheet>(0);
				InputManager = GetParent().GetChild<PlayerInputManager>(0);
				}
			catch (InvalidCastException e){
				GD.Print(e.Message);
				}
			catch (NullReferenceException e){
				GD.Print(e.Message);
				}
			}
		public override void _Ready(){
			try{
				PlayerSMC = GetChild<StateMachine>(2);
				}
			catch (InvalidCastException e){
				GD.Print(e.Message);
				}
			catch (NullReferenceException e){
				GD.Print(e.Message);
				}
			}
		public override void _PhysicsProcess(double delta){
			var currentState = PlayerSMC.Current.ToDynamic();
			GD.Print(currentState.Name);
			var Frame = currentState.Frame;
			Velocity = InputManager.GetPlayerMovementVector(Velocity) * currentState.MovingSpeed;
				Frame.GetDirectionFacing(Velocity);
				Sheet.Animate(Frame, FrameInfo.GetRelativeResponseTime(delta), currentState.IsLoop);
			isCollided = MoveAndSlide();
			}
		}
	}