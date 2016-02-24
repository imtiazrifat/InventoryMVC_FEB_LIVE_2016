using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Models;

namespace InventoryMVC.Controllers
{
    public class CustomerController : Controller
    {
        private INV_RIFEntities db = new INV_RIFEntities();

        // GET: /Customer/
        public ActionResult Index()
        {
            return View(db.Inv_Customer.ToList());
        }

        // GET: /Customer/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Inv_Customer inv_customer = db.Inv_Customer.Find(id);
            if (inv_customer == null)
            {
                return HttpNotFound();
            }
            return View(inv_customer);
        }

        // GET: /Customer/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Customer/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Inv_CustomerId,CustomerName,CustomerMobile,CustomerAddress,CustomerDetails,Note,CreatedDate,UpdateDate,IsActive,IsDeleted,CompanyId,UserId")] Inv_Customer inv_customer)
        {
            if (ModelState.IsValid)
            {
                db.Inv_Customer.Add(inv_customer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(inv_customer);
        }

        // GET: /Customer/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Inv_Customer inv_customer = db.Inv_Customer.Find(id);
            if (inv_customer == null)
            {
                return HttpNotFound();
            }
            return View(inv_customer);
        }

        // POST: /Customer/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Inv_CustomerId,CustomerName,CustomerMobile,CustomerAddress,CustomerDetails,Note,CreatedDate,UpdateDate,IsActive,IsDeleted,CompanyId,UserId")] Inv_Customer inv_customer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(inv_customer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(inv_customer);
        }

        // GET: /Customer/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Inv_Customer inv_customer = db.Inv_Customer.Find(id);
            if (inv_customer == null)
            {
                return HttpNotFound();
            }
            return View(inv_customer);
        }

        // POST: /Customer/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Inv_Customer inv_customer = db.Inv_Customer.Find(id);
            db.Inv_Customer.Remove(inv_customer);
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
