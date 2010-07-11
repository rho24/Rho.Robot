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

            Assert.Equal(0.0, ang.Degrees);
            Assert.Equal(0.0, ang.Radians);
            Assert.Equal(0.0, ang.RawDegrees);
            Assert.Equal(0.0, ang.RawRadians);
        }
    }
}
