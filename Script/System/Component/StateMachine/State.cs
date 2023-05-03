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
                GD.Print("Failed to detect State Machine for State \"" + this.Name + "\"");
                GD.Print("This State's Parent is \"" + this.GetParent().GetType() + "\"");
                }
            }
        public override void _Ready(){
             this.Init();
            }
        public override void _PhysicsProcess(double delta){
            this._UpdateCondition(delta);
                if (this.Machine.CurrentState == this){
                    _RunningState(delta);
                    }
            }
        protected void Init(){
            this.Initialized = true;
            }
        public DynamicState ToDynamic(){
            if (this is not State || this is StaticState){
                return null;
                }
            return (DynamicState)this;
            }
        public StaticState ToStatic(){
            if (this is not State || this is DynamicState){
                return null;
                }
            return (StaticState)this;
            }
        public virtual void SetCondition(bool condition){
            if (!this.Initialized){
                return;
                }
            Condition = condition;
            }
        public virtual void ResetCondition(){
            if (!this.Initialized){
                return;
                }
            Condition = false;
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
        public virtual void _RunningState(double delta){
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