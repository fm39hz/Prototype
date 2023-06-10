using Component.DamageSystem;
using Godot;

namespace Component.Object.Equipment;
    public abstract partial class Weapon : DynamicObject{
        [Export] public Area2D Hitbox{get; set;}
        public DamageType Type{get; set;}

        }
