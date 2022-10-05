namespace VBar
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    public partial class VBarSettings
    {
        public string Name { get; set; }

        public List<VBarSetting> List = new List<VBarSetting>();

        public VBarSettings(string name, Stream fileStream)
        {
            Name = name;

            var buffer = new byte[2];

            while (fileStream.Position < fileStream.Length)
            {
                var hexId = (int)fileStream.Position / buffer.Length;
                fileStream.Read(buffer, 0, buffer.Length);
                var hexValue = buffer[0] + buffer[1];

                List.Add(new VBarSetting { Pos = hexId + 1, Value = hexValue });
            }
        }

        public int RealValue(Settings setting)
        {
            return List.Single(l => l.Pos == (int)setting).Value;
        }

        public int CollectiveMax()
        {
            return new List<int>
            {
                Value(Settings.Collective_100_1),
                Value(Settings.Collective_100_2),
                Value(Settings.Collective_100_3),
                Value(Settings.Collective_100_4)
            }.Max();
        }

        public int CollectiveMin()
        {
            return new List<int>
            {
                Value(Settings.Collective_minus100_1),
                Value(Settings.Collective_minus100_2),
                Value(Settings.Collective_minus100_3),
                Value(Settings.Collective_minus100_4)
            }.Min();
        }

        public int Value(Settings setting)
        {
            var vbarSetting = List.Single(l => l.Pos == (int)setting);

            if (vbarSetting.Value > 350)
                return vbarSetting.Value - 511;

            return vbarSetting.Value;
        }

        public int MainRotorAgility(Settings setting)
        {
            var vbarSetting = List.Single(l => l.Pos == (int)setting);

            if (vbarSetting.Value > 350)
                return Math.Abs((vbarSetting.Value - 511) * 2);

            return vbarSetting.Value;
        }

        public string TailControl()
        {
            return "Servo";
        }

        public string TailServoType()
        {
            var result = string.Empty;

            var refreshRate = List.Single(l => l.Pos == (int)Settings.Tailrotor_Servo_Refresh);

            if (refreshRate.Value > 0)
            {
                if (refreshRate.Value == 2)
                {
                    result += "500 Hz.";
                }

                if (refreshRate.Value == 3)
                {
                    result += "333 Hz.";
                }

                if (refreshRate.Value == 4)
                {
                    result += "250 Hz.";
                }

                if (refreshRate.Value == 20)
                {
                    result += "50 Hz.";
                }

                result += " / ";

                var pulseWidth = List.Single(l => l.Pos == (int)Settings.Tailrotor_Servo_Pulse_Width);

                if (pulseWidth.Value == 0)
                {
                    result += "1500/1520";
                }

                if (pulseWidth.Value == 1)
                {
                    result += "760 uSec.";
                }

                if (pulseWidth.Value == 2)
                {
                    result += "1000";
                }
            }

            return result;
        }

        public string OnOff(Settings setting)
        {
            var vbarSetting = List.Single(l => l.Pos == (int)setting);

            return vbarSetting.Value == 1 ? "On" : "Off";
        }

        public int TailRotorAgility(Settings setting)
        {
            var value = Value(setting);

            return value > 0 ? value : value * -2;
        }

        public string NormalReversed(Settings setting)
        {
            var vbarSetting = List.Single(l => l.Pos == (int)setting);

            return vbarSetting.Value == 1 ? "Reverse" : "Normal";
        }

        public string SensorDirection()
        {
            var direction = List.Single(l => l.Pos == (int)Settings.Sensor_Direction);

            if (direction.Value == 0)
            {
                return "Face Up, Wire Rear";
            }
            if (direction.Value == 1)
            {
                return "Face Down, Wire Front";
            }
            if (direction.Value == 2)
            {
                return "Face Down, Wire Rear";
            }
            if (direction.Value == 3)
            {
                return "Face Up, Wire Front";
            }

            return string.Empty;
        }

        public string ExternalSensor()
        {
            var value = List.Single(l => l.Pos == (int)Settings.External_Sensor_Direction);

            return "No external sensor";
        }

        public string MainRotorDirection()
        {
            var direction = List.Single(l => l.Pos == (int)Settings.Rotor_Direction);

            return (direction.Value == 0 ? "CW" : "CCW") + " Main Rotor";
        }

        public string SwashplateType()
        {
            var mixer1 = Value(Settings.Swash_Mixer_A_1);
            var mixer2 = Value(Settings.Swash_Mixer_A_2);
            var mixer3 = Value(Settings.Swash_Mixer_A_3);
            var mixer4 = Value(Settings.Swash_Mixer_A_4);

            if (mixer1 == -100
                && mixer2 == 50
                && mixer3 == 50
                && mixer4 == 0)
            {
                return "HR-3 (120° Rev)";
            }
            else if (mixer1 == 100
                     && mixer2 == -50
                     && mixer3 == -50
                     && mixer4 == 0)
            {
                return "H-3 (120°)";
            }
            else if (mixer1 == -100
                     && mixer2 == 0
                     && mixer3 == 100
                     && mixer4 == 0)
            {
                return "H-4 (90°)";
            }
            else if (mixer1 == -71
                     && mixer2 == 71
                     && mixer3 == 71
                     && mixer4 == 0)
            {
                return "HR-3 (135° Rev)";
            }
            else if (mixer1 == 71
                     && mixer2 == -71
                     && mixer3 == -71
                     && mixer4 == 0)
            {
                return "H-3 (135°)";
            }
            else if (mixer1 == 0
                     && mixer2 == 0
                     && mixer3 == 100
                     && mixer4 == 0)
            {
                return "H-1 (Mech.)";
            }
            else
            {
                return "User defined";
            }
        }

        public double MainGearRatio()
        {
            double ratio = Value(Settings.Main_Gear_Ratio);

            return (ratio / 10);
        }

        public string Version()
        {
            var version = Value(Settings.Version);

            return "6.4." + version;
        }

        public int CyclicCalibration()
        {
            var value = Value(Settings.Cyclic_Setup_Value);

            return (value * 100 / 64);
        }

        public string GovernorType()
        {
            var type = Value(Settings.Governor_Mode);

            switch (type)
            {
                case GovernorTypes.VBarElectric:
                    return "VBar Electric Governor";

                case GovernorTypes.External:
                    return "External Governor";

                case GovernorTypes.VBarNitro:
                    return "VBar Nitro Governor";
            }

            return "Unknown";
        }

        public int Headspeed(Settings setting)
        {
            var value = RealValue(setting);

            var multiplier = RealValue(Settings.Governor_Max_RPM);

            if (multiplier == 0)
            {
                multiplier = 1;
            }

            if (value < 391)
            {
                value += 511;
            }

            return (value - 391) * 20 * multiplier;
        }

        public int Throttle(Settings setting)
        {
            return 50 + Value(setting) / 2;
        }

        public int GovernorOutput(Settings setting)
        {
            return Value(setting) / 2 + 50;
        }

        public double RxVoltageWarning()
        {
            return Value(VBarSettings.Settings.RC_Voltage_Warning) / (double)10;
        }

        public int TailLimit(Settings setting)
        {
            return Value(setting) * 2;
        }

        public bool ArBank()
        {
            return OnOff(VBarSettings.Settings.Autorotation_Bank) == "On";
        }
    }
}