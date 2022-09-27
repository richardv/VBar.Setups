namespace VBar
{
    using System.Text;

    public static class ExportSettingsExtension
    {
        public static string ExportCsv(this VBarSettings settings)
        {
            var response = new StringBuilder();

            response.AppendLine($"{settings.Name},Bank 1,Bank 2,Bank 3,Bank AR");
            response.AppendLine("Flight Parameter");
            response.AppendLine("Collective Curve");
            response.AppendLine($"Max,{settings.Value(VBarSettings.Settings.Collective_100_1)},{settings.Value(VBarSettings.Settings.Collective_100_2)},{settings.Value(VBarSettings.Settings.Collective_100_3)}");
            response.AppendLine($"P 50%,{settings.Value(VBarSettings.Settings.Collective_50_1)},{settings.Value(VBarSettings.Settings.Collective_50_2)},{settings.Value(VBarSettings.Settings.Collective_50_3)}");
            response.AppendLine($"Center,{settings.Value(VBarSettings.Settings.Collective_0_1)},{settings.Value(VBarSettings.Settings.Collective_0_2)},{settings.Value(VBarSettings.Settings.Collective_0_3)}");
            response.AppendLine($"P -50%,{settings.Value(VBarSettings.Settings.Collective_minus50_1)},{settings.Value(VBarSettings.Settings.Collective_minus50_2)},{settings.Value(VBarSettings.Settings.Collective_minus50_3)}");
            response.AppendLine($"Min,{settings.Value(VBarSettings.Settings.Collective_minus100_1)},{settings.Value(VBarSettings.Settings.Collective_minus100_2)},{settings.Value(VBarSettings.Settings.Collective_minus100_3)}");

            response.AppendLine();
            response.AppendLine("Main Rotor");
            response.AppendLine($"Exponential,{settings.Value(VBarSettings.Settings.Mainrotor_Expo_1)},{settings.Value(VBarSettings.Settings.Mainrotor_Expo_2)},{settings.Value(VBarSettings.Settings.Mainrotor_Expo_3)}");
            response.AppendLine($"Agility,{settings.MainRotorAgility(VBarSettings.Settings.Mainrotor_Rate_1)},{settings.MainRotorAgility(VBarSettings.Settings.Mainrotor_Rate_2)},{settings.MainRotorAgility(VBarSettings.Settings.Mainrotor_Rate_3)}");
            response.AppendLine($"Gain,{settings.Value(VBarSettings.Settings.Mainrotor_Gain_1)},{settings.Value(VBarSettings.Settings.Mainrotor_Gain_2)},{settings.Value(VBarSettings.Settings.Mainrotor_Gain_3)}");
            response.AppendLine($"Style,{settings.Value(VBarSettings.Settings.Mainrotor_Style_1)},{settings.Value(VBarSettings.Settings.Mainrotor_Style_2)},{settings.Value(VBarSettings.Settings.Mainrotor_Style_3)}");
            response.AppendLine($"Lightness,{settings.Value(VBarSettings.Settings.Lightness_1)},{settings.Value(VBarSettings.Settings.Lightness_2)},{settings.Value(VBarSettings.Settings.Lightness_3)}");
            response.AppendLine($"Elev. Precomp,{settings.Value(VBarSettings.Settings.Mainrotor_Elev_Prec_1)},{settings.Value(VBarSettings.Settings.Mainrotor_Elev_Prec_2)},{settings.Value(VBarSettings.Settings.Mainrotor_Elev_Prec_3)}");
            response.AppendLine($"Paddlesim,{settings.Value(VBarSettings.Settings.Mainrotor_Paddle_Sim_1)},{settings.Value(VBarSettings.Settings.Mainrotor_Paddle_Sim_2)},{settings.Value(VBarSettings.Settings.Mainrotor_Paddle_Sim_3)}");
            response.AppendLine($"Integral,{settings.Value(VBarSettings.Settings.Mainrotor_Integral_1)},{settings.Value(VBarSettings.Settings.Mainrotor_Integral_2)},{settings.Value(VBarSettings.Settings.Mainrotor_Integral_3)}");
            response.AppendLine($"Pitch pump,{settings.Value(VBarSettings.Settings.Mainrotor_Pitch_Pump_1)},{settings.Value(VBarSettings.Settings.Mainrotor_Pitch_Pump_2)},{settings.Value(VBarSettings.Settings.Mainrotor_Pitch_Pump_3)}");
            response.AppendLine($"Coll. Balance,{settings.Value(VBarSettings.Settings.Collective_Balance_1)},{settings.Value(VBarSettings.Settings.Collective_Balance_2)},{settings.Value(VBarSettings.Settings.Collective_Balance_3)}");
            response.AppendLine($"Optimizer Values,{settings.Value(VBarSettings.Settings.Mainrotor_Optimizer_1)},{settings.Value(VBarSettings.Settings.Mainrotor_Optimizer_2)},{settings.Value(VBarSettings.Settings.Mainrotor_Optimizer_3)}");
            response.AppendLine($"Optimizer,{(settings.Value(VBarSettings.Settings.Mainrotor_Optimizer) == 1 ? "On" : "Off")}");
            response.AppendLine($"General Response,{settings.Value(VBarSettings.Settings.Heli_Size)}");

            response.AppendLine();
            response.AppendLine("Tail Rotor");
            response.AppendLine($"Exponential,{settings.Value(VBarSettings.Settings.Tailrotor_Expo_1)},{settings.Value(VBarSettings.Settings.Tailrotor_Expo_2)},{settings.Value(VBarSettings.Settings.Tailrotor_Expo_3)}");
            response.AppendLine($"Yaw Rate,{settings.TailRotorAgility(VBarSettings.Settings.Tailrotor_Rate_1)},{settings.TailRotorAgility(VBarSettings.Settings.Tailrotor_Rate_2)},{settings.TailRotorAgility(VBarSettings.Settings.Tailrotor_Rate_3)}");
            response.AppendLine($"Gain,{settings.Value(VBarSettings.Settings.Tailrotor_Gain_1)},{settings.Value(VBarSettings.Settings.Tailrotor_Gain_2)},{settings.Value(VBarSettings.Settings.Tailrotor_Gain_3)}");
            response.AppendLine($"Proportional,{settings.Value(VBarSettings.Settings.Tailrotor_P_Gain_1)},{settings.Value(VBarSettings.Settings.Tailrotor_P_Gain_2)},{settings.Value(VBarSettings.Settings.Tailrotor_P_Gain_3)}");
            response.AppendLine($"Integral,{settings.Value(VBarSettings.Settings.Tailrotor_I_Gain_1)},{settings.Value(VBarSettings.Settings.Tailrotor_I_Gain_2)},{settings.Value(VBarSettings.Settings.Tailrotor_I_Gain_3)}");
            response.AppendLine($"I Limiter,{settings.Value(VBarSettings.Settings.Tailrotor_I_Limit_1)},{settings.Value(VBarSettings.Settings.Tailrotor_I_Limit_2)},{settings.Value(VBarSettings.Settings.Tailrotor_I_Limit_3)}");
            response.AppendLine($"I Discharge,{settings.Value(VBarSettings.Settings.Tailrotor_I_Discharge_1)},{settings.Value(VBarSettings.Settings.Tailrotor_I_Discharge_2)},{settings.Value(VBarSettings.Settings.Tailrotor_I_Discharge_3)}");
            response.AppendLine($"Differential,{settings.Value(VBarSettings.Settings.Tailrotor_D_Gain_1)},{settings.Value(VBarSettings.Settings.Tailrotor_D_Gain_2)},{settings.Value(VBarSettings.Settings.Tailrotor_D_Gain_3)}");
            response.AppendLine($"Coll Precomp.,{settings.Value(VBarSettings.Settings.Tailrotor_Torque_Compensation_Collective_1)},{settings.Value(VBarSettings.Settings.Tailrotor_Torque_Compensation_Collective_2)},{settings.Value(VBarSettings.Settings.Tailrotor_Torque_Compensation_Collective_3)}");
            response.AppendLine($"Cycl. Precomp.,{settings.Value(VBarSettings.Settings.Tailrotor_Torque_Compensation_Cyclic_1)},{settings.Value(VBarSettings.Settings.Tailrotor_Torque_Compensation_Cyclic_2)},{settings.Value(VBarSettings.Settings.Tailrotor_Torque_Compensation_Cyclic_3)}");
            response.AppendLine($"Stop Gain A,{settings.Value(VBarSettings.Settings.Tailrotor_Stop_Gain_A_1)},{settings.Value(VBarSettings.Settings.Tailrotor_Stop_Gain_A_2)},{settings.Value(VBarSettings.Settings.Tailrotor_Stop_Gain_A_3)}");
            response.AppendLine($"Stop Gain B,{settings.Value(VBarSettings.Settings.Tailrotor_Stop_Gain_B_1)},{settings.Value(VBarSettings.Settings.Tailrotor_Stop_Gain_B_2)},{settings.Value(VBarSettings.Settings.Tailrotor_Stop_Gain_B_3)}");
            response.AppendLine($"Optimizer A,{settings.Value(VBarSettings.Settings.Tailrotor_Optimize_Side_A_1)},{settings.Value(VBarSettings.Settings.Tailrotor_Optimize_Side_A_2)},{settings.Value(VBarSettings.Settings.Tailrotor_Optimize_Side_A_3)}");
            response.AppendLine($"Optimizer B,{settings.Value(VBarSettings.Settings.Tailrotor_Optimize_Side_B_1)},{settings.Value(VBarSettings.Settings.Tailrotor_Optimize_Side_B_2)},{settings.Value(VBarSettings.Settings.Tailrotor_Optimize_Side_B_3)}");
            response.AppendLine($"Wag Suppression,{settings.Value(VBarSettings.Settings.Tail_Wag_Suppression_1)},{settings.Value(VBarSettings.Settings.Tail_Wag_Suppression_2)},{settings.Value(VBarSettings.Settings.Tail_Wag_Suppression_3)}");
            response.AppendLine($"Auto Opti,{settings.OnOff(VBarSettings.Settings.Mainrotor_Autotrim_Tail)}");
            response.AppendLine($"Tail Acceleration,{settings.Value(VBarSettings.Settings.Tail_Expert_Acceleration)}");

            response.AppendLine();
            response.AppendLine($"Governor,{settings.GovernorType()}");
            if (settings.Value(VBarSettings.Settings.Governor_Mode) == 1)
            {
                response.AppendLine($"Headspeed,{settings.Headspeed(VBarSettings.Settings.Headspeed_1)},{settings.Headspeed(VBarSettings.Settings.Headspeed_2)},{settings.Headspeed(VBarSettings.Settings.Headspeed_3)}");
            }
            else
            {
                response.AppendLine($"Output,{settings.Value(VBarSettings.Settings.Governor_ESC_Output_1) / 2 + 50},{settings.Value(VBarSettings.Settings.Governor_ESC_Output_2) / 2 + 50},{settings.Value(VBarSettings.Settings.Governor_ESC_Output_3) / 2 + 50}");
            }
            if (settings.Value(VBarSettings.Settings.Governor_Mode) == 1)
            {
                response.AppendLine($"Gain,{settings.Value(VBarSettings.Settings.Governor_Gain_1)},{settings.Value(VBarSettings.Settings.Governor_Gain_2)},{settings.Value(VBarSettings.Settings.Governor_Gain_3)}");
                response.AppendLine($"Collective Ad,{settings.Value(VBarSettings.Settings.Governor_Collective_Add_1)},{settings.Value(VBarSettings.Settings.Governor_Collective_Add_2)},{settings.Value(VBarSettings.Settings.Governor_Collective_Add_3)}");
                response.AppendLine($"Cyclic Ad,{settings.Value(VBarSettings.Settings.Governor_Cyclic_Add_1)},{settings.Value(VBarSettings.Settings.Governor_Cyclic_Add_2)},{settings.Value(VBarSettings.Settings.Governor_Cyclic_Add_3)}");
                response.AppendLine($"Collective Dynamic,{settings.Value(VBarSettings.Settings.Governor_Collective_Dynamic_1)},{settings.Value(VBarSettings.Settings.Governor_Collective_Dynamic_2)},{settings.Value(VBarSettings.Settings.Governor_Collective_Dynamic_3)}");
                response.AppendLine($"Basic Throttle,{settings.Throttle(VBarSettings.Settings.Governor_Basic_Throttle_1)},{settings.Throttle(VBarSettings.Settings.Governor_Basic_Throttle_2)},{settings.Throttle(VBarSettings.Settings.Governor_Basic_Throttle_3)}");
                response.AppendLine($"Integral,{settings.Value(VBarSettings.Settings.Governor_Integral_1)},{settings.Value(VBarSettings.Settings.Governor_Integral_2)},{settings.Value(VBarSettings.Settings.Governor_Integral_3)}");
                response.AppendLine($"Proportional Limit +,?,?,?");
                response.AppendLine($"Proportional Limit -,?,?,?");
                response.AppendLine($"Min. Throttle,{settings.Throttle(VBarSettings.Settings.Governor_Min_Throttle)}");
                response.AppendLine($"AR Idle,{settings.Throttle(VBarSettings.Settings.Governor_Expert_Autorotation)}");
                response.AppendLine($"Runup Limit,{settings.Value(VBarSettings.Settings.Governor_Runup_Limit)}");
            }

            response.AppendLine();
            response.AppendLine("Autotrim");
            response.AppendLine($"Elevator,{settings.Value(VBarSettings.Settings.Mainrotor_Autotrim_Elevator)}");
            response.AppendLine($"Aileron,{settings.Value(VBarSettings.Settings.Mainrotor_Autotrim_Aileron)}");
            response.AppendLine($"Tail,{settings.Value(VBarSettings.Settings.Mainrotor_Autotrim_Tail)}");
            response.AppendLine($"Autotrim Flight,{(settings.Value(VBarSettings.Settings.Mainrotor_Autotrim) == 1 ? "On" : "Off")}");

            response.AppendLine();
            response.AppendLine("Device and Version");
            response.AppendLine($"Firmware Version,{settings.Version()}");

            response.AppendLine();
            response.AppendLine("Model Setup");
            response.AppendLine("Basic Model Setup");
            response.AppendLine($"Model Name,{settings.Name.Replace("_", " ")}");
            response.AppendLine($"Sensor Orientation,\"{settings.SensorDirection()}\"");
            response.AppendLine($"External Sensor,\"{settings.ExternalSensor()}\"");
            response.AppendLine($"Rotation Direction,{settings.MainRotorDirection()}");

            response.AppendLine();
            response.AppendLine("Main Rotor Setup");
            response.AppendLine($"Swashplate Type,{settings.SwashplateType()}");
            response.AppendLine();
            response.AppendLine($"Elevator Top,{settings.Value(VBarSettings.Settings.End_Trim_Pos_Elevator)}");
            response.AppendLine($"Aileron Top,{settings.Value(VBarSettings.Settings.End_Trim_Pos_Aileron)}");
            response.AppendLine($"Elevator Bottom,{settings.Value(VBarSettings.Settings.End_Trim_Neg_Elevator)}");
            response.AppendLine($"Aileron Bottom,{settings.Value(VBarSettings.Settings.End_Trim_Neg_Aileron)}");
            response.AppendLine();
            response.AppendLine($"Cyclic Ring,{settings.Value(VBarSettings.Settings.Cyclic_Ring)}");
            response.AppendLine();
            response.AppendLine($"Geometry Correction,{settings.OnOff(VBarSettings.Settings.Geometry_Correction)}");
            response.AppendLine();
            response.AppendLine($"Zero Collective,{settings.Value(VBarSettings.Settings.Tail_Optimize_Zero_Collective)}");
            response.AppendLine();
            response.AppendLine($"Servo Direction Channel 1,{settings.NormalReversed(VBarSettings.Settings.Servo_Direction_1)}");
            response.AppendLine($"Servo Direction Channel 2,{settings.NormalReversed(VBarSettings.Settings.Servo_Direction_2)}");
            response.AppendLine($"Servo Direction Channel 3,{settings.NormalReversed(VBarSettings.Settings.Servo_Direction_3)}");
            response.AppendLine($"Servo Direction Channel 4,{settings.NormalReversed(VBarSettings.Settings.Servo_Direction_4)}");
            response.AppendLine();
            response.AppendLine($"Trim Servo Ch1,{settings.Value(VBarSettings.Settings.Servo_1_Center_Trim)}");
            response.AppendLine($"Trim Servo Ch2,{settings.Value(VBarSettings.Settings.Servo_2_Center_Trim)}");
            response.AppendLine($"Trim Servo Ch3,{settings.Value(VBarSettings.Settings.Servo_3_Center_Trim)}");
            response.AppendLine($"Trim Servo Ch4,{settings.Value(VBarSettings.Settings.Servo_4_Center_Trim)}");
            response.AppendLine();
            response.AppendLine($"Collective Max,{settings.Value(VBarSettings.Settings.Collective_100_1)}");
            response.AppendLine($"Collective Min,{settings.Value(VBarSettings.Settings.Collective_minus100_1)}");
            response.AppendLine();
            response.AppendLine($"Cyclic Calibration,{settings.CyclicCalibration()}");

            response.AppendLine();
            response.AppendLine("Tail Rotor Setup");
            response.AppendLine($"Tail Servo Type,{settings.TailServoType()}");
            response.AppendLine($"Tail Control,{settings.TailControl()}");
            response.AppendLine($"Tail Servo Direction,{settings.NormalReversed(VBarSettings.Settings.Tailrotor_Servo_Reverse)}");
            response.AppendLine();
            response.AppendLine($"Tail Servo Left Limit,{settings.Value(VBarSettings.Settings.Tailrotor_Left_Limit) * 2}");
            response.AppendLine($"Tail Servo Right Limit,{settings.Value(VBarSettings.Settings.Tailrotor_Right_Limit) * 2}");

            response.AppendLine();
            response.AppendLine("Governor Setup");
            response.AppendLine($"Governor Type,{settings.GovernorType()}");
            response.AppendLine($"Collective Control,Off");
            response.AppendLine($"Output Endpoint Full,{settings.Value(VBarSettings.Settings.Governor_ESC_Endpoint_High)}");
            response.AppendLine($"Output Endpoint Stop,{settings.Value(VBarSettings.Settings.Governor_ESC_Endpoint_Low)}");
            response.AppendLine($"Gear Ratio,{settings.MainGearRatio()}");
            response.AppendLine($"Motor Poles,{settings.Value(VBarSettings.Settings.Governor_Sensor_Config)}");

            response.AppendLine();
            response.AppendLine("Flight Timer");
            response.AppendLine($"Timer Duration,{settings.Value(VBarSettings.Settings.Timer_Duration)}");

            response.AppendLine();
            response.AppendLine("RC Voltage");
            response.AppendLine($"RC Voltage Warning,{settings.Value(VBarSettings.Settings.RC_Voltage_Warning) / 10}");

            return response.ToString();
        }
    }
}
