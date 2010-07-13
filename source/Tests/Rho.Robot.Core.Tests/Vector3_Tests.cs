using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace Rho.Robot.Core.Tests
{
    public class Vector3_Tests
    {
        [Fact]
        public void Default_Is_Zero()
        {
            var v = default(Vector3);

            Assert.Equal(0, v.X);
            Assert.Equal(0, v.Y);
            Assert.Equal(0, v.Z);
        }

        [Fact]
        public void Length_Is_Correct()
        {
            var v = new Vector3 { X = 3, Y = 4, Z = 0 };

            Assert.Equal(5.0, v.Length);
        }

        [Fact]
        public void Normal_Is_Correct()
        {
            var v = new Vector3 { X = 5, Y = 5, Z = 5 };

            var root1Over3 = MathHelper.Sqrt(1.0 / 3);

            Assert.Equal(new Vector3 { X = root1Over3, Y = root1Over3, Z = root1Over3 }, v.Normal);
        }

        [Fact]
        public void Adding_Works()
        {
            var v1 = new Vector3 { X = 3, Y = 5, Z = 2 };
            var v2 = new Vector3 { X = 1, Y = 1, Z = 1 };

            var v3 = v1 + v2;

            Assert.Equal(4, v3.X);
            Assert.Equal(6, v3.Y);
            Assert.Equal(3, v3.Z);
        }

        [Fact]
        public void Subtracting_Works()
        {
            var v1 = new Vector3 { X = 3, Y = 5, Z = 2 };
            var v2 = new Vector3 { X = 1, Y = 1, Z = 1 };

            var v3 = v1 - v2;

            Assert.Equal(2, v3.X);
            Assert.Equal(4, v3.Y);
            Assert.Equal(1, v3.Z);
        }

        [Fact]
        public void Multiplying_Works()
        {
            var v1 = new Vector3 { X = 3, Y = 5, Z = 2 };

            var v2 = v1 * 3;

            Assert.Equal(9, v2.X);
            Assert.Equal(15, v2.Y);
            Assert.Equal(6, v2.Z);
        }

        [Fact]
        public void Dividing_Works()
        {
            var v1 = new Vector3 { X = 3, Y = 5, Z = 2 };

            var v2 = v1 / 2;

            Assert.Equal(1.5, v2.X);
            Assert.Equal(2.5, v2.Y);
            Assert.Equal(1, v2.Z);
        }
    }
}
