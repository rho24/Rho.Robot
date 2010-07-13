using System;

namespace Rho.Robot.Core
{
    public struct Angle
    {
        const double TWO_PI =  Math.PI * 2.0;
        const double RAD_TO_DEG = 360 / (2 * Math.PI);
        const double DEG_TO_RAD = (2 * Math.PI) / 360;

        private double _RawRadians;
        public double RawRadians
        {
            get
            {
                return _RawRadians;
            }
        }

        public double RawDegrees
        {
            get
            {
                return RawRadians * RAD_TO_DEG;
            }
        }

        private double _Radians;
        public double Radians
        {
            get
            {
                return _Radians;
            }
        }

        public double Degrees
        {
            get
            {
                return Radians * RAD_TO_DEG;
            }
        }

        private Angle(double radians)
        {
            _RawRadians = radians;
            //_Radians = (((((radians % TWO_PI) + TWO_PI) % TWO_PI) + Math.PI) % TWO_PI) - Math.PI;
            _Radians = (((((radians % TWO_PI) - TWO_PI) % TWO_PI) - Math.PI) % TWO_PI) + Math.PI;
        }

        public override string ToString()
        {
            return RawDegrees.ToString() + " Degrees";
        }

        public static Angle FromRadians(double radians)
        {
            return new Angle(radians);
        }

        public static Angle FromDegrees(double degrees)
        {
            return new Angle(degrees * DEG_TO_RAD);
        }

        public static Angle Zero
        {
            get { return new Angle(); }
        }

        public static Angle operator +(Angle a1, Angle a2)
        {
            return new Angle(a1.RawRadians + a2.RawRadians);
        }

        public static Angle operator -(Angle a1, Angle a2)
        {
            return new Angle(a1.RawRadians - a2.RawRadians);
        }

        public static Angle operator *(Angle a, double d)
        {
            return new Angle(a.RawRadians * d);
        }

        public static Angle operator /(Angle a, double d)
        {
            return new Angle(a.RawRadians / d);
        }
    }
}
