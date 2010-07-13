using System;

namespace Rho.Robot.Core
{
    public class Rotation3D
    {
        public Angle X;
        public Angle Y;
        public Angle Z;

        public double Length
        {
            get
            {
                return MathHelper.Sqrt(MathHelper.Pow(X.RawRadians, 2) + MathHelper.Pow(Y.RawRadians, 2) + MathHelper.Pow(Z.RawRadians, 2));
            }
        }

        public Vector3 Normal
        {
            get
            {
                var length = this.Length;
                if (length == 0.0)
                    return new Vector3();

                return new Vector3 { X = this.X.RawRadians / length, Y = this.Y.RawRadians / length, Z = this.Z.RawRadians / length };
            }
        }

        public override string ToString()
        {
            return X + "," + Y + "," + Z;
        }

        public static Rotation3D operator +(Rotation3D aa1, Rotation3D aa2)
        {
            return new Rotation3D
            {
                X = aa1.X + aa2.X,
                Y = aa1.Y + aa2.Y,
                Z = aa1.Z + aa2.Z
            };
        }

        public static Rotation3D operator -(Rotation3D aa1, Rotation3D aa2)
        {
            return new Rotation3D
            {
                X = aa1.X - aa2.X,
                Y = aa1.Y - aa2.Y,
                Z = aa1.Z - aa2.Z
            };
        }

        public static Rotation3D operator *(Rotation3D a, double d)
        {
            return new Rotation3D
            {
                X = a.X * d,
                Y = a.Y * d,
                Z = a.Z * d
            };
        }

        public static Rotation3D operator *(double d, Rotation3D a)
        {
            return a * d;
        }

        public static Rotation3D operator /(Rotation3D a, double d)
        {
            return new Rotation3D
            {
                X = a.X / d,
                Y = a.Y / d,
                Z = a.Z / d
            };
        }
    }
}
