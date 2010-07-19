using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace Rho.Robot.Core.Tests
{
    public static class TestExtensions
    {
        public static double SigFig(this double d, int fig)
        {
            return Math.Round(d * MathHelper.Pow(10, fig)) / MathHelper.Pow(10, fig);
        }

        public static Vector3 SigFig(this Vector3 v, int fig)
        {
            return new Vector3 { X = v.X.SigFig(fig), Y = v.Y.SigFig(fig), Z = v.Z.SigFig(fig) };
        }
    }
}
