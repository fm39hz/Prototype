using System;
using Godot;

namespace Component.StateMachine{
    public abstract partial class State : Node{
		[Signal] public delegate void StateRunningEventHandler();
        public bool Condition{get; protected set;}
        protected StateMachine Machine{get; set;}
        protected bool Initialized{get; set;}
        public override void _EnterTree(){
            try{
                this.Machine = this.GetParent<StateMachine>();
                }
            catch (NullReferenceException){
                GD.Print("Failed to detect State Machine for State: \"" + this.Name + "\"");
                GD.Print("This State's Parent is " + this.GetParent().GetType());
                }
            }
        public override void _Ready(){
             this.Init();
            }
        public override void _PhysicsProcess(double delta){
            this._UpdateCondition(delta);
                if (this.Machine.Current == this){
                    _RunningState();
                    }
            }
        public DynamicState ToDynamic(){
            if (this is not State state){
                return null;
                }
            return (DynamicState)this;
            }
        public StaticState ToStatic(){
            if (this is not State state){
                return null;
                }
            return (StaticState)this;
            }
        protected void Init(){
            this.Initialized = true;
            }
        public virtual void _EnteredMachine(){
            if (!this.Initialized){
                return;
                }
            }
        public virtual void _UpdateCondition(double delta){
            if (!this.Initialized){
                return;
                }
            }
        public virtual void _RunningState(){
            if (!this.Initialized){
                return;
                }
                this.EmitSignal(SignalName.StateRunning);
            }
        public virtual void _ExitState(){
            if (!this.Initialized){
                return;
                }
            }
        }
    }