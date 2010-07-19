using System;
using System.Text;
using System.IO.Ports;
using Microsoft.SPOT;

namespace Rho.Robot.Core
{
#if MICRO
    public class PcInterface
    {

        private SerialPort Port { get; set; }

        public PcInterface()
        {
            Port = new SerialPort("COM1", 115200);
            Port.ReadTimeout = 100;
            Port.WriteTimeout = 100;

            Port.Open();
        }

        public void Send(AxisAngle worldRotation)
        {
            var temp = "O," + worldRotation.Angle.Degrees.ToString() + "," + worldRotation.Axis.X.ToString() + "," + worldRotation.Axis.Y.ToString() + "," + worldRotation.Axis.Z.ToString() + "\r\n";
            var buffer = Encoding.UTF8.GetBytes(temp);

            Port.Write(buffer, 0, buffer.Length);

        }

        public void Send(Vector3 v)
        {
            var temp = "V," + v.X.ToString() + "," + v.Y.ToString() + "," + v.Z.ToString() + "\r\n";
            var buffer = Encoding.UTF8.GetBytes(temp);

            Port.Write(buffer, 0, buffer.Length);
        }
    }
#endif
}
