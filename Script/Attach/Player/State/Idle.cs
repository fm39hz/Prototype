using Component.Animation;
using Component.StateMachine;
using Management.InputManager;

namespace Game.Object.Dynamic{
	public partial class Idle : DynamicState{
		private PlayerInputManager inputManager;
		private Player player;
		public override void _EnterTree(){
			base._EnterTree();
			ID = 0;
			player = GetOwnerOrNull<Player>();
			inputManager = player.InputManager;
			Frame = new FrameInfo(4, 4.5);
			IsLoop = true;
			}
		public override void _Ready(){
			base._Ready();
			inputManager.MovementKeyPressed += this.SetCondition;
			inputManager.DashKeyPressed += this.ResetCondition;
			}
		public override void SetCondition(bool condition){
            if (!this.Initialized){
                return;
                }
			Condition = !condition;
			}
		}
	}
