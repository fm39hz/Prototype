using System.Collections.Generic;
using Godot;

namespace Component.DamageSystem;
    public partial class Hitbox : Area2D{
        [Signal] public delegate void AttackHittedEventHandler();
        }