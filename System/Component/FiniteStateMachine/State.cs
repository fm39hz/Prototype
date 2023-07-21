using System;
using Godot;

namespace GameSystem.Component.FiniteStateMachine;
    [GlobalClass]
    public partial class State : Node{
		[Signal] public delegate void StateRunningEventHandler();
        [Export] public int ID { get; set; }
        public bool Condition { get; protected set; }
        protected StateMachine StateController{get; set;}
        protected bool IsInitialized { get; set; }
        public override void _EnterTree(){
            try{
                this.StateController = this.GetParent<StateMachine>();
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
            this.UpdateCondition(delta);
                if (StateController.CurrentState == this){
                    RunningState(delta);
                    }
            }
        protected void Init(){
            this.IsInitialized = true;
            }
        public DynamicState ToDynamic(){
            return this as DynamicState;
            }
        public StaticState ToStatic(){
            return this as StaticState;
            }
        public bool IsState(State state){
            if (state == this){
                return true;
                }
            return false;
            }
        public bool IsState(String stateName){
            if (stateName == this.Name){
                return true;
                }
            return false;
            }
        public virtual void SetCondition(bool condition){
            if (!this.IsInitialized){
                return;
                }
            this.Condition = condition;
            }
        public virtual void ResetCondition(){
            if (!this.IsInitialized){
                return;
                }
            this.Condition = false;
            }
        public virtual void EnteredMachine(){
            if (!this.IsInitialized){
                return;
                }
            }
        public virtual void UpdateCondition(double delta){
            if (!this.IsInitialized){
                return;
                }
            }
        public virtual void RunningState(double delta){
            if (!this.IsInitialized){
                return;
                }
            this.EmitSignal(SignalName.StateRunning);
            }
        public virtual void ExitState(){
            if (!this.IsInitialized){
                return;
                }
            }
        }
