//By Krystian Horoszkiewicz
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShutdownLogic
{
    public enum UnitOfData
    {
        Bits, Bytes, Kilobits, Kilobytes, Megabits, Megabytes, Gigabits, Gigabytes, Terabits, Terabytes
    }

    public class NetworkStats
    {
        private List<PerformanceCounter> instancesList = new List<PerformanceCounter>();
        private Dictionary<string, bool> activeButtonState = new Dictionary<string, bool>();
        private float _speedInBytes = 0;
        private readonly Dictionary<UnitOfData, string> _unitRepresentationList = new Dictionary<UnitOfData, string>(){
                    {UnitOfData.Bits, "Bit/s"},
                    {UnitOfData.Bytes, "Bytes/s"},
                    {UnitOfData.Kilobits, "Kb/s"},
                    {UnitOfData.Kilobytes, "KB/s"},
                    {UnitOfData.Megabits, "Mb/s"},
                    {UnitOfData.Megabytes, "MB/s"},
                    {UnitOfData.Gigabits, "Gb/s"},
                    {UnitOfData.Gigabytes, "GB/s"},
                    {UnitOfData.Terabits, "Tb/s"},
                    {UnitOfData.Terabytes, "TB/s"},

        };
        public string GetUnitStringRepresentation(UnitOfData dataType)
        {
            string type = "";
            _unitRepresentationList.TryGetValue(dataType, out type);
            return type;
        }
        public NetworkStats()
        {
            // Network Utilization (in Bytes/Sec)
            PerformanceCounterCategory category = new PerformanceCounterCategory("Network Interface");
            String[] instanceName = category.GetInstanceNames();
            foreach (string name in instanceName)
            {
                instancesList.Add(new PerformanceCounter("Network Interface", "Bytes Received/sec", name));
            }
        }
        /// <summary>
        /// Call this method to get the speed updated.
        /// </summary>
        /// <returns></returns>
        public float CurrentSpeedInBytes()
        {
            //float speedInBytes = 0;
            foreach (PerformanceCounter counter in instancesList)
            {
                // Value returned in bytes
                // May throw AccessViolationException, in .NET Corrupted State Exceptions (CSE) are not allowed to be caught by your standard managed code.
                _speedInBytes = counter.NextValue();
                if (_speedInBytes > 0) return _speedInBytes;
            }
            return _speedInBytes;
        }
        /// <summary>
        /// Returns speed in Bits/sec in specified format.
        /// </summary>
        /// <param name="dataType"></param>
        /// <returns></returns>
        public float CurrentSpeed(UnitOfData dataType)
        {
            return ConvertSpeed(_speedInBytes, dataType);
        }

        /// <summary>
        /// Returns current speed in Bits/s and format based on speed.
        /// </summary>
        /// <returns></returns>
        public float CurrentSpeedFromBits(out UnitOfData dataType)
        {
            float baseSpeed = _speedInBytes;
            dataType = UnitOfData.Bits;
            baseSpeed = ConvertSpeed(baseSpeed, UnitOfData.Bits);

            if (baseSpeed < 1000)
            {
                return ScaleBits(baseSpeed, dataType);
            }
            else if (baseSpeed >= 1000 && baseSpeed < 1e+6)
            {
                dataType = UnitOfData.Kilobits;
                return ScaleBits(baseSpeed, dataType);
            }
            else if (baseSpeed >= 1e+6 && baseSpeed < 1e+9)
            {
                dataType = UnitOfData.Megabits;
                return ScaleBits(baseSpeed, dataType);
            }
            else if (baseSpeed >= 1e+9 && baseSpeed < 1e+12)
            {
                dataType = UnitOfData.Gigabits;
                return ScaleBits(baseSpeed, dataType);
            }
            else if (baseSpeed >= 1e+12 && baseSpeed < 1e+15)
            {
                dataType = UnitOfData.Terabits;
                return ScaleBits(baseSpeed, dataType);
            }
            else
            {
                dataType = UnitOfData.Terabits;
                return ScaleBits(baseSpeed, dataType);
            }
        }

        /// <summary>
        /// Returns current speed in Bytes/s and format based on speed.
        /// </summary>
        /// <returns></returns>
        public float CurrentSpeedFromBytes(out UnitOfData dataType)
        {
            float baseSpeed = _speedInBytes;
            dataType = UnitOfData.Bytes;

            if (baseSpeed < 1024)
            {
                return ScaleBytes(baseSpeed, dataType);
            }
            else if (baseSpeed >= 1024 && baseSpeed < 1048576)
            {
                dataType = UnitOfData.Kilobytes;
                return ScaleBytes(baseSpeed, dataType);
            }
            else if (baseSpeed >= 1048576 && baseSpeed < 1073741824)
            {
                dataType = UnitOfData.Megabytes;
                return ScaleBytes(baseSpeed, dataType);
            }
            else if (baseSpeed >= 1073741824 && baseSpeed < 1.09e12)
            {
                dataType = UnitOfData.Gigabytes;
                return ScaleBytes(baseSpeed, dataType);
            }
            else if (baseSpeed >= 1.09e12 && baseSpeed < 1.236e15)
            {
                dataType = UnitOfData.Terabytes;
                return ScaleBytes(baseSpeed, dataType);
            }
            else
            {
                dataType = UnitOfData.Terabytes;
                return ScaleBytes(baseSpeed, dataType);
            }
        }
        /// <summary>
        /// Converts speed from bytes/sec to any bits/sec or bytes/sec format. Supported formats: Bits/sec, kilobits/sec, kilobytes/sec, megabits/sec, megabytes/sec
        /// </summary>
        /// <param name="speed"></param>
        /// <param name="dataType"></param>
        /// <returns></returns>
        public float ConvertSpeed(float speedInBytes, UnitOfData dataType)
        {
            switch (dataType)
            {
                case UnitOfData.Bits:
                    return (float)Math.Round(speedInBytes * 8, 1);
                case UnitOfData.Kilobits:
                    return (float)Math.Round((speedInBytes / 1000) * 8, 1);
                case UnitOfData.Megabits:
                    return (float)Math.Round((speedInBytes / 1000 / 1000) * 8, 1);
                case UnitOfData.Gigabits:
                    return (float)Math.Round((speedInBytes / 1000 / 1000 / 1000) * 8, 1);
                case UnitOfData.Terabits:
                    return (float)Math.Round((speedInBytes / 1000 / 1000 / 1000 / 1000) * 8, 1);
                case UnitOfData.Bytes:
                    return (float)Math.Round(speedInBytes, 1);
                case UnitOfData.Kilobytes:
                    return (float)Math.Round((speedInBytes / 1024), 1);
                case UnitOfData.Megabytes:
                    return (float)Math.Round((speedInBytes / 1024 / 1024), 1);
                case UnitOfData.Gigabytes:
                    return (float)Math.Round((speedInBytes / 1024 / 1024 / 1024), 1);
                case UnitOfData.Terabytes:
                    return (float)Math.Round((speedInBytes / 1024 / 1024 / 1024 / 1024), 1);
                default:
                    return speedInBytes;
            };
        }

        /// <summary>
        /// Converts speed from bit/s to specified higher transfer speeds. Supported formats: Bits/sec, kilobits/sec, megabits/sec and gigabits/sec.
        /// </summary>
        /// <param name="bits"></param>
        /// <param name="dataType"></param>
        /// <returns></returns>
        private float ScaleBits(float bits, UnitOfData dataType)
        {
            switch (dataType)
            {
                case UnitOfData.Bits:
                    return (float)Math.Round(bits, 1);
                case UnitOfData.Kilobits:
                    return (float)Math.Round((bits / 1000), 1);
                case UnitOfData.Megabits:
                    return (float)Math.Round((bits / 1000 / 1000), 1);
                case UnitOfData.Gigabits:
                    return (float)Math.Round((bits / 1000 / 1000 / 1000), 1);
                case UnitOfData.Terabits:
                    return (float)Math.Round((bits / 1000 / 1000 / 1000 / 1000), 1);
                default:
                    return bits;
            };
        }

        /// <summary>
        /// Converts speed from bytes/s to specified higher transfer speeds. Supported formats: Bytes/sec, kilobytes/sec, megabytes/sec and gigabytes/sec.
        /// </summary>
        /// <param name="bytes"></param>
        /// <param name="dataType"></param>
        /// <returns></returns>
        private float ScaleBytes(float bytes, UnitOfData dataType)
        {
            switch (dataType)
            {
                case UnitOfData.Bytes:
                    return (float)Math.Round(bytes, 1);
                case UnitOfData.Kilobytes:
                    return (float)Math.Round((bytes / 1000), 1);
                case UnitOfData.Megabytes:
                    return (float)Math.Round((bytes / 1000 / 1000), 1);
                case UnitOfData.Gigabytes:
                    return (float)Math.Round((bytes / 1000 / 1000 / 1000), 1);
                case UnitOfData.Terabytes:
                    return (float)Math.Round((bytes / 1000 / 1000 / 1000 / 1000), 1);
                default:
                    return bytes;
            };
        }

        public bool SpeedBelowTreshold(float speed, UnitOfData dataType)
        {
            if (ConvertSpeed(_speedInBytes, dataType) < speed)
            {
                return true;
            }
            return false;
        }
    }
}
