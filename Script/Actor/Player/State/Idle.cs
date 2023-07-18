using GameSystem.Component.FiniteStateMachine;

namespace  Actor.TargetPlayer;
	public partial class Idle : DynamicState{
		public override void _Ready(){
			base._Ready();
			var _inputManager = Object.PlayerInputManager;
			_inputManager.MovementKeyPressed += this.SetCondition;
			_inputManager.DashKeyPressed += this.ResetCondition;
			}
		public override void SetCondition(bool condition){
			if (!this.IsInitialized){
				return;
				}
			Condition = !condition;
			}
		}
