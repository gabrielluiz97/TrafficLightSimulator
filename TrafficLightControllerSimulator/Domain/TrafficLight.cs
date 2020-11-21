using System;
using System.Diagnostics;
using System.Threading;

namespace Domain
{
    public class TrafficLight
    {
        public TrafficLight()
        {
            TrafficLightOperatorThread = new Thread(TrafficLightOperator);
        }
        public void PowerOn(TimeSpan transitionTIme)
        {
            //Dispara %M4(Ligar sistema)
            On = true;
            GreenLight = true;
            TransitionTIme = transitionTIme;
            TrafficLightOperatorThread.Start();

        }
        public void PowerOff()
        {
            On = false;
            RedLight = false;
            YellowLight = false;
            GreenLight = false;
        }

        public void TrafficLightOperator()
        {
            while (On)
            {
                var TransitionWatch = new Stopwatch();

                TransitionWatch.Start();

                Thread.Sleep((int)TransitionTIme.TotalMilliseconds);

                TransitionWatch.Stop();

                LightTransition();

            }
        }

        public void LightTransition()
        {
            if (GreenLight)
            {
                GreenLight = RedLight = false;
                YellowLight = true;

            }
            else if (YellowLight)
            {
                GreenLight = YellowLight = false;
                RedLight = true;
            }
            else if (RedLight)
            {
                YellowLight = RedLight = false;
                GreenLight = true;
            }
        }
        private Thread TrafficLightOperatorThread { get; set; }
        public bool On { get; set; }//%M5
        public TimeSpan TransitionTIme { get; set; }
        public bool RedLight { get; set; }//%M7
        public bool YellowLight { get; set; }//%M8
        public bool GreenLight { get; set; }//%M6
    }
}

