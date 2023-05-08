using Godot;
using System;
using Metadata.Object;
using Component.Animation;
using Component.StateMachine;

namespace Game.Object{
    public abstract partial class DynamicObject : CharacterBody2D{
        public bool IsCollided{get; protected set;} = false;
		public SpriteSheet Sheet{get; protected set;}
		public StateMachine ObjectedStateMachine{get; protected set;}
		public DynamicMetadata Metadata{get; protected set;}
		public T GetFirstChildOfType<T>() where T : Node{
			T targetChild = null;
				for (int i = 0; i < this.GetChildCount(); i++){
					if (this.GetChildOrNull<T>(i) != null){
						targetChild = this.GetChild<T>(i);
						}
					}
			return targetChild;
			}
		public T GetFirstSiblingOfType<T>() where T : Node{
			Node parent = this.GetParent();
			T targetSibling = null;
				for (int i = 0; i < parent.GetChildCount(); i++){
					if (parent.GetChildOrNull<T>(i) != null){
						targetSibling = parent.GetChild<T>(i);
						}
					}
			return targetSibling;
			}
		public override void _EnterTree(){
			try{
				this.Sheet = GetFirstChildOfType<SpriteSheet>();
				}
			catch (InvalidCastException e){
				GD.Print(e.Message);
				}
			catch (NullReferenceException e){
				GD.Print(e.Message);
				}
			}
		public override void _Ready(){
			try{
				this.ObjectedStateMachine = GetFirstChildOfType<StateMachine>();
				this.Metadata = new();
				}
			catch (InvalidCastException e){
				GD.Print(e.Message);
				}
			catch (NullReferenceException e){
				GD.Print(e.Message);
				}
			}
		protected static double GetRelativeResponseTime(double delta){
			return 60 * delta;
			}
		protected void UpdateMetaData(){
			var currentState = ObjectedStateMachine.CurrentState.ToDynamic();
				Metadata.StateID = currentState.ID;
				Metadata.IsLoopingAnimation = currentState.IsLoop;
					if (!Velocity.IsEqualApprox(Vector2.Zero)){
						Metadata.SetDirection(Velocity);
						}
			}
        }
    }