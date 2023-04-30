using Godot;
using Component.StateMachine;

public partial class Walk : ControllableState{
	private CharacterBody2D Player;
	public override void _EnterTree(){
		Player = GetOwnerOrNull<CharacterBody2D>();
			Condition = (!Player.Velocity.IsEqualApprox(Vector2.Zero));
		}
	public override void UpdateState(){
		base.UpdateState();
			Condition = (!Player.Velocity.IsEqualApprox(Vector2.Zero));
		}
	}
