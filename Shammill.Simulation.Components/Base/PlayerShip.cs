using System;
using System.Numerics;

namespace Shammill.Simulation.Components.Base
{
    public class PlayerShip : SimulationObject
    {
        // todo, this will be much more complex later (struct, hull, shields?)


        Guid Id;
        Guid UserId;

        int Health;
        bool IsDead;
        bool IsDisabled;

        public PlayerShip(Guid id, Guid userId, Transform transform) : base(id, transform)
        {
            Id = id;
            UserId = userId;
        }

        public override void Update(float deltaTime)
        {
            // todo damage & related effects
            base.Update(deltaTime);
        }
    }
}
