using Component.StateMachine;
using Management.InputManager;

namespace Game.Object.Dynamic{
	public partial class Walk : DynamicState{
		private PlayerInputManager inputManager;
		private Player player;
		public override void _EnterTree(){
			base._EnterTree();
			player = GetOwnerOrNull<Player>();
			inputManager = player.InputManager;
			}
		public override void _Ready(){
			base._Ready();
			inputManager.MovementKeyPressed += this.SetCondition;
			inputManager.DashKeyPressed += this.ResetCondition;
			}
		// public override void SetCondition(bool condition){
		// 	base.SetCondition(condition);
		// 	if (player.Velocity.IsZeroApprox() && !Machine.PreviousState.IsState(this)){
		// 		Condition = false;
		// 		}
		// 	}
		public override void _RunningState(double delta){
			base._RunningState(delta);
			player.Velocity = inputManager.GetPlayerMovementVector(player.Velocity) * this.MovingSpeed;
			}
		}
	}