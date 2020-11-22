using System.Diagnostics;
using System.Threading;
using TrafficLightControllerSimulatorCOM;

namespace Domain
{
    public class TrafficLight
    {
        ModBusConnection HTTPRequester;
        public TrafficLight()
        {
            HTTPRequester = ModBusConnection.GetInstance;
            SetOn = false;
        }
        public void PowerOn()
        {
                SetOn = true;
                TrafficLightOperatorThread = new Thread(TrafficLightOperator);
                TrafficLightOperatorThread.Start();
                ChangeValues(SetOn, PresetRedLightTimeLeft, PresetGreenLightTimeLeft, PresetYellowLightTimeLeft);
        }
        public void PowerOff()
        {
            SetOn = false;
            ChangeValues(SetOn, PresetRedLightTimeLeft, PresetGreenLightTimeLeft, PresetYellowLightTimeLeft);
        }

        public void SetNewPresetYellowLightTimeLeft(int presetValue)
        {
            ChangeValues(SetOn, PresetRedLightTimeLeft, PresetGreenLightTimeLeft, presetValue);
        }

        public void SetNewPresetGreenLightTimeLeft(int presetValue)
        {
            ChangeValues(SetOn, PresetRedLightTimeLeft, presetValue, PresetYellowLightTimeLeft);
        }

        public void SetNewPresetRedLightTimeLeft(int presetValue)
        {
            ChangeValues(SetOn, presetValue, PresetGreenLightTimeLeft, PresetYellowLightTimeLeft);
        }

        public void ChangeValues(bool setOn, int presetRedLightTimeLeft, int presetGreenLightTimeLeft, int presetYellowLightTimeLeft)
        {
                NewOn = setOn;
                NewPresetRedLightTimeLeft = presetRedLightTimeLeft;
                NewPresetGreenLightTimeLeft = presetGreenLightTimeLeft;
                NewPresetYellowLightTimeLeft = presetYellowLightTimeLeft;
                HTTPRequester.WriteValues(NewOn, NewPresetRedLightTimeLeft, NewPresetGreenLightTimeLeft, NewPresetYellowLightTimeLeft);
        }

        public void TrafficLightOperator()
        {
            while (true)
            {
                HTTPRequester.Connect();
                var registers = HTTPRequester.ReadInputRegister();
                var readCoil = HTTPRequester.ReadCoils();
                var readHoldingRegisters = HTTPRequester.ReadHoldingRegisters();

                PresetRedLightTimeLeft = registers[1];
                PresetGreenLightTimeLeft = registers[3];
                PresetYellowLightTimeLeft = registers[5];

                On = readCoil[5];
                RedLighttOn = readCoil[7];
                YellowLightOn = readCoil[8];
                GreenLightOn = readCoil[6];

                RedLightTimeLeft = readHoldingRegisters[1] - readHoldingRegisters[2];
                GreenLightTimeLeft = readHoldingRegisters[3] - readHoldingRegisters[4];
                YellowLightTimeLeft = readHoldingRegisters[5] - readHoldingRegisters[6];
            }
        }

        private Thread TrafficLightOperatorThread { get; set; }

        //Write
        public bool On { get; set; }//%M4
        public bool SetOn { get; set; }//%M4
        public int PresetRedLightTimeLeft { get; set; }///%MW1
        public int PresetGreenLightTimeLeft { get; set; }//%MW3
        public int PresetYellowLightTimeLeft { get; set; }//%MW5

        private bool NewOn { get; set; }//%M5
        private int NewPresetRedLightTimeLeft { get; set; }///%MW1
        private int NewPresetGreenLightTimeLeft { get; set; }//%MW3
        private int NewPresetYellowLightTimeLeft { get; set; }//%MW5

        public int RedLightTimeLeft { get; set; }///%MW1
        public int GreenLightTimeLeft { get; set; }//%MW3
        public int YellowLightTimeLeft { get; set; }//%MW5

        //Read    
        public bool RedLighttOn { get; set; }//%M7
        public bool YellowLightOn { get; set; }//%M8
        public bool GreenLightOn { get; set; }//%M6

    }
}

