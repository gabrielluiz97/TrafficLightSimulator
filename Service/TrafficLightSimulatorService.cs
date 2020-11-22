using Domain;
using System;

namespace Service
{
    public class TrafficLightSimulatorService
    {
        public TrafficLight TrafficLight;
        static TrafficLightSimulatorService TrafficLightSimulatorServiceIntance;

        public static TrafficLightSimulatorService GetInstance
        {
            get { return TrafficLightSimulatorServiceIntance ?? (TrafficLightSimulatorServiceIntance = new TrafficLightSimulatorService()); }
        }
        private TrafficLightSimulatorService() {
            TrafficLight = new TrafficLight();
        }

        public  void PowerOn()
        {
             TrafficLight.PowerOn();
        }

        public  void PowerOff()
        {
             TrafficLight.PowerOff();
        }
        public void PresetYellowLightTimeLeft(int presetValue)
        {
            TrafficLight.SetNewPresetYellowLightTimeLeft(presetValue);
        }
        public void PresetGreenLightTimeLeft(int presetValue)
        {
            TrafficLight.SetNewPresetGreenLightTimeLeft(presetValue);
        }
        public void PresetRedLightTimeLeft(int presetValue)
        {
            TrafficLight.SetNewPresetRedLightTimeLeft(presetValue);
        }
        public TrafficLight GetTrafficLight()
        {
            return TrafficLight;
        }
    }
}
