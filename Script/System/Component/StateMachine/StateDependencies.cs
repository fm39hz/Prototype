using Godot;
using Component.Animation;

namespace Component.StateMachine{
    public abstract partial class DynamicState : State{
        [Export] public float MovingSpeed{get; set;}
        public FrameInfo Frame{get; protected set;}
        public bool IsLoop{get; protected set;}
        }
    public abstract partial class StaticState : State{
        
        }
    }