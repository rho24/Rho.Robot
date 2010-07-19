using System;

namespace Rho.Robot.Core
{
    public class AxisAngle
    {
        public Vector3 Axis { get; set; }
        public Angle Angle { get; set; }

        public override string ToString()
        {
            return "Angle: " + Angle.ToString() + " Axis: " + Axis.X + "," + Axis.Y + "," + Axis.Z;
        }

        public static AxisAngle operator *(AxisAngle a, double d)
        {
            return new AxisAngle { Axis = a.Axis, Angle = a.Angle * d };
        }
    }
}
