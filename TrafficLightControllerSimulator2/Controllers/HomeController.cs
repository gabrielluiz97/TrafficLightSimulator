using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TrafficLightControllerSimulator2.Controllers
{
    public class HomeController : Controller
    {
        TrafficLightSimulatorService Service = TrafficLightSimulatorService.GetInstance;
        public ActionResult Index()
        {
            var trafficLight = Service.GetTrafficLight();
            ViewBag.On = trafficLight.On;

            ViewBag.PresetGreenLightTimeLeft = trafficLight.PresetGreenLightTimeLeft;
            ViewBag.PresetRedLightTimeLeft = trafficLight.PresetRedLightTimeLeft;
            ViewBag.PresetYellowLightTimeLeft = trafficLight.PresetYellowLightTimeLeft;

            ViewBag.RedLighttOn = trafficLight.RedLighttOn;
            ViewBag.YellowLightOn = trafficLight.YellowLightOn;
            ViewBag.GreenLightOn = trafficLight.GreenLightOn;

            ViewBag.RedLightTimeLeft = trafficLight.RedLightTimeLeft;
            ViewBag.YellowLightTimeLeft = trafficLight.YellowLightTimeLeft;
            ViewBag.GreenLightTimeLeft = trafficLight.GreenLightTimeLeft;

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }


        //[HttpPut]
        //[ActionName("PowerOn")]
        //public JsonResult PowerOn()
        //{
        //    var result = new JsonResult();
        //    try
        //    {
        //        Service.PowerOn();

        //        result.Data = new { Success = true, Message = "Sistema foi iniciado com Sucesso." };
        //    }
        //    catch (Exception ex)
        //    {
        //        result.Data = new Exception(ex.Message);
        //    }
        //    return result;
        //}

        //[HttpPut]
        //public JsonResult PowerOff()
        //{
        //    var result = new JsonResult();
        //    try
        //    {

        //        Service.PowerOff();

        //        result.Data = new { Success = true, Message = "Sistema foi parado com Sucesso." };
        //    }
        //    catch (Exception ex)
        //    {
        //        result.Data = new Exception(ex.Message);
        //    }
        //    return result;
        //}
    }
}