using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using rotelearn.Models;

namespace rotelearn.Controllers
{
    public class verbsController : Controller
    {
        private englishDBEntities db = new englishDBEntities();

        // GET: verbs
        public ActionResult Index()
        {
            return View(db.verbs.ToList());
        }

        // GET: verbs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            verb verb = db.verbs.Find(id);
            if (verb == null)
            {
                return HttpNotFound();
            }
            return View(verb);
        }

        // GET: verbs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: verbs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,verb1,verb_desc,verb_example,created_at,updated_at")] verb verb)
        {
            if (ModelState.IsValid)
            {
                db.verbs.Add(verb);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(verb);
        }

        // GET: verbs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            verb verb = db.verbs.Find(id);
            if (verb == null)
            {
                return HttpNotFound();
            }
            return View(verb);
        }

        // POST: verbs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,verb1,verb_desc,verb_example,created_at,updated_at")] verb verb)
        {
            if (ModelState.IsValid)
            {
                db.Entry(verb).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(verb);
        }

        // GET: verbs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            verb verb = db.verbs.Find(id);
            if (verb == null)
            {
                return HttpNotFound();
            }
            return View(verb);
        }

        // POST: verbs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            verb verb = db.verbs.Find(id);
            db.verbs.Remove(verb);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
