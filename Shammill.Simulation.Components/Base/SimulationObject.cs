using System.Numerics;

namespace Shammill.Simulation.Components.Base
{
    public abstract class SimulationObject
    {
        public int Id;
        // might need double precision Vector3, if so use 3rd party package.
        public Vector3 Position;
        public Vector3 Velocity;
        public Vector3 Rotation;
        public Quaternion RotationRate;

        //public float PositionalInertia;
        //public float RotationalInertia;
        public float Size;

        protected SimulationObject(int id, Vector3 position, Vector3 velocity, Vector3 rotation, Quaternion rotationRate, float size)
        {
            Id = id;
            Position = position;
            Velocity = velocity;
            Size = size;
            Rotation = rotation;
            RotationRate = rotationRate;
        }

        public virtual void Update(float deltaTime)
        {
            Position += Velocity * deltaTime;
            //Rotation = Vector3.Transform(Rotation, RotationRate); // creates a new Vector 3. analyze memory to see if this is a problem, write custom if so.
            //ClampRotationValues();
        }

        private void ClampRotationValues()
        {
            Rotation.X = Rotation.X % 360;
            Rotation.Y = Rotation.Y % 360;
            Rotation.Z = Rotation.Z % 360;
        }
    }
}