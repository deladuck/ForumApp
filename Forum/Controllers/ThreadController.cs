using Forum.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Forum.Controllers
{
    public class ThreadController : Controller {

        /**
         * AddComment method handles adding comments by users in threads.
         * Accepting as incoming paramethers the next info:
         * @Body as a comment body
         * @AuthorId as an autor id
         * @ThreadId as a thread id
         * */
        [HttpPost]
        public ActionResult AddComment(string Body, string AuthorId, int ThreadId) {
            var context = new ForumContext();
            int elementsCount = context.Comments.ToList().Count;
            context.Comments.Add(new Comment(0, AuthorId, Body, ThreadId));
            context.SaveChanges();
            return Redirect(Request.UrlReferrer.ToString());
        }

        /**
         * EditComment method handles edditing comments written by the user.
         * Accepting as incoming paramethers the next info:
         * @Id as a comment id
         * Matching comment' author ID and User' ID
         * If matches - returing partial view with comment' edit form
         * Otherwise, makes page refresh
         * */
        [HttpPost]
        public ActionResult EditComment(int Id) {
            var context = new ForumContext();
            var comment = context.Comments.Find(Id);
            if (comment.AuthorId == User.Identity.GetUserId()) {
                ViewBag.editComment = comment;
                return PartialView("_EditComment");
            }
            return Redirect(Request.UrlReferrer.ToString());
        }

        /**
         * ApplyEdit method updates edited comment on DB.
         * Accepting as incoming paramethers the next info:
         * @Body as a comment body
         * @Id as a comment id
         * Matching comment' author ID and User' ID
         * If matches - returing partial view with edited comment
         * Otherwise, makes page refresh
         * */
        [HttpPost]
        public ActionResult ApplyEdit(string Body, int Id) {
            var context = new ForumContext();
            var comment = context.Comments.SingleOrDefault(c => c.Id == Id);
            if (comment.AuthorId == User.Identity.GetUserId()) {
                comment.Body = Body;
                context.SaveChanges();
                ViewBag.Comm = comment;
                return PartialView("_commentPartial");
            }
            return Redirect(Request.UrlReferrer.ToString());
        }

        /**
         * CreateThread method returns page with the form for a new thread creation.
         * If user is authenticated - returns the page with new thread creation form
         * Otherwise, makes page refresh
         * */
        public ActionResult CreateThread() {
            if (User.Identity.IsAuthenticated) {
                return View();
            } else {
                return Redirect(Request.UrlReferrer.ToString());
            }
        }

        /**
         * SubmitNewThread method sumbits new thread on DB.
         * Accepting as incoming paramethers the next info:
         * @thread as a thread instance from CreateThread view
         * If user is authenticated - adds to BD context a new thread
         * returns Index page
         * */
        [HttpPost]
        public ActionResult SubmitNewThread(Thread thread) {
            if (User.Identity.IsAuthenticated) {
                var context = new ForumContext();
                thread.Author = User.Identity.GetUserId();
                context.Threads.Add(thread);
                context.SaveChanges();
            }
            return RedirectToAction("Index", "Home");
        }
    }
}