using Component.Animation;
using Component.StateMachine;
using Management.InputManager;

namespace Game.Object.Dynamic{
	public partial class Walk : DynamicState{
		private PlayerInputManager inputManager;
		private Player player;
		public override void _EnterTree(){
			base._EnterTree();
			ID = 1;
			player = GetOwnerOrNull<Player>();
			inputManager = player.InputManager;
			Frame = new FrameInfo(8, 8.5);
			IsLoop = true;
			}
		public override void _Ready(){
			base._Ready();
			inputManager.MovementKeyPressed += this.SetCondition;
			inputManager.DashKeyPressed += this.ResetCondition;
			}
		public override void _RunningState(double delta){
			base._RunningState(delta);
			player.Velocity = inputManager.GetPlayerMovementVector(player.Velocity) * this.MovingSpeed;
			}
		}
	}