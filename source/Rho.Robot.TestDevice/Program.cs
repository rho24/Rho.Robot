using System;
using Microsoft.SPOT;
using Rho.Robot.Core;
using Rho.Robot.Core.Gyro;
using System.Threading;

namespace Rho.Robot.TestDevice
{
    public class Program
    {
        public static void Main()
        {
            Debug.Print("Fez!!!");

            var pcInterface = new PcInterface();
            var gyro = new HardwareGyro();

            Thread.Sleep(1500);
            gyro.Calibrate();

            DateTime lastTime = DateTime.Now, currentTime;
            TimeSpan delta;

            Quaternion rotation = new Quaternion();
            AxisAngle angularRate;
            var i = 0;

            while (true)
            {
                try
                {
                    currentTime = DateTime.Now;
                    delta = currentTime - lastTime;
                    lastTime = currentTime;
                    angularRate = gyro.GetAngularRate();

                    var r = angularRate * (delta.Milliseconds / 1000.0);
                    rotation *= Quaternion.FromAxisAngle(r);

                    Debug.Print(rotation.ToAxisAngle().ToString());

                    if ((i++ % 10) == 0)
                    {
                        pcInterface.Send(rotation.ToAxisAngle());
                    }
                }
                catch (Exception ex)
                {
                    Debug.Print("EXCEPTION: " + ex.ToString());
                }
                //Thread.Sleep(25);
            }
        }

    }
}
