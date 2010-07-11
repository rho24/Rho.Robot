using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;
using Rho.Robot.Core;

namespace Rho.Robot.Core.Tests
{
    public class Angle_Tests
    {
        [Fact]
        public void Default_Should_Be_Zero()
        {
            Angle ang = default(Angle);

            Assert.Equal(Angle.Zero, ang);
            Assert.Equal(0.0, ang.Degrees);
            Assert.Equal(0.0, ang.Radians);
            Assert.Equal(0.0, ang.RawDegrees);
            Assert.Equal(0.0, ang.RawRadians);
        }

        [Fact]
        public void Degrees_And_Radians_Should_Be_Consistent()
        {
            Angle A0 = Angle.FromDegrees(0);

            Assert.Equal(0, A0.RawDegrees);
            Assert.Equal(0, A0.RawRadians);

            Angle A90 = Angle.FromDegrees(90);

            Assert.Equal(90.0, A90.RawDegrees);
            Assert.Equal(Math.PI / 2, A90.RawRadians);

            Angle A180 = Angle.FromDegrees(180);

            Assert.Equal(180.0, A180.RawDegrees);
            Assert.Equal(Math.PI, A180.RawRadians);

            Angle A270 = Angle.FromDegrees(270);

            Assert.Equal(270.0, A270.RawDegrees);
            Assert.Equal(Math.PI * 3 / 2, A270.RawRadians);

            Angle A360 = Angle.FromDegrees(360);

            Assert.Equal(360.0, A360.RawDegrees);
            Assert.Equal(2 * Math.PI, A360.RawRadians);
        }

        [Fact]
        public void Angles_Wrap_Around_Correctly()
        {
            Angle A_270 = Angle.FromDegrees(-270);

            Assert.Equal(90.0, A_270.Degrees);

            Angle A_360 = Angle.FromDegrees(-360);

            Assert.Equal(0, A_360.Degrees);

            Angle A270 = Angle.FromDegrees(270);

            Assert.Equal(-90.0, A270.Degrees);

            Angle A360 = Angle.FromDegrees(360);

            Assert.Equal(0, A360.Degrees);
        }

        [Fact]
        public void Adding_Works()
        {
            var a1 = Angle.FromDegrees(60);
            var a2 = Angle.FromDegrees(120);

            var a3 = a1 + a2;

            Assert.Equal(180.0, a3.Degrees);
        }

        [Fact]
        public void Subtracting_Works()
        {
            var a1 = Angle.FromRadians(1.5);
            var a2 = Angle.FromRadians(0.5);

            var a3 = a1 - a2;

            Assert.Equal(1.0, a3.Radians);
        }

        [Fact]
        public void Multiplying_Works()
        {
            var a1 = Angle.FromDegrees(60);

            var a2 = a1 * 3;

            Assert.Equal(180.0, a2.Degrees);
        }

        [Fact]
        public void Dividinging_Works()
        {
            var a1 = Angle.FromRadians(3);

            var a2 = a1 / 3;

            Assert.Equal(1.0, a2.Radians);
        }
    }
}
