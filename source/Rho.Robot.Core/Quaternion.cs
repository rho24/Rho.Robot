using System;


namespace Rho.Robot.Core
{
    public class Quaternion
    {
        public double W { get; private set; }
        public double X { get; private set; }
        public double Y { get; private set; }
        public double Z { get; private set; }

        public Quaternion()
        {
            W = 1;
            X = Y = Z = 0;
        }

        public Quaternion(double w, double x, double y, double z)
        {
            W = w;
            X = x;
            Y = y;
            Z = z;

            this.Normalize();
        }

        //public Quaternion(Rotation3D a)
        //{
        //    var halfAngle = a.Length() / 2;
        //    var sinAngle = MathEx.Sin(halfAngle);

        //    var normal = a.Normal();

        //    W = MathEx.Cos(halfAngle);
        //    X = normal.X * sinAngle;
        //    Y = normal.Y * sinAngle;
        //    Z = normal.Z * sinAngle;
        //}

        public static Quaternion FromAxisAngle(AxisAngle a)
        {
            var halfAngle = a.Angle.RawRadians / 2;
            var sinAngle = MathHelper.Sin(halfAngle);

            var normal = a.Axis.Normal;

            return new Quaternion(
                MathHelper.Cos(halfAngle),
                normal.X * sinAngle,
                normal.Y * sinAngle,
                normal.Z * sinAngle);
        }

        public Quaternion Normalize()
        {
            var mag2 = Math.Pow(W, 2) + Math.Pow(X, 2) + Math.Pow(Y, 2) + Math.Pow(Z, 2);

            if (mag2 != 0.0 && mag2 != 1.0)
            {
                var mag = Math.Pow(mag2, 0.5);

                return new Quaternion(this.W / mag, this.X / mag, this.Y / mag, this.Z / mag);
            }
            else
            {
                return new Quaternion { W = this.W, X = this.X, Y = this.Y, Z = this.Z };
            }
        }

        public Quaternion Conjugate()
        {
            return new Quaternion { W = this.W, X = -this.X, Y = -this.Y, Z = -this.Z };
        }

        public static Quaternion operator *(Quaternion q1, Quaternion q2)
        {
            var q = new Quaternion
            {
                W = q1.W * q2.W - q1.X * q2.X - q1.Y * q2.Y - q1.Z * q2.Z,
                X = q1.W * q2.X + q1.X * q2.W + q1.Y * q2.Z - q1.Z * q2.Y,
                Y = q1.W * q2.Y + q1.Y * q2.W + q1.Z * q2.X - q1.X * q2.Z,
                Z = q1.W * q2.Z + q1.Z * q2.W + q1.X * q2.Y - q1.Y * q2.X
            };

            return q;

        }

        public Vector3 Rotate(Vector3 v)
        {
            var vQuat = new Quaternion
            {
                W = 0.0,
                X = v.X,
                Y = v.Y,
                Z = v.Z
            };

            var resQuat = this * (vQuat * this.Conjugate());

            return new Vector3 { X = resQuat.X, Y = resQuat.Y, Z = resQuat.Z };
        }

        public AxisAngle ToAxisAngle()
        {
            var qNorm = this.Normalize();

            if (qNorm.W == 1)
            {
                return new AxisAngle { Axis = Vector3.Zero, Angle = Angle.Zero };
            }

            var a = Angle.FromRadians(2 * MathHelper.Acos(qNorm.W));

            var v = new Vector3
            {
                X = qNorm.X,
                Y = qNorm.Y,
                Z = qNorm.Z
            }.Normal;

            return new AxisAngle { Axis = v, Angle = a };
        }

    }
}
