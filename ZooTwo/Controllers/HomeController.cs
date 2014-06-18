using System;
using System.Web.Mvc;

namespace ZooTwo.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
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

        public ActionResult Admin()
        {
            //string apiUri = Url.HttpRouteUrl("DefaultApi", new {controller = "admin"});
            string apiUri = Url.HttpRouteUrl("DefaultApi", new { controller = "Admin" });
            ViewBag.ApiUrl = new Uri(Request.Url, apiUri).AbsoluteUri.ToString();

            return View();
        }
    }
}