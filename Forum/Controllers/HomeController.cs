using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Forum.Models;

namespace Forum.Controllers {
    public class HomeController : Controller {

        ForumContext db = new ForumContext();
        /**
         * Thread Index returns index page
         * Set ViewBag => Thread with the list of all threads
         * */

        public ActionResult Index() {
            IEnumerable<Thread> threads = db.Threads;
            ViewBag.Thread = threads;
            return View();
        }

        /**
         * Thread method returns a thread page
         * Accepting as incoming parameters the next info:
         * @id as a thread ID
         * Set ViewBag => threadId with the current id to handle it in view
         * 
         * If no thread id passed to the method - returns index page
         * */
        [HttpGet]
        public ActionResult Thread(int? id) {
            if (id.HasValue) {
                ViewBag.ThreadId = id;
                return View();
            } else {
                return RedirectToAction("Index", "Home");
            }
            
        }

    }
}