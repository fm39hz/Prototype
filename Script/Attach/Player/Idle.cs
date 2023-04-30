using Godot;
using Component.StateMachine;

public partial class Idle : ControllableState{
	private CharacterBody2D Player;
	public override void _EnterTree(){
		base._EnterTree();
		Player = GetOwnerOrNull<CharacterBody2D>();
			Condition = (Player.Velocity.IsEqualApprox(Vector2.Zero));
		}
	public override void UpdateCondition(double delta){
		Condition = (Player.Velocity.IsEqualApprox(Vector2.Zero));
		}
	}
