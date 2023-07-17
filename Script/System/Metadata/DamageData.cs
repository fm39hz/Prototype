using System.Collections.Generic;
using Component.DamageSystem;
using Godot;

namespace Metadata.Instance;
    public abstract partial class DamageData : Node{
        [Export] public double Value { get; set; }
        public List<Effect> EffectsValue { get; set; } = new();
        }
