using Godot;
using System.Collections.Generic;

namespace Component.StateMachine{
	public partial class StateMachine : Node{
		public ControllableState Current{get; set;}
		protected List<State> States = new List<State>();
		private bool Initialized = false;
		public override void _Ready(){
			Init();
			SelectState();
			}
		public override void _PhysicsProcess(double delta){
			GD.Print(Current.Name);
			}
		protected void Init(){
			foreach (State selectedState in GetChildren(false)){
				States.Add(selectedState);
				selectedState.EnteredMachine();
				}
			Initialized = true;
			foreach (ControllableState selected in States){
				selected.StateRunning += SetStateUpdate;
				selected.StateExited += SelectState;
				}
			}
		protected void SelectState(){
			if (!Initialized){
				return;
				}
			foreach (ControllableState selected in States){
				if (selected.Condition){
					Current = selected;
					return;
					}
				}
			}
		private void SetStateUpdate(){
			if (!Current.Condition){
				Current.ExitState();
				}
			}
		public float getCurrentSpeed(){
			float targetSpeed = 0;
				foreach (ControllableState i in States){
					if (i.Speed > 0){
						targetSpeed = i.Speed;
						break;
						}
					}
				if (Current.Speed > 0){
					targetSpeed = Current.Speed;
					}
			return targetSpeed;
			}
		}
	}
