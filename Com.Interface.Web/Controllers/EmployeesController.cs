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
    public class EmployeesController : Controller
    {
        private DataContext db = new DataContext();

        // GET: Employees
        public ActionResult Index()
        {
            var employees = db.Employees.Include(e => e.Email).Include(e => e.EmployeeGroup);
            return View(employees.ToList());
        }

        // GET: Employees/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // GET: Employees/Create
        public ActionResult Create()
        {
            ViewBag.EmailID = new SelectList(db.Emails, "EmailID", "Address");
            ViewBag.EmployeeGroupID = new SelectList(db.EmployeeGroups, "EmployeeGroupID", "Name");
            return View();
        }

        // POST: Employees/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,PremiseID,EmployeeGroupID,EmailID,FirstName,LastName,MiddleNames,Title,UserName,AccessFailedCount,LockoutEnabled,LockoutEndDate,Gender,BirthDate,StartDate,HiredDate,TerminationDate,JobTitle,EmployeeNumber,NationalInsuranceNumber,EmploymnentBasis,PaymentSchedule,CreatedDate,CreatedBy,ModifiedDate,ModifiedBy")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                db.Employees.Add(employee);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EmailID = new SelectList(db.Emails, "EmailID", "Address", employee.EmailID);
            ViewBag.EmployeeGroupID = new SelectList(db.EmployeeGroups, "EmployeeGroupID", "Name", employee.EmployeeGroupID);
            return View(employee);
        }

        // GET: Employees/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            ViewBag.EmailID = new SelectList(db.Emails, "EmailID", "Address", employee.EmailID);
            ViewBag.EmployeeGroupID = new SelectList(db.EmployeeGroups, "EmployeeGroupID", "Name", employee.EmployeeGroupID);
            return View(employee);
        }

        // POST: Employees/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,PremiseID,EmployeeGroupID,EmailID,FirstName,LastName,MiddleNames,Title,UserName,AccessFailedCount,LockoutEnabled,LockoutEndDate,Gender,BirthDate,StartDate,HiredDate,TerminationDate,JobTitle,EmployeeNumber,NationalInsuranceNumber,EmploymnentBasis,PaymentSchedule,CreatedDate,CreatedBy,ModifiedDate,ModifiedBy")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                db.Entry(employee).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EmailID = new SelectList(db.Emails, "EmailID", "Address", employee.EmailID);
            ViewBag.EmployeeGroupID = new SelectList(db.EmployeeGroups, "EmployeeGroupID", "Name", employee.EmployeeGroupID);
            return View(employee);
        }

        // GET: Employees/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            Employee employee = db.Employees.Find(id);
            db.Employees.Remove(employee);
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
