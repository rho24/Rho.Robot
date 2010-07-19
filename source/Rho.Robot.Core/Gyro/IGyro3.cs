using System;
using Microsoft.SPOT;

namespace Rho.Robot.Core.Gyro
{
    public interface IGyro3
    {
        void Calibrate();
        AxisAngle GetAngularRate();
    }
}
