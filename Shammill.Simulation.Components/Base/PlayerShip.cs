using MessagePack;
using Shammill.Simulation.Components.Behaviours;
using System;
using System.Collections.Generic;
using System.Numerics;

namespace Shammill.Simulation.Components.Base
{
    [MessagePackObject(keyAsPropertyName: true)] // TODO remove this, and have explicit keys (performance)
    public class PlayerShip : SimulationObject
    {
        //public DamagableBehavior DamagableBehavior;

        //public Guid Id;
        public Guid UserId;

        public int Health; // todo, this will be much more complex later (struct, hull, shields?)
        public bool IsDead;
        public bool IsDisabled;

        public List<Equipment> Equipment;

        public PlayerShip(Guid id, Guid userId, Transform transform) : base(id, transform)
        {
           // Id = id;
            UserId = userId;
            Health = 100;
        }

        public void CalculateDamage() 
        {
            // TODO pass in maybe weapon type, ship will have resitances, armour, etc.
        }

        public void TakeDamage(int damage)
        {
            Health = Health - damage;
            if (Health <= 0)
            {
                IsDead = true; // TODO death event. Maybe handled in loop.
            }
        }


        public override void Update(float deltaTime)
        {
            // todo damage & related effects
            base.Update(deltaTime);
        }
    }
}
