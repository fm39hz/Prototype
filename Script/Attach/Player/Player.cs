using Management.InputManager;

namespace Game.Object.Dynamic{
	public partial class Player : DynamicObject{
		public PlayerInputManager InputManager{get; private set;}
		public override void _EnterTree(){
			base._EnterTree();
				var _scene = GetParent();
				InputManager = GetFirstChildOfType<PlayerInputManager>();
			}
		}
	}