using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.Mvc;
using ZooTwo.Models;

namespace ZooTwo.Controllers
{
    //[System.Web.Http.RoutePrefix("api/Admin")] // Commmon prefix for the entire controller
    public class AdminController : ApiController
    {
        private readonly ZooTwoContext db = new ZooTwoContext();

        // GET: api/Admin
        public IQueryable<Animal> GetAnimals()
        {
            return db.Animals;
        }
        //[System.Web.Http.Route("")]
        //[System.Web.Http.AcceptVerbs("GET")]
        //public IQueryable<Animal> GetAnimals()
        //{
        //    return db.Animals;
        //}

        // GET: api/Admin/5
        //[Route("{id:int}")]
        [ResponseType(typeof (Animal))]
        public IHttpActionResult GetAnimal(int? id)
        {
            Animal animal = db.Animals.Find(id);
            if (animal == null)
            {
                return NotFound();
            }

            return Ok(animal);
        }

        // PUT: api/Admin/5
        [System.Web.Http.HttpPut]
        [ResponseType(typeof (void))]
        public IHttpActionResult PutAnimal(int id, Animal animal)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != animal.Id)
            {
                return BadRequest();
            }

            db.Entry(animal).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AnimalExists(id))
                {
                    return NotFound();
                }
                throw;
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Admin
        [System.Web.Http.HttpPost]
        [ResponseType(typeof (Animal))]
        public IHttpActionResult PostAnimal(Animal animal)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Animals.Add(animal);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new {id = animal.Id}, animal);
        }

        // DELETE: api/Admin/5
        [ResponseType(typeof (Animal))]
        public IHttpActionResult DeleteAnimal(int id)
        {
            Animal animal = db.Animals.Find(id);
            if (animal == null)
            {
                return NotFound();
            }

            db.Animals.Remove(animal);
            db.SaveChanges();

            return Ok(animal);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AnimalExists(int id)
        {
            return db.Animals.Count(e => e.Id == id) > 0;
        }
    }
}