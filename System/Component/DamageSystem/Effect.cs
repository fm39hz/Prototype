using Godot;

namespace GameSystem.Component.DamageSystem;
    public partial class Effect : Node{
        [Signal] public delegate void EffectAppliedEventHandler();
        [Signal] public delegate void EffectDiscardedEventHandler();
        public virtual void Apply(){
            EmitSignal(SignalName.EffectApplied);
            }
        public virtual void Discard(){
            EmitSignal(SignalName.EffectDiscarded);
            }
        }
