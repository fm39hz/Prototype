using Godot;
using System.Collections.Generic;
using System.Linq;

namespace Component.FiniteStateMachine;
	public abstract partial class StateMachine : Node{
		[Signal] public delegate void StateEnteredEventHandler();
		[Signal] public delegate void StateExitedEventHandler();
		[Export] public State CurrentState { get; protected set; }
		public State PreviousState { get; protected set; }
		public List<State> States { get; protected set; }
		protected bool IsInitialized { get; set; }
		public override void _Ready(){
			var _id = 0;
			this.States = new();
			foreach (var target in GetChildren().OfType<State>()){
				this.States.Add(target);
				target.ID = _id++;
				}
			this.Init();
			}
		protected void Init(){
			this.IsInitialized = true;
				foreach (var selected in States){
					this.StateEntered += selected.EnteredMachine;
					selected.StateRunning += this.CheckingCondition;
					this.StateExited += selected.ExitState;
					}
			this.SelectState();
			this.PreviousState = this.CurrentState;
			}
		protected void SelectState(){
			if (!this.IsInitialized){
				return;
				}
			foreach (var selected in States){
				if (selected.Condition){
					this.CurrentState = selected;
					this.EmitSignal(SignalName.StateEntered);
					return;
					}
					}
			}
		protected void CheckingCondition(){
			if (this.IsInitialized && !CurrentState.Condition){
				this.PreviousState = this.CurrentState;
					this.EmitSignal(SignalName.StateExited);
					this.SelectState();
				}
			}
		}
