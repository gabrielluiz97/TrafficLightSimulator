using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TrafficLightControllerSimulator2.Controllers
{
    public class TafficLightSimulatorController : Controller
    {
        TrafficLightSimulatorService Service = TrafficLightSimulatorService.GetInstance;
        public ActionResult Index()
        {
            ViewBag.TrafficLight = Service.GetTrafficLight();
            return View();
        }

        [HttpPost]
        public JsonResult PowerOn()
        {
            var result = new JsonResult();
            try
            {
                Service.PowerOn();

                result.Data = new { Success = true, Message = "Sistema foi iniciado com Sucesso." };
            }
            catch (Exception ex)
            {
                result.Data = new Exception(ex.Message);
            }
            return result;
        }

        [HttpPost]
        public JsonResult PowerOff()
        {
            var result = new JsonResult();
            try
            {

                Service.PowerOff();

                result.Data = new { Success = true, Message = "Sistema foi parado com Sucesso." };
            }
            catch (Exception ex)
            {
                result.Data = new Exception(ex.Message);
            }
            return result;
        }

        [HttpPost]
        public JsonResult PresetYellowLightTimeLeft(int presetValue)
        {
            var result = new JsonResult();
            try
            {

                Service.PresetYellowLightTimeLeft(presetValue);

                result.Data = new { Success = true, Message = "Novo tempo setado com sucesso." };
            }
            catch (Exception ex)
            {
                result.Data = new Exception(ex.Message);
            }
            return result;
        }

        [HttpPost]
        public JsonResult PresetGreenLightTimeLeft(int presetValue)
        {
            var result = new JsonResult();
            try
            {

                Service.PresetGreenLightTimeLeft(presetValue);

                result.Data = new { Success = true, Message = "Novo tempo setado com sucesso." };
            }
            catch (Exception ex)
            {
                result.Data = new Exception(ex.Message);
            }
            return result;
        }

        [HttpPost]
        public JsonResult PresetRedLightTimeLeft(int presetValue)
        {
            var result = new JsonResult();
            try
            {

                Service.PresetRedLightTimeLeft(presetValue);

                result.Data = new { Success = true, Message = "Novo tempo setado com sucesso." };
            }
            catch (Exception ex)
            {
                result.Data = new Exception(ex.Message);
            }
            return result;
        }
    }
}
