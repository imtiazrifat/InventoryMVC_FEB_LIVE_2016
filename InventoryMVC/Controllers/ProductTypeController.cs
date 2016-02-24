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
    public class ProductTypeController : Controller
    {
        private INV_RIFEntities db = new INV_RIFEntities();

        // GET: /ProductType/
        public ActionResult Index()
        {
            return View(db.Inv_ProductType.ToList());
        }

        // GET: /ProductType/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Inv_ProductType inv_producttype = db.Inv_ProductType.Find(id);
           
            if (inv_producttype == null)
            {
                return HttpNotFound();
            }
            return View(inv_producttype);
        }

        // GET: /ProductType/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /ProductType/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Inv_ProductTypeId,ProductTypeName,ProductTypeCode,Note,CreatedDate,UpdateDate,IsActive,IsDeleted,UserId")] Inv_ProductType inv_producttype)
        {
            if (ModelState.IsValid)
            {
                db.Inv_ProductType.Add(inv_producttype);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(inv_producttype);
        }

        // GET: /ProductType/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Inv_ProductType inv_producttype = db.Inv_ProductType.Find(id);
            if (inv_producttype == null)
            {
                return HttpNotFound();
            }
            return View(inv_producttype);
        }

        // POST: /ProductType/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Inv_ProductTypeId,ProductTypeName,ProductTypeCode,Note,CreatedDate,UpdateDate,IsActive,IsDeleted,UserId")] Inv_ProductType inv_producttype)
        {
            if (ModelState.IsValid)
            {
                db.Entry(inv_producttype).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(inv_producttype);
        }

        // GET: /ProductType/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Inv_ProductType inv_producttype = db.Inv_ProductType.Find(id);
            if (inv_producttype == null)
            {
                return HttpNotFound();
            }
            return View(inv_producttype);
        }

        // POST: /ProductType/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Inv_ProductType inv_producttype = db.Inv_ProductType.Find(id);
            db.Inv_ProductType.Remove(inv_producttype);
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
