using Godot;

namespace Component{
    namespace StateMachine{
        public partial class State : Node{
            public bool Condition{get; set;}
            protected bool Initialized = false;
            protected bool Running = false;
        [Signal]
            public delegate void StateEnteredEventHandler();
        [Signal]
            public delegate void StateRunningEventHandler();
        [Signal]
            public delegate void StateExitedEventHandler();

            public void Init(){
                Initialized = true;
                StateEntered += RunningState;
                }
            public virtual void EnterState(){
                if (!Initialized){
                    return;
                    }
                    EmitSignal(SignalName.StateEntered);
                }
            public virtual void RunningState(){
                if (!Initialized){
                    return;
                    }
                Running = true;
                    EmitSignal(SignalName.StateRunning);
                    UpdateState();
                }
            public virtual void UpdateState(){
                if (!Running){
                    return;
                    }
                }
            public virtual void ExitState(){
                if (!Initialized){
                    return;
                    }
                Initialized = false;
                Running = false;
                    EmitSignal(SignalName.StateExited);
                }
            }
        public partial class ControllableState : State{
            [Export]
                public float Speed{get; set;}
            }
        public partial class UncontrollableState : State{
            [Export]
                public Timer Time{get; set;}
            }
        }
    }