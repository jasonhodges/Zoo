//namespace Zoo.Controllers
//{
//    public class ZooController : Controller
//    {
//        // GET: Zoo
//        [HttpGet]
//        public ActionResult Animal()
//        {
//            var db = new ApplicationDbContext();
//            ViewBag.AnimalName = new SelectList(db.Animals, "Name", "Animal");

//            var animals = db.Animals.Include(a => a.Name).OrderBy(a => a.Name);

//            return View(animals.ToList());
//        }
//    }
//}

