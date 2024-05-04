using System;
using System.Numerics;

namespace Shammill.Simulation.Components.Base
{
    public class Asteroid : SimulationObject
    {
        public Asteroid(int id, Vector3 position, Vector3 velocity, Vector3 rotation, Quaternion rotationRate, float size) : base(id, position, velocity, rotation, rotationRate, size)
        {
        }
    }
}
