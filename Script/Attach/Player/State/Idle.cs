using Component.FiniteStateMachine;
using Component.Manager;
using Component.Object.Dynamic;

public partial class Idle : DynamicState{
	private InputManager inputManager;
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
	public override void SetCondition(bool condition){
		if (!this.Initialized){
			return;
			}
		Condition = !condition;
		}
	}