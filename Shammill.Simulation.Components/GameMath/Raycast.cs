using System;
using System.Numerics;

namespace Shammill.Simulation.Components.GameMath
{
    public class Raycast
    {
        public Vector3 Position;
        public Vector3 Direction; // normalised - between 0 and 1

        public Raycast(Vector3 position, Vector3 direction)
        {
            this.Position = position;
            this.Direction = direction;
        }

        private bool RayIsParallel(float normalisedAxisPoint)
        {
            return Math.Abs(normalisedAxisPoint) < Constants.PracticallyZero; // ray is not moving on the axis
        }

        private bool IsOutsideOf(float axisPosition, float axisMin, float axisMax)
        {
            return (axisPosition < axisMin || axisPosition > axisMax);
        }

        // Check if the raycast is outside the bounds of the three slabs that make a box.
        // A slab being a space between two parallel planes. A box has 3 such slabs.
        // If all 3 checks pass, the ray intersects.
        public bool Intersects(BoundingBox box)
        {
            var ray = this;
            var distance = 0f;
            float maxDistance = float.MaxValue;

            if (RayIsParallel(ray.Direction.X) && IsOutsideOf(ray.Position.X, box.Minimum.X, box.Maximum.X))
            {
                return false;
            }
            else
            {
                float ood = 1.0f / ray.Direction.X;
                float nearPlane = (box.Minimum.X - ray.Position.X) * ood;
                float farPlane = (box.Maximum.X - ray.Position.X) * ood;

                if (nearPlane > farPlane)
                {
                    distance = Math.Max(farPlane, distance);
                    maxDistance = Math.Min(nearPlane, maxDistance);
                }
                else
                {
                    distance = Math.Max(nearPlane, distance);
                    maxDistance = Math.Min(farPlane, maxDistance);
                }

                if (distance > maxDistance)
                {
                    return false;
                }
            }

            if (RayIsParallel(ray.Direction.Y) && IsOutsideOf(ray.Position.Y, box.Minimum.Y, box.Maximum.Y))
            {
                return false;
            }
            else
            {
                float ood = 1.0f / ray.Direction.Y;
                float nearPlane = (box.Minimum.Y - ray.Position.Y) * ood;
                float farPlane = (box.Maximum.Y - ray.Position.Y) * ood;

                if (nearPlane > farPlane)
                {
                    distance = Math.Max(farPlane, distance);
                    maxDistance = Math.Min(nearPlane, maxDistance);
                }
                else { 
                    distance = Math.Max(nearPlane, distance);
                    maxDistance = Math.Min(farPlane, maxDistance);
                }

                if (distance > maxDistance)
                {
                    return false;
                }
            }

            if (RayIsParallel(ray.Direction.Z) && IsOutsideOf(ray.Position.Z, box.Minimum.Z, box.Maximum.Z))
            {
                return false;
            }
            else
            {
                float ood = 1.0f / ray.Direction.Z;
                float nearPlane = (box.Minimum.Z - ray.Position.Z) * ood;
                float farPlane = (box.Maximum.Z - ray.Position.Z) * ood;

                if (nearPlane > farPlane)
                {
                    distance = Math.Max(farPlane, distance);
                    maxDistance = Math.Min(nearPlane, maxDistance);
                }
                else
                {
                    distance = Math.Max(nearPlane, distance);
                    maxDistance = Math.Min(farPlane, maxDistance);
                }

                if (distance > maxDistance)
                {
                    return false;
                }
            }

            Vector3 intersectionPoint = ray.Position + ray.Direction * distance;
            return true;
        }
    }
}
