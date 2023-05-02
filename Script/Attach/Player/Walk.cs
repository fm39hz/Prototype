using Godot;
using Component.StateMachine;
using Component.Animation;

namespace Game.Object.Player{
	public partial class Walk : DynamicState{
		private CharacterBody2D Player;
		public override void _EnterTree(){
			base._EnterTree();
			Player = GetOwnerOrNull<CharacterBody2D>();
			Frame = new FrameInfo(8, 1, 8.5);
			IsLoop = true;
			}
		}
	}