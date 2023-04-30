namespace Component.StateMachine;

	public abstract partial class StateMachine : Node{
		[Export]
			public ControllableState Current{get; set;}
		public List<State> States = new List<State>();
		private bool Initialized = false;
		public override void _Ready(){
			Init();
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
		public void SelectState(){
			if (Initialized){
				foreach (ControllableState selected in States){
					if (selected.Condition){
						Current = selected;
						return;
						}
					}
				}
			}
		private void SetStateUpdate(){
			if (Initialized && !Current.Condition){
				Current.ExitState();
				}
			}
		public float GetCurrentSpeed(){
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
	
