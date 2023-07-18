using Component.DamageSystem;
using Data.Instance;
using Godot;

namespace Component.Object.Equipment;
    public abstract partial class Weapon : DynamicObject{
        [Export] public Area2D Hitbox { get; set; }
        public DamageData Damage { get; set; }
        public virtual double DoDamage(){
            return Damage.Value;
            }
        }
