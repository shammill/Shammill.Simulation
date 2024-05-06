using System;
using System.Numerics;

namespace Shammill.Simulation.Components.Base
{
    public abstract class SimulationObject
    {
        public Guid Id;
        public Transform Transform;

        protected SimulationObject(Guid id, Transform transform)
        {
            Id = id;
            Transform = transform;
        }

        public virtual void Update(float deltaTime)
        {
            Transform.Update(deltaTime);
        }
    }
}