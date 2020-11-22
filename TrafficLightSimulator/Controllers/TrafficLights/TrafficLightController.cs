using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Service;

namespace TrafficLightSimulator.Controllers
{
    public class TrafficLightController : Controller
    {
        TrafficLightSimulatorService Service = TrafficLightSimulatorService.GetInstance;
        public IActionResult Index()
        {
            return View();
        }

        [HttpPut]
        public async Task<JsonResult> PowerOn(TimeSpan? transitionTIme)
        {
            try
            {
                if (!transitionTIme.HasValue) transitionTIme = new TimeSpan(0, 0, 0, 5);


                Service.PowerOn();

                return new JsonResult(new { Success = true, Message = "Sistema foi iniciado com Sucesso." });
            }
            catch (Exception ex)
            {
                return new JsonResult(new { Success = false, Message = ex.Message });
            }
        }

        [HttpPut]
        public async Task<JsonResult> PowerOff(TimeSpan transitionTIme)
        {
            try
            {

                Service.PowerOff();

                return new JsonResult(new { Success = true, Message = "Sistema foi parado com Sucesso." });
            }
            catch (Exception ex)
            {
                return new JsonResult(new { Success = false, Message = ex.Message });
            }
        }
    }
}
