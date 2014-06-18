using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using ZooTwo.Models;

namespace ZooTwo.Controllers
{
    public class CommentController : Controller
    {
        private readonly ZooTwoContext context = new ZooTwoContext();

        public PartialViewResult _GetForLocation(Int32 locationID) //GET the list of all comments
        {
            ViewBag.LocationID = locationID;
            List<Comment> comments = context.Comments.Where(c => c.LocationID == locationID).ToList();

            return PartialView("_GetForLocation", comments);
        }

        [ChildActionOnly]
        public PartialViewResult _CommentForm(Int32 locationID) //CREATE the form for the comments
        {
            var comment = new Comment {LocationID = locationID};
            return PartialView("_CommentForm", comment);
        }

        [ValidateAntiForgeryToken]
        public PartialViewResult _Submit(Comment comment) //SUBMIT the comments
        {
            context.Comments.Add(comment);
            context.SaveChanges();

            List<Comment> comments = context.Comments.Where(c => c.LocationID == comment.LocationID).ToList();
            ViewBag.LocationID = comment.LocationID;

            return PartialView("_GetForLocation", comments);
        }
    }
}