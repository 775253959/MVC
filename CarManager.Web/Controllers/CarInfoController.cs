using CarManager.Service.CarInfos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarManager.Web.Controllers
{
    public class CarInfoController : Controller
    {
        private readonly ICarInfoService carService;

        public CarInfoController(ICarInfoService carService)
        {
            this.carService = carService;
        }
        // GET: CarInfo
        public ActionResult Index()
        {
            return View(carService.GetCarInfos());
        }
        public 
    }
}