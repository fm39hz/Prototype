using Component.Manager;

namespace Component.Object.Dynamic;
	public partial class Player : DynamicObject{
		public InputManager InputManager{get; private set;}
		public override void _EnterTree(){
			base._EnterTree();
				InputManager = GetFirstChildOfType<InputManager>();
			}
		}