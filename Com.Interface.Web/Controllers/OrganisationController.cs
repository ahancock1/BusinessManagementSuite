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
    public class OrganisationController : Controller
    {
        private DataContext db = new DataContext();

        // GET: Organisation
        public ActionResult Index()
        {
            var organisations = db.Organisations.Include(o => o.Image);
            return View(organisations.ToList());
        }

        // GET: Organisation/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Organisation organisation = db.Organisations.Find(id);
            if (organisation == null)
            {
                return HttpNotFound();
            }
            return View(organisation);
        }

        // GET: Organisation/Create
        public ActionResult Create()
        {
            ViewBag.ImageID = new SelectList(db.Images, "ImageID", "ImageID");
            return View();
        }

        // POST: Organisation/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,ImageID,Name,LegalName,Code,PaysTax,OrganisationType,ApiKey,OrganisationStatus,OrganisationCategory,TaxNumber,FinancialYearEndDay,FinancialYearEndMonth,CountryCode,CreatedDate,CreatedBy,ModifiedDate,ModifiedBy")] Organisation organisation)
        {
            if (ModelState.IsValid)
            {
                db.Organisations.Add(organisation);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ImageID = new SelectList(db.Images, "ImageID", "ImageID", organisation.ImageID);
            return View(organisation);
        }

        // GET: Organisation/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Organisation organisation = db.Organisations.Find(id);
            if (organisation == null)
            {
                return HttpNotFound();
            }
            ViewBag.ImageID = new SelectList(db.Images, "ImageID", "ImageID", organisation.ImageID);
            return View(organisation);
        }

        // POST: Organisation/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,ImageID,Name,LegalName,Code,PaysTax,OrganisationType,ApiKey,OrganisationStatus,OrganisationCategory,TaxNumber,FinancialYearEndDay,FinancialYearEndMonth,CountryCode,CreatedDate,CreatedBy,ModifiedDate,ModifiedBy")] Organisation organisation)
        {
            if (ModelState.IsValid)
            {
                db.Entry(organisation).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ImageID = new SelectList(db.Images, "ImageID", "ImageID", organisation.ImageID);
            return View(organisation);
        }

        // GET: Organisation/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Organisation organisation = db.Organisations.Find(id);
            if (organisation == null)
            {
                return HttpNotFound();
            }
            return View(organisation);
        }

        // POST: Organisation/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            Organisation organisation = db.Organisations.Find(id);
            db.Organisations.Remove(organisation);
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
