using Godot;
using GameSystem.Data.Instance;
using GameSystem.Component.Object;

namespace GameSystem.Component.FiniteStateMachine;
	[GlobalClass]
	public partial class DynamicState : State{
		public DynamicObject Object { get; protected set; }
		public FrameData Frame { get; protected set; }
		[ExportCategory("Motion")]
			[Export] public float MovingSpeed { get; protected set; }
		[ExportCategory("Animation")]
			[Export] public int NumberOfFrame { get; protected set; }
			[Export] public bool IsLoop { get; protected set; }
			[Export] public float AnimationSpeed { get; protected set; }
		public override void _EnterTree(){
			base._EnterTree();
			Object = GetOwner<DynamicObject>();
			Frame = new(NumberOfFrame, AnimationSpeed);
				if (AnimationSpeed == 0){
					IsLoop = false;
					GD.Print("Animation Loop đã được set về false vì AnimationSpeed chưa được set");
					}
			}
		}
