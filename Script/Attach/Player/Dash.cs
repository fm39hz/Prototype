using Godot;
using Component.StateMachine;
using Component.Animation;

public partial class Dash : DynamicState{
	private bool Dashing = false;
	private CharacterBody2D Player;
	public override void _EnterTree(){
		base._EnterTree();
		Player = GetOwnerOrNull<CharacterBody2D>();
		Frame = new FrameInfo(4, 2, 4.5);
		}
	
	public override void _PhysicsProcess(double delta){
		if (Input.IsActionJustPressed("ui_dash")){
			GD.Print("Dash");
			Dashing = true;
			}
		base._PhysicsProcess(delta);
		}
	public override void _UpdateCondition(double delta){
		Condition = Dashing;
		}
	public override void _RunningState(){
		Dashing = false;
		}
	}