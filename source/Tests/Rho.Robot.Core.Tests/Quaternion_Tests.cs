using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace Rho.Robot.Core.Tests
{
    public class Quaternion_Tests
    {
        [Fact]
        public void To_From_AxisAngle_X_Axis()
        {
            var q = Quaternion.FromAxisAngle(new AxisAngle { Axis = Vector3.UnitX, Angle = Angle.FromDegrees(90) });

            var a = q.ToAxisAngle();

            Assert.True(Math.Abs(a.Angle.RawDegrees - 90.0) < 0.001);
            Assert.True(Math.Abs(a.Axis.X - 1.0) < 0.001);
            Assert.True(Math.Abs(a.Axis.Y - 0.0) < 0.001);
            Assert.True(Math.Abs(a.Axis.Z - 0.0) < 0.001);
        }

        [Fact]
        public void To_From_AxisAngle_Y_Axis()
        {
            var q = Quaternion.FromAxisAngle(new AxisAngle { Axis = Vector3.UnitY, Angle = Angle.FromDegrees(180) });

            var a = q.ToAxisAngle();

            Assert.True(Math.Abs(a.Angle.RawDegrees - 180.0) < 0.001);
            Assert.True(Math.Abs(a.Axis.X - 0.0) < 0.001);
            Assert.True(Math.Abs(a.Axis.Y - 1.0) < 0.001);
            Assert.True(Math.Abs(a.Axis.Z - 0.0) < 0.001);
        }

        [Fact]
        public void To_From_AxisAngle_Z_Axis()
        {
            var q = Quaternion.FromAxisAngle(new AxisAngle { Axis = Vector3.UnitZ, Angle = Angle.FromDegrees(-90) });

            var a = q.ToAxisAngle();

            Assert.True(Math.Abs(a.Angle.RawDegrees - 90.0) < 0.001);
            Assert.True(Math.Abs(a.Axis.X - 0.0) < 0.001);
            Assert.True(Math.Abs(a.Axis.Y - 0.0) < 0.001);
            Assert.True(Math.Abs(a.Axis.Z + 1.0) < 0.001);
        }

        [Fact]
        public void To_From_AxisAngle_Multi_Axis()
        {
            var q = Quaternion.FromAxisAngle(new AxisAngle { Axis = new Vector3 { X = 1, Y = 1, Z = 1 }, Angle = Angle.FromDegrees(30) });

            var a = q.ToAxisAngle();

            Assert.True(Math.Abs(a.Angle.RawDegrees - 30.0) < 0.001);
            Assert.True(Math.Abs(a.Axis.X - MathHelper.Sqrt(1.0 / 3)) < 0.001);
            Assert.True(Math.Abs(a.Axis.Y - MathHelper.Sqrt(1.0 / 3)) < 0.001);
            Assert.True(Math.Abs(a.Axis.Z - MathHelper.Sqrt(1.0 / 3)) < 0.001);
        }

        [Fact]
        public void Multiplication_Works()
        {
            var q1 = Quaternion.FromAxisAngle(new AxisAngle { Axis = Vector3.UnitX, Angle = Angle.FromDegrees(180) });
            var q2 = Quaternion.FromAxisAngle(new AxisAngle { Axis = Vector3.UnitY, Angle = Angle.FromDegrees(180) });

            var q3 = q1 * q2;

            var a = q3.ToAxisAngle();

            Assert.True(Math.Abs(a.Angle.RawDegrees - 180.0) < 0.001);
            Assert.True(Math.Abs(a.Axis.X - MathHelper.Sqrt(0.0 / 3)) < 0.001);
            Assert.True(Math.Abs(a.Axis.Y - MathHelper.Sqrt(0.0 / 3)) < 0.001);
            Assert.True(Math.Abs(a.Axis.Z - MathHelper.Sqrt(1.0 / 3)) < 0.001);
        }
    }
}
