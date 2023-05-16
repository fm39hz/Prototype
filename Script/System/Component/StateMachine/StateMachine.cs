using Godot;
using System.Collections.Generic;
using System.Linq;

namespace Component.StateMachine{
	public abstract partial class StateMachine : Node{
		[Signal] public delegate void StateEnteredEventHandler();
		[Signal] public delegate void StateExitedEventHandler();
		[Export] public State CurrentState{get; protected set;}
		public State PreviousState{get; protected set;}
		public List<State> States{get; protected set;} = new();
		protected bool IsInitialized {get; set;}
		public override void _Ready(){
			int _id = 0;
			foreach (State target in GetChildren().OfType<State>()){
				this.States.Add(target);
				target.ID = _id++;
				}
			this.Init();
			}
		protected void Init(){
			IsInitialized = true;
				foreach (State selected in States){
					this.StateEntered += selected._EnteredMachine;
					selected.StateRunning += this.CheckingCondition;
					this.StateExited += selected._ExitState;
					}
			this.SelectState();
			PreviousState = CurrentState;
			}
		protected void SelectState(){
			if (!this.IsInitialized){
				return;
				}
			foreach (State selected in States){
				if (selected.Condition){
					this.CurrentState = selected;
					this.EmitSignal(SignalName.StateEntered);
					return;
					}
					}
			}
		protected void CheckingCondition(){
			if (this.IsInitialized && !CurrentState.Condition){
				PreviousState = CurrentState;
					this.EmitSignal(SignalName.StateExited);
					this.SelectState();
				}
			}
		}
	}
