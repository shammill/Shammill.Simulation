using Shammill.Simulation.Components.Base;
using System;
using System.Numerics;

namespace Shammill.Simulation.Components
{
    public class SimulationAction
    {
        public Guid ActorId { get; set; }
        public Guid SubjectId { get; set; }
        public ActionType Type { get; set; }
        public int Gear { get; set; }
        public Transform Transform { get; set; }

    }

    public enum ActionType
    {
        None,
        Movement,
        Item,

        /// id, null, Movement, null , Position // move to place
        /// id, null, Item, 1 , Position // use item at place
        /// id, idenemy, Item, 2 , null // use missile on enemy
        /// id, null, Item, 3 , Position// use gun at enemy location
    }
}




// COMBAT
// me, them, shoot, laser


// WORLD
// me, station, dock, null
// me, asteroid, mine, mining laser
// me, jumpgate, dock, null
// me, wreck, salvage, salvager,
// me, container, use, null

//equipment
// me, null, equipment, drone
// me, null, equipment, mine


// movement?
// me, null, move, null, location
// me, null, move, null, location
// me, null, move, null, location

// ALTERNATIVE - more physics based
// me, shoot, location
// me, shoot, 1, location
// me, move, location,
// me, equipment, 1, location
// me, shoot, 5, target, // missile


