using Component.Animation;
using Component.StateMachine;
using Management.InputManager;

namespace Game.Object.Dynamic{
	public partial class Dash : DynamicState{
		private Player player;
		private PlayerInputManager inputManager;
		private SpriteSheet spriteSheet;
		public override void _EnterTree(){
			base._EnterTree();
			player = GetOwnerOrNull<Player>();
			inputManager = player.InputManager;
			spriteSheet = player.Sheet;
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
			player.CanMove = true;
			}
		public override void _RunningState(double delta){
			base._RunningState(delta);
			player.Velocity = inputManager.GetPlayerMovementVector(player.Metadata.GetDirectionVector()) * this.MovingSpeed;
			}
		}
	}