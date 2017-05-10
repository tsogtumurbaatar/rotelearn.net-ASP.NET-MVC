using rotelearn.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;

namespace rotelearn.Controllers
{
    public class HomeController : Controller
    {
        private englishDBEntities db = new englishDBEntities();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Whatis()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult List(string currentFilter, string searchString, int? page)
        {
            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }
            ViewBag.CurrentFilter = searchString;

            var verbs = from verb in db.verbs
                        select verb;

            if (!String.IsNullOrEmpty(searchString))
            {
                verbs = verbs.Where(s => s.verb1.Contains(searchString)
                                   || s.verb_desc.Contains(searchString)
                                   || s.verb_example.Contains(searchString));
            }

            verbs = verbs.OrderBy(s => s.id);

            int pageSize = 30;
            int pageNumber = (page ?? 1);
            return View(verbs.ToPagedList(pageNumber, pageSize));
        }
    }
}