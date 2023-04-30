using Godot;
using System.Collections.Generic;

namespace Component.StateMachine{
	public partial class StateMachine : Node{
		public ControllableState Current{get; set;}
		protected List<State> States = new List<State>();
		private bool Initialized = false;
		public override void _Ready(){
			Init();
			Connect();
			SelectState();
			}
		public override void _PhysicsProcess(double delta){
			Current.RunningState();
			}
		protected void Init(){
			foreach (State selectedState in GetChildren(false)){
				States.Add(selectedState);
				selectedState.Init();
				}
			Initialized = true;
			}
		protected void Connect(){
			if (!Initialized){
				return;
				}
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
				if (selected.Condition == true){
					Current = selected;
						Current.EnterState();
					return;
					}
				}
			}
		private void SetStateUpdate(){
			if (Current.Condition == false){
				Current.ExitState();
				}
			}
		public float getCurrentSpeed(){
			foreach (ControllableState i in States){
				if (i.Speed > 0){
					return i.Speed;
					}
				continue;
				}
			return Current.Speed;
			}
		}
	}
