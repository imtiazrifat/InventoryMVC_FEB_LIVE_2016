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
    public class ProductInventoryController : Controller
    {
        private INV_RIFEntities db = new INV_RIFEntities();

        // GET: /ProductInventory/
        public ActionResult Index()
        {
            var inv_productinventory = db.Inv_ProductInventory.Include(i => i.Inv_Orders);
            return View(inv_productinventory.ToList());
        }

        // GET: /ProductInventory/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Inv_ProductInventory inv_productinventory = db.Inv_ProductInventory.Find(id);
            if (inv_productinventory == null)
            {
                return HttpNotFound();
            }
            return View(inv_productinventory);
        }

        // GET: /ProductInventory/Create
        public ActionResult Create()
        {
            ViewBag.Inv_OrdersId = new SelectList(db.Inv_Orders, "Inv_OrdersId", "OrderDetails");
            return View();
        }

        // POST: /ProductInventory/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Inv_ProductInventoryId,Inv_OrdersId,Inv_ProductId,QuantityStock,AleartMinStock,InventoryDate,Note,CreatedDate,UpdateDate,IsActive,IsDeleted,CompanyId,UserId")] Inv_ProductInventory inv_productinventory)
        {
            if (ModelState.IsValid)
            {
                db.Inv_ProductInventory.Add(inv_productinventory);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Inv_OrdersId = new SelectList(db.Inv_Orders, "Inv_OrdersId", "OrderDetails", inv_productinventory.Inv_OrdersId);
            return View(inv_productinventory);
        }

        // GET: /ProductInventory/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Inv_ProductInventory inv_productinventory = db.Inv_ProductInventory.Find(id);
            if (inv_productinventory == null)
            {
                return HttpNotFound();
            }
            ViewBag.Inv_OrdersId = new SelectList(db.Inv_Orders, "Inv_OrdersId", "OrderDetails", inv_productinventory.Inv_OrdersId);
            return View(inv_productinventory);
        }

        // POST: /ProductInventory/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Inv_ProductInventoryId,Inv_OrdersId,Inv_ProductId,QuantityStock,AleartMinStock,InventoryDate,Note,CreatedDate,UpdateDate,IsActive,IsDeleted,CompanyId,UserId")] Inv_ProductInventory inv_productinventory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(inv_productinventory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Inv_OrdersId = new SelectList(db.Inv_Orders, "Inv_OrdersId", "OrderDetails", inv_productinventory.Inv_OrdersId);
            return View(inv_productinventory);
        }

        // GET: /ProductInventory/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Inv_ProductInventory inv_productinventory = db.Inv_ProductInventory.Find(id);
            if (inv_productinventory == null)
            {
                return HttpNotFound();
            }
            return View(inv_productinventory);
        }

        // POST: /ProductInventory/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Inv_ProductInventory inv_productinventory = db.Inv_ProductInventory.Find(id);
            db.Inv_ProductInventory.Remove(inv_productinventory);
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
