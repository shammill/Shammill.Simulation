using System;
using System.Numerics;

namespace Shammill.Simulation.Components.GameMath
{
    public class BoundingBox
    {
        public Vector3 Minimum;
        public Vector3 Maximum;

        public BoundingBox(Vector3 minimum, Vector3 maximum) {
            this.Minimum = minimum;
            this.Maximum = maximum;
        }

        public static BoundingBox FromPoints(Vector3[] points)
        {
            if (points == null)
                throw new ArgumentNullException("points");

            Vector3 min = new Vector3(float.MaxValue);
            Vector3 max = new Vector3(float.MinValue);

            for (int i = 0; i < points.Length; ++i)
            {
                // todo get min and max
            }

            return new BoundingBox(min, max);
        }

        public Vector3 Center
        {
            get { return (Minimum + Maximum) * 0.5f; }
        }
    }
}
