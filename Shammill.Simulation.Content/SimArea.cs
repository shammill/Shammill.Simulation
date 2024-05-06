using Shammill.Simulation.Components.Base;
using System;
using System.Collections.Generic;
using System.Numerics;
using System.Xml.Linq;

namespace Shammill.Simulation.Content
{
    public class SimArea
    {
        public String Name { get; set; }
        public List<SimulationObject> objects = new List<SimulationObject>();
        public SimArea()
        {
            //TODO construct from location files instead of hardcode
            Name = "First Area";

            //objects.Add(new Asteroid(1, Vector3.Zero, Vector3.Zero, Vector3.Zero, Quaternion.Identity, 1f));
            //objects.Add(new Asteroid(2, Vector3.One, new Vector3(0f, 1f, 0f), Vector3.Zero, Quaternion.Identity, 1f));
            objects.Add(new Asteroid(Guid.NewGuid(), new Transform(Vector3.One, Vector3.Zero, Vector3.Zero, new Quaternion(0, 0.707f, 0, 0.707f), 1f)));

        }
    }
}
