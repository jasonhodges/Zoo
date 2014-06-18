using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using ZooTwo.Models;

namespace ZooTwo.Controllers
{
    public class LocationController : Controller
    {
        private readonly ZooTwoContext context = new ZooTwoContext();

        // GET: Location
        public ActionResult Index()
        {
            List<Location> locations = context.Locations.ToList();
            return View(locations);
        }

        [ChildActionOnly]
        public PartialViewResult _GetForAnimal(Int32 id)
        {
            List<Location> locations = context.Locations.Where(l => l.Animal.Id == id).ToList();
            return PartialView(locations);
        }

        //public ActionResult Details(Int32 id)
    }
}