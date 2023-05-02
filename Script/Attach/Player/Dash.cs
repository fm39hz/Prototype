using Godot;
using Component.StateMachine;
using Component.Animation;

namespace Game.Object.Player{
	public partial class Dash : DynamicState{
		private CharacterBody2D Player;
		public override void _EnterTree(){
			base._EnterTree();
			Player = GetOwnerOrNull<CharacterBody2D>();
			Frame = new FrameInfo(4, 2, 4.5);
			IsLoop = false;
			}
		public override void SetCondition(bool condition){
			base.SetCondition(condition);
			}
		}
	}