using IOT.Philips.WebAPI.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IOT.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            LightController light = new LightController();
            light.OnOff(true);
            //light.GetAllLights("test");
           // light.LightOnOff("username", 1,true);
           // light.DeleteLights("test", 7);
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
    }
}