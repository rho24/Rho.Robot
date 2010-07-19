using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace Rho.Robot.Core.Tests
{
    public class Quaternion_Tests
    {
#if MICRO
        [Fact(Skip = "Contains hardware maths.")]
#else
        [Fact]
#endif
        public void To_From_AxisAngle_X_Axis()
        {
            var q = Quaternion.FromAxisAngle(new AxisAngle { Axis = Vector3.UnitX, Angle = Angle.FromDegrees(90) });

            var a = q.ToAxisAngle();

            Assert.Equal(90, a.Angle.RawDegrees.SigFig(3));
            Assert.Equal(Vector3.UnitX, a.Axis.SigFig(3));
        }

#if MICRO
        [Fact(Skip = "Contains hardware maths.")]
#else
        [Fact]
#endif
        public void To_From_AxisAngle_Y_Axis()
        {
            var q = Quaternion.FromAxisAngle(new AxisAngle { Axis = Vector3.UnitY, Angle = Angle.FromDegrees(180) });

            var a = q.ToAxisAngle();

            Assert.Equal(180, a.Angle.RawDegrees.SigFig(3));
            Assert.Equal(Vector3.UnitY, a.Axis.SigFig(3));
        }

#if MICRO
        [Fact(Skip = "Contains hardware maths.")]
#else
        [Fact]
#endif
        public void To_From_AxisAngle_Z_Axis()
        {
            var q = Quaternion.FromAxisAngle(new AxisAngle { Axis = Vector3.UnitZ, Angle = Angle.FromDegrees(-90) });

            var a = q.ToAxisAngle();

            Assert.Equal(90, a.Angle.RawDegrees.SigFig(3));
            Assert.Equal(new Vector3(0,0,-1), a.Axis.SigFig(3));
        }

#if MICRO
        [Fact(Skip = "Contains hardware maths.")]
#else
        [Fact]
#endif
        public void To_From_AxisAngle_Multi_Axis()
        {
            var q = Quaternion.FromAxisAngle(new AxisAngle { Axis = new Vector3 { X = 1, Y = 1, Z = 1 }, Angle = Angle.FromDegrees(30) });

            var a = q.ToAxisAngle();

            Assert.Equal(30, a.Angle.RawDegrees.SigFig(3));
            Assert.Equal(new Vector3(1, 1, 1).Normal.SigFig(3), a.Axis.SigFig(3));
        }

#if MICRO
        [Fact(Skip = "Contains hardware maths.")]
#else
        [Fact]
#endif
        public void Multiplication_Works()
        {
            var q1 = Quaternion.FromAxisAngle(new AxisAngle { Axis = Vector3.UnitX, Angle = Angle.FromDegrees(180) });
            var q2 = Quaternion.FromAxisAngle(new AxisAngle { Axis = Vector3.UnitY, Angle = Angle.FromDegrees(180) });

            var q3 = q1 * q2;

            var a = q3.ToAxisAngle();

            Assert.Equal(180, a.Angle.RawDegrees.SigFig(3));
            Assert.Equal(Vector3.UnitZ, a.Axis.SigFig(3));
        }

#if MICRO
        [Fact(Skip = "Contains hardware maths.")]
#else
        [Fact]
#endif
        public void Small_Changes_Single_Axis()
        {
            var q1 = Quaternion.FromAxisAngle(new AxisAngle { Axis = Vector3.UnitX, Angle = Angle.FromDegrees(0.1) });

            var q2 = new Quaternion();

            for (var i = 0; i < 2700; i++)
            {
                q2 *= q1;
            }

            var a = q2.ToAxisAngle();

            Assert.Equal(270, a.Angle.RawDegrees.SigFig(3));
            Assert.Equal(Vector3.UnitX, a.Axis.SigFig(3));
        }

#if MICRO
        [Fact(Skip = "Contains hardware maths.")]
#else
        [Fact]
#endif
        public void Small_Changes_Two_Axis()
        {
            var q1 = Quaternion.FromAxisAngle(new AxisAngle { Axis = Vector3.UnitX, Angle = Angle.FromDegrees(0.1) });
            var q2 = Quaternion.FromAxisAngle(new AxisAngle { Axis = Vector3.UnitY, Angle = Angle.FromDegrees(0.1) });

            var q3 = new Quaternion();

            for (var i = 0; i < 2700; i++)
            {
                q3 *= q1;
                q3 *= q2;
            }

            var a = q3.ToAxisAngle();

            Assert.Equal(90, a.Angle.RawDegrees.SigFig(3));
            Assert.Equal(Vector3.UnitX, a.Axis.SigFig(3));
        }
    }
}
