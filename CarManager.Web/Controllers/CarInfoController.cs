using CarManager.Service.CarInfos;
using CarManager.WebCore.MVC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarManager.Web.Controllers
{
    public class CarInfoController : BaseController
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

        public JsonResult GetCars()
        {
            return Json(carService.GetCarInfos(),JsonRequestBehavior.AllowGet);
        }
    }
}