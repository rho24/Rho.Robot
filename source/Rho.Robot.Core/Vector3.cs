using System;

namespace Rho.Robot.Core
{
    public struct Vector3
    {
        public double X;
        public double Y;
        public double Z;

        public double Length
        {
            get
            {
                return Math.Pow(Math.Pow(X, 2) + Math.Pow(Y, 2) + Math.Pow(Z, 2), 0.5);
            }
        }

        public Vector3 Normal()
        {
            var length = this.Length;
            if (length == 0.0)
                return new Vector3();

            return this / length;
        }

        public override string ToString()
        {
            return X + "," + Y + "," + Z;
        }

        public static Vector3 operator +(Vector3 v1, Vector3 v2)
        {
            return new Vector3
            {
                X = v1.X + v2.X,
                Y = v1.Y + v2.Y,
                Z = v1.Z + v2.Z
            };
        }

        public static Vector3 operator -(Vector3 v1, Vector3 v2)
        {
            return new Vector3
            {
                X = v1.X - v2.X,
                Y = v1.Y - v2.Y,
                Z = v1.Z - v2.Z
            };
        }

        public static Vector3 operator *(Vector3 v1, Vector3 v2)
        {
            return new Vector3
            {
                X = v1.X + v2.X,
                Y = v1.Y + v2.Y,
                Z = v1.Z + v2.Z
            };
        }

        public static Vector3 operator *(Vector3 v, double d)
        {
            return new Vector3
            {
                X = v.X * d,
                Y = v.Y * d,
                Z = v.Z * d
            };
        }

        public static Vector3 operator *(double d, Vector3 v)
        {
            return v * d;
        }

        public static Vector3 operator /(Vector3 v, double d)
        {
            return new Vector3
            {
                X = v.X / d,
                Y = v.Y / d,
                Z = v.Z / d
            };
        }
    }
}
