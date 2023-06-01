using Godot;

namespace Component.DamageSystem;
    public partial class Hitbox : Node{
        [Signal] delegate void AttackHittedEventHandler();
        [Export] public Area2D AttackZone{get; set;}
        public virtual void DoAttack(){

            }
        }