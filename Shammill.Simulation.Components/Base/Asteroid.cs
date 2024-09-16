using MessagePack;
using System;
using System.Numerics;

namespace Shammill.Simulation.Components.Base
{
    [MessagePackObject(keyAsPropertyName: true)]
    public class Asteroid : SimulationObject
    {
        public Asteroid(Guid id, Transform transform) : base(id, transform)
        {
            // todo
            // type
            // loot behaviour
            // yield/remaining.

        }
    }
}
