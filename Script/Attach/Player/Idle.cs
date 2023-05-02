using Godot;
using Component.StateMachine;
using Component.Animation;

namespace Game.Object.Player{
	public partial class Idle : DynamicState{
		private CharacterBody2D Player;
		public override void _EnterTree(){
			base._EnterTree();
			Player = GetOwnerOrNull<CharacterBody2D>();
			Frame = new FrameInfo(4, 0, 4.5);
			}
		public override void _UpdateCondition(double delta){
			Condition = (Player.Velocity.IsEqualApprox(Vector2.Zero) && Player.GetSlideCollisionCount() == 0);
			}
		}
	}
