using Godot;
using Controll;
using Component.StateMachine;

public partial class Player : CharacterBody2D{
	private bool isCollided;
	private StateMachine PlayerStateMachine;
	public override void _Ready(){
		PlayerStateMachine = GetChildOrNull<StateMachine>(0, false);
		}
	public override void _PhysicsProcess(double delta){
		Velocity = ControllInput.GetPlayerInput(Velocity) * PlayerStateMachine.getCurrentSpeed();
		isCollided = MoveAndSlide();
		}
	}
