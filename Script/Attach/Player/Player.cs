using Godot;
using System;
using Component.Animation;
using Component.StateMachine;
using Management.InputManager;
using Management.Direction;

namespace Game.Object.Player{
	public partial class Player : CharacterBody2D{
		private int DirectionNumber;
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
			var currentState = PlayerSMC.CurrentState.ToDynamic();
			GD.Print(currentState.Name);
			var Frame = currentState.Frame;
				if (!Velocity.IsEqualApprox(Vector2.Zero)){
					DirectionNumber = new DirectionManager().GetDirectionNumber(Velocity);
					}
				Sheet.Animate(Frame, DirectionNumber, FrameInfo.GetRelativeResponseTime(delta), currentState.IsLoop);
			isCollided = MoveAndSlide();
			}
		}
	}