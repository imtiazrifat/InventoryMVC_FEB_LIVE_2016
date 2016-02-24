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
    public class OrderProductController : Controller
    {
        private INV_RIFEntities db = new INV_RIFEntities();

        // GET: /OrderProduct/
        public ActionResult Index()
        {
            var inv_orderproduct = db.Inv_OrderProduct.Include(i => i.Inv_Orders).Include(i => i.Inv_Product);
            return View(inv_orderproduct.ToList());
        }

        // GET: /OrderProduct/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Inv_OrderProduct inv_orderproduct = db.Inv_OrderProduct.Find(id);
            if (inv_orderproduct == null)
            {
                return HttpNotFound();
            }
            return View(inv_orderproduct);
        }

        // GET: /OrderProduct/Create
        public ActionResult Create()
        {
            ViewBag.Inv_OrdersId = new SelectList(db.Inv_Orders, "Inv_OrdersId", "OrderDetails");
            ViewBag.Inv_ProductId = new SelectList(db.Inv_Product, "Inv_ProductId", "ProductName");
            return View();
        }

        // POST: /OrderProduct/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Inv_OrderProductId,Inv_OrdersId,Inv_ProductId,OrderQuantity,Note,CreatedDate,UpdateDate,IsActive,IsDeleted,CompanyId,UserId")] Inv_OrderProduct inv_orderproduct)
        {
            if (ModelState.IsValid)
            {
                db.Inv_OrderProduct.Add(inv_orderproduct);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Inv_OrdersId = new SelectList(db.Inv_Orders, "Inv_OrdersId", "OrderDetails", inv_orderproduct.Inv_OrdersId);
            ViewBag.Inv_ProductId = new SelectList(db.Inv_Product, "Inv_ProductId", "ProductName", inv_orderproduct.Inv_ProductId);
            return View(inv_orderproduct);
        }

        // GET: /OrderProduct/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Inv_OrderProduct inv_orderproduct = db.Inv_OrderProduct.Find(id);
            if (inv_orderproduct == null)
            {
                return HttpNotFound();
            }
            ViewBag.Inv_OrdersId = new SelectList(db.Inv_Orders, "Inv_OrdersId", "OrderDetails", inv_orderproduct.Inv_OrdersId);
            ViewBag.Inv_ProductId = new SelectList(db.Inv_Product, "Inv_ProductId", "ProductName", inv_orderproduct.Inv_ProductId);
            return View(inv_orderproduct);
        }

        // POST: /OrderProduct/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Inv_OrderProductId,Inv_OrdersId,Inv_ProductId,OrderQuantity,Note,CreatedDate,UpdateDate,IsActive,IsDeleted,CompanyId,UserId")] Inv_OrderProduct inv_orderproduct)
        {
            if (ModelState.IsValid)
            {
                db.Entry(inv_orderproduct).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Inv_OrdersId = new SelectList(db.Inv_Orders, "Inv_OrdersId", "OrderDetails", inv_orderproduct.Inv_OrdersId);
            ViewBag.Inv_ProductId = new SelectList(db.Inv_Product, "Inv_ProductId", "ProductName", inv_orderproduct.Inv_ProductId);
            return View(inv_orderproduct);
        }

        // GET: /OrderProduct/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Inv_OrderProduct inv_orderproduct = db.Inv_OrderProduct.Find(id);
            if (inv_orderproduct == null)
            {
                return HttpNotFound();
            }
            return View(inv_orderproduct);
        }

        // POST: /OrderProduct/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Inv_OrderProduct inv_orderproduct = db.Inv_OrderProduct.Find(id);
            db.Inv_OrderProduct.Remove(inv_orderproduct);
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
