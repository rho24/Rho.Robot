using System;
using Microsoft.SPOT;
using Microsoft.SPOT.Hardware;

namespace Rho.Robot.Core.Gyro
{
    public class HardwareGyro : IGyro3
    {
        public I2CDevice Device { get; private set; }

        const double SCALE = 14.375 * 8;
        public Vector3 avg = new Vector3();

        public HardwareGyro()
        {
            Device = new I2CDevice(new I2CDevice.Configuration(0x69, 400));
        }

        const int CALIBRATION_REPETITIONS = 500;
        public void Calibrate()
        {
            var temp = new Vector3();
            var newAvg = new Vector3();

            avg = new Vector3();
            for (var i = 0; i < CALIBRATION_REPETITIONS; i++)
            {
                temp = GetAngularRateVector();

                newAvg += temp;
            }

            newAvg /= CALIBRATION_REPETITIONS;

            avg = newAvg;
        }

        public Vector3 GetAngularRateVector()
        {
            var x = (short)((ReadByte(0x1D) << 8) + ReadByte(0x1E));
            var y = (short)((ReadByte(0x1F) << 8) + ReadByte(0x20));
            var z = (short)((ReadByte(0x21) << 8) + ReadByte(0x22));

            return new Vector3((x / SCALE) - avg.X, (y / SCALE) - avg.Y, (z / SCALE) - avg.Z);
        }

        public AxisAngle GetAngularRate()
        {
            var v = GetAngularRateVector();

            return (new Quaternion() *
                Quaternion.FromAxisAngle(new AxisAngle { Axis = Vector3.UnitX, Angle = Angle.FromRadians(v.X) }) *
                Quaternion.FromAxisAngle(new AxisAngle { Axis = Vector3.UnitY, Angle = Angle.FromRadians(v.Y) }) *
                Quaternion.FromAxisAngle(new AxisAngle { Axis = Vector3.UnitZ, Angle = Angle.FromRadians(v.Z) })).ToAxisAngle();
        }


        private I2CDevice.I2CTransaction[] readByteTrans = new I2CDevice.I2CTransaction[2];
        private byte[] writeBuffer = new byte[1];
        private byte[] readBuffer = new byte[1];
        private byte ReadByte(byte address)
        {
            writeBuffer[0] = address;
            readBuffer[0] = 0;

            readByteTrans[0] = Device.CreateWriteTransaction(writeBuffer);
            readByteTrans[1] = Device.CreateReadTransaction(readBuffer);

            Device.Execute(readByteTrans, 10);

            return readBuffer[0];
        }
    }
}
