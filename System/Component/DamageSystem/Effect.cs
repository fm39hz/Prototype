using Godot;

namespace Component.DamageSystem;
    public abstract partial class Effect : Node{
        [Signal] public delegate void EffectAppliedEventHandler();
        [Signal] public delegate void EffectDiscardedEventHandler();
        public virtual void Apply(){
            EmitSignal(SignalName.EffectApplied);
            }
        public virtual void Discard(){
            EmitSignal(SignalName.EffectDiscarded);
            }
        }
