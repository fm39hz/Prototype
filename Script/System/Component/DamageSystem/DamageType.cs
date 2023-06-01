using System.Collections.Generic;
using Godot;

namespace Component.DamageSystem;
    public abstract class DamageType{
        [Export] public double Value{get; set;}
        public List<Effect> Type{get; set;} = new();
        }