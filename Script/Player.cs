using Godot;
using Controll;
using Component.StateMachine;
using Component.Animation;

public partial class Player : CharacterBody2D{
	private bool isCollided;
	private StateMachine SMC;
	private SheetComponent Sheet;
	public override void _Ready(){
		Sheet = GetChild<SheetComponent>(0);
		SMC = GetChild<StateMachine>(2);
		Sheet.AnimationFinished += SMC.States[2].ExitState;
		}
	public override void _PhysicsProcess(double delta){
		FrameComponent Frame = SMC.Current.Frame;
		Velocity = ControllInput.GetPlayerMovementVector(Velocity, SMC.Current.Controllable) * SMC.GetCurrentSpeed();
			Frame.GetDirection(Velocity);
			Sheet.RunAnimation(Frame, ResponseTime.GetRelative(delta), SMC.Current.Controllable);
		isCollided = MoveAndSlide();
		}
	}
