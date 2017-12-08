using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using NWEmployee.DAL;
using NWEmployee.Models;

namespace NWEmployee.Controllers
{
    public class Potential_CustomersController : Controller
    {
        private NorthwestContext db = new NorthwestContext();

        // GET: Potential_Customers
        public ActionResult Index()
        {
            return View(db.p_customers.ToList());
        }

        // GET: Potential_Customers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Potential_Customers potential_Customers = db.p_customers.Find(id);
            if (potential_Customers == null)
            {
                return HttpNotFound();
            }
            return View(potential_Customers);
        }

        // GET: Potential_Customers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Potential_Customers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "potentialID,companyName,ContactName,contactPhone,contactEmail,notes")] Potential_Customers potential_Customers)
        {
            if (ModelState.IsValid)
            {
                db.p_customers.Add(potential_Customers);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(potential_Customers);
        }

        // GET: Potential_Customers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Potential_Customers potential_Customers = db.p_customers.Find(id);
            if (potential_Customers == null)
            {
                return HttpNotFound();
            }
            return View(potential_Customers);
        }

        // POST: Potential_Customers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "potentialID,companyName,ContactName,contactPhone,contactEmail,notes")] Potential_Customers potential_Customers)
        {
            if (ModelState.IsValid)
            {
                db.Entry(potential_Customers).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(potential_Customers);
        }

        // GET: Potential_Customers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Potential_Customers potential_Customers = db.p_customers.Find(id);
            if (potential_Customers == null)
            {
                return HttpNotFound();
            }
            return View(potential_Customers);
        }

        // POST: Potential_Customers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Potential_Customers potential_Customers = db.p_customers.Find(id);
            db.p_customers.Remove(potential_Customers);
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
