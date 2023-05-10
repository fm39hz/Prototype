using Component.Animation;
using Component.StateMachine;
using Management.InputManager;

namespace Game.Object.Moving{
	public partial class Dash : DynamicState{
		private Player player;
		private PlayerInputManager inputManager;
		private SpriteSheet spriteSheet;
		public override void _EnterTree(){
			base._EnterTree();
			ID = 2;
			player = GetOwnerOrNull<Player>();
			inputManager = player.InputManager;
			spriteSheet = player.Sheet;
			Frame = new FrameInfo(4, 4.5);
			IsLoop = false;
			}
		public override void _Ready(){
			base._Ready();
			inputManager.DashKeyPressed += this.SetCondition;
			spriteSheet.AnimationFinished += this.ResetCondition;
			}
		public void SetCondition(){
            base.SetCondition(true);
			}
		public override void ResetCondition(){
			base.ResetCondition();
			inputManager.IsDoingSomething = false;
			}
		public override void _RunningState(double delta){
			base._RunningState(delta);
			player.Velocity = inputManager.GetPlayerMovementVector(player.Metadata.GetDirectionVector()) * this.MovingSpeed;
			}
		}
	}