using Management.InputManager;

namespace Game.Object.Dynamic{
	public partial class Player : DynamicObject{
		public PlayerInputManager InputManager{get; private set;}
		public override void _EnterTree(){
			base._EnterTree();
				InputManager = GetFirstChildOfType<PlayerInputManager>();
			}
		}
	}