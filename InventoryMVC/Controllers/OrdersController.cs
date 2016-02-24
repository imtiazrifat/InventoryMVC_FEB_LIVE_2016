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
    public class OrdersController : Controller
    {
        private INV_RIFEntities db = new INV_RIFEntities();

        // GET: /Orders/
        public ActionResult Index()
        {
            var inv_orders = db.Inv_Orders.Include(i => i.Inv_Customer);
            return View(inv_orders.ToList());
        }

        // GET: /Orders/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Inv_Orders inv_orders = db.Inv_Orders.Find(id);
            if (inv_orders == null)
            {
                return HttpNotFound();
            }
            return View(inv_orders);
        }

        // GET: /Orders/Create
        public ActionResult Create()
        {
            ViewBag.Inv_CustomerId = new SelectList(db.Inv_Customer, "Inv_CustomerId", "CustomerName");
            return View();
        }

        // POST: /Orders/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Inv_OrdersId,Inv_CustomerId,OrderDate,OrderDetails,TotalUnit,TotalPrice,Paid,Due,DiscountPercent,DiscountAmount,Adjustment,UnitofMeasurementCode,Note,CreatedDate,UpdateDate,IsActive,IsDeleted,CompanyId,UserId")] Inv_Orders inv_orders)
        {
            if (ModelState.IsValid)
            {
                db.Inv_Orders.Add(inv_orders);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Inv_CustomerId = new SelectList(db.Inv_Customer, "Inv_CustomerId", "CustomerName", inv_orders.Inv_CustomerId);
            return View(inv_orders);
        }

        // GET: /Orders/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Inv_Orders inv_orders = db.Inv_Orders.Find(id);
            if (inv_orders == null)
            {
                return HttpNotFound();
            }
            ViewBag.Inv_CustomerId = new SelectList(db.Inv_Customer, "Inv_CustomerId", "CustomerName", inv_orders.Inv_CustomerId);
            return View(inv_orders);
        }

        // POST: /Orders/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Inv_OrdersId,Inv_CustomerId,OrderDate,OrderDetails,TotalUnit,TotalPrice,Paid,Due,DiscountPercent,DiscountAmount,Adjustment,UnitofMeasurementCode,Note,CreatedDate,UpdateDate,IsActive,IsDeleted,CompanyId,UserId")] Inv_Orders inv_orders)
        {
            if (ModelState.IsValid)
            {
                db.Entry(inv_orders).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Inv_CustomerId = new SelectList(db.Inv_Customer, "Inv_CustomerId", "CustomerName", inv_orders.Inv_CustomerId);
            return View(inv_orders);
        }

        // GET: /Orders/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Inv_Orders inv_orders = db.Inv_Orders.Find(id);
            if (inv_orders == null)
            {
                return HttpNotFound();
            }
            return View(inv_orders);
        }

        // POST: /Orders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Inv_Orders inv_orders = db.Inv_Orders.Find(id);
            db.Inv_Orders.Remove(inv_orders);
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
