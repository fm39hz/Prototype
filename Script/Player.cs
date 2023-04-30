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
		}
	public override void _PhysicsProcess(double delta){
		FrameComponent Frame = SMC.Current.Frame;
		Velocity = ControllInput.GetPlayerInput(Velocity) * SMC.getCurrentSpeed();
			Frame.GetDirection(Velocity);
			Sheet.RunAnimation(Frame, ResponseTime.GetRelative(delta), true);
		isCollided = MoveAndSlide();
		}
	}
