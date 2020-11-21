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

        public  void PowerOn(TimeSpan transitionTIme)
        {
             TrafficLight.PowerOn(transitionTIme);
        }

        public  void PowerOff()
        {
             TrafficLight.PowerOff();
        }
    }
}
