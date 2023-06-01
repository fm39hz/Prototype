using Godot;

namespace Component.DamageSystem;
    public interface Effect{
        [Signal] delegate void AppliedEffectEventHandler();
        [Signal] delegate void DiscardedEffectEventHandler();
        public void Apply();
        public void Discard();
        }