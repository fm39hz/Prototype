using System.Collections.Generic;
using Godot;

namespace Component.DamageSystem;
    public abstract partial class DamageData : Node{
        [Export] public double Value{get; set;}
        public List<Effect> Effects{get; set;} = new();
        }
