using Godot;
using Component.Animation;
using Game.Object;

namespace Component.StateMachine{
    public abstract partial class DynamicState : State{
        [Export] public float MovingSpeed{get; protected set;}
        public FrameInfo Frame{get; protected set;}
        public bool IsLoop{get; protected set;}
        public DynamicObject OwnerObjected{get; protected set;}
        }
    public abstract partial class StaticState : State{
        }
    }