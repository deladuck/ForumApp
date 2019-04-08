using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Forum.Models;

namespace Forum.Controllers {
    public class HomeController : Controller {

        ForumContext db = new ForumContext();

        public ActionResult Index() {
            IEnumerable<Thread> threads = db.Threads;
            ViewBag.Thread = threads;
            return View();
        }

        /**
         * Thread method returns a thread page
         * Accepting as incoming paramethers the next info:
         * @id as a thread ID
         * Set ViewBag => threadId with the current id to handle it in view
         * If matches - returing partial view with edited comment
         * */
        [HttpGet]
        public ActionResult Thread(int id) {
            ViewBag.ThreadId = id;
            return View();
        }

    }
}