using System;

#if MICRO
using GHIElectronics.NETMF.System;
#endif

namespace Rho.Robot.Core
{
    public static class MathHelper
    {
        public static double Pow(double x, double y)
        {
#if MICRO
            return MathEx.Pow(x, y);
#else
            return Math.Pow(x,y);
#endif
        }

        public static double Sqrt(double d)
        {
#if MICRO
            return MathEx.Sqrt(d);
#else
            return Math.Pow(d,0.5);
#endif
        }

        public static double Sin(double d)
        {
#if MICRO
            return MathEx.Sin(d);
#else
            return Math.Sin(d);
#endif
        }

        public static double Cos(double d)
        {
#if MICRO
            return MathEx.Cos(d);
#else
            return Math.Cos(d);
#endif
        }

        public static double Acos(double d)
        {
#if MICRO
            return MathEx.Acos(d);
#else
            return Math.Acos(d);
#endif
        }

        public static double SigFig(double d, int fig)
        {
            return Math.Round(d * MathHelper.Pow(10, fig)) / MathHelper.Pow(10, fig);
        }
    }
}
