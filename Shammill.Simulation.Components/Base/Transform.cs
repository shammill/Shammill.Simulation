using System.Numerics;

namespace Shammill.Simulation.Components.Base
{
    public class Transform
    {
        // might need double precision Vector3, if so use 3rd party package (.NET aint there yet.)
        public Vector3 Position;
        public Vector3 Rotation;
        public Vector3 Velocity;
        public Quaternion RotationRate;

        //public float PositionalInertia;
        //public float RotationalInertia;
        public float Size;

        public Transform(Vector3 position, Vector3 velocity, Vector3 rotation, Quaternion rotationRate, float size)
        {
            Position = position;
            Velocity = velocity;
            Size = size;
            Rotation = rotation;
            RotationRate = rotationRate;
        }

        public void Update(float deltaTime)
        {
            Position += Velocity * deltaTime;
            //Rotation = Vector3.Transform(Rotation, RotationRate); // creates a new Vector 3. analyze memory to see if this is a problem, write custom if so (prefer mutate)
            ClampRotationValues();
        }

        private void ClampRotationValues()
        {
            Rotation.X = Rotation.X % 360;
            Rotation.Y = Rotation.Y % 360;
            Rotation.Z = Rotation.Z % 360;
        }
    }
}