using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Com.Framework.Data;
using Com.Framework.DataAccess;

namespace Com.Interface.Web.Controllers
{
    public class PremisesController : Controller
    {
        private DataContext db = new DataContext();

        // GET: Premises
        public ActionResult Index()
        {
            return View(db.Premises.ToList());
        }

        // GET: Premises/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Premise premise = db.Premises.Find(id);
            if (premise == null)
            {
                return HttpNotFound();
            }
            return View(premise);
        }

        // GET: Premises/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Premises/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,OrganisationID,Name,Description,Url,CountryCode,Currency,ApiKey,Rating,ReviewRating,CreatedDate,CreatedBy,ModifiedDate,ModifiedBy")] Premise premise)
        {
            if (ModelState.IsValid)
            {
                db.Premises.Add(premise);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(premise);
        }

        // GET: Premises/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Premise premise = db.Premises.Find(id);
            if (premise == null)
            {
                return HttpNotFound();
            }
            return View(premise);
        }

        // POST: Premises/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,OrganisationID,Name,Description,Url,CountryCode,Currency,ApiKey,Rating,ReviewRating,CreatedDate,CreatedBy,ModifiedDate,ModifiedBy")] Premise premise)
        {
            if (ModelState.IsValid)
            {
                db.Entry(premise).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(premise);
        }

        // GET: Premises/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Premise premise = db.Premises.Find(id);
            if (premise == null)
            {
                return HttpNotFound();
            }
            return View(premise);
        }

        // POST: Premises/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            Premise premise = db.Premises.Find(id);
            db.Premises.Remove(premise);
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
