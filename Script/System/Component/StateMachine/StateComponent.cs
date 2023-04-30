using Godot;
using Component.Animation;

namespace Component{
    namespace StateMachine{
        public partial class State : Node{
            public StateMachine Machine{get; set;}
            public bool Condition{get; set;}
            protected bool Initialized{get; set;}
        [Signal]
            public delegate void StateEnteredEventHandler();
        [Signal]
            public delegate void StateRunningEventHandler();
        [Signal]
            public delegate void StateExitedEventHandler();
            public override void _EnterTree(){
                Machine = this.GetParent<StateMachine>();
                this.Init();
                }
            public override void _PhysicsProcess(double delta){
                UpdateCondition(delta);
                    if (Machine.Current == this){
                        RunningState(delta);
                        }
                }
            public void Init(){
                Initialized = true;
                }
            public virtual void EnteredMachine(){
                if (Initialized){
                    EmitSignal(SignalName.StateEntered);
                    }
                }
            public virtual void UpdateCondition(double delta){
                }
            public virtual void RunningState(double delta){
                if (Initialized){
                    EmitSignal(SignalName.StateRunning);
                    }
                }
            public virtual void ExitState(){
                if (Initialized){
                    EmitSignal(SignalName.StateExited);
                    }
                }
            }
        public partial class ControllableState : State{
            [Export]
                public float Speed{get; set;}
            public FrameComponent Frame{get; set;} = new FrameComponent(0, 0, 0);
            }
        public partial class UncontrollableState : State{
            [Export]
                public Timer Time{get; set;}
            }
        }
    }