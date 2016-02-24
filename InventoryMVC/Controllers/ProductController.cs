using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using Models;
using Newtonsoft.Json;

namespace InventoryMVC.Controllers
{
    public class ProductController : Controller
    {
        private INV_RIFEntities db = new INV_RIFEntities();

        // GET: /Product/
        public ActionResult Index()
        {
            var inv_product = db.Inv_Product.Include(i => i.Inv_ProductType);
            return View(inv_product.ToList());
        }

        // GET: /Product/GetAllProducts
        public ActionResult GetAllProducts()
        
        {
          return View();
        }

        // GET: /Product/GetAllProductsData
        public JsonResult GetAllProductsData()
        {
            db.Configuration.LazyLoadingEnabled = false;
            var inv_product = db.Inv_Product.Include(i => i.Inv_ProductType);

            var data = inv_product.Select(i => new { i.ProductName, i.ProductCode, i.ProductDetails, i.BuyPrice, i.SellPrice, i.Note,i.Inv_ProductId }).ToList();
           
             return Json(new { data = data }, JsonRequestBehavior.AllowGet);
           
        }

        // GET: /Product/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Inv_Product inv_product = db.Inv_Product.Find(id);
            if (inv_product == null)
            {
                return HttpNotFound();
            }
            return View(inv_product);
        }

        // GET: /Product/Create
        public ActionResult Create()
        {
            ViewBag.Inv_ProductTypeId = new SelectList(db.Inv_ProductType, "Inv_ProductTypeId", "ProductTypeName");
            return View();
        }

        // POST: /Product/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Inv_ProductId,Inv_ProductTypeId,ProductName,ProductCode,ProductDetails,BuyPrice,SellPrice,Tax,Note,CreatedDate,UpdateDate,IsActive,IsDeleted,CompanyId,UserId")] Inv_Product inv_product)
        {
            if (ModelState.IsValid)
            {
                db.Inv_Product.Add(inv_product);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Inv_ProductTypeId = new SelectList(db.Inv_ProductType, "Inv_ProductTypeId", "ProductTypeName", inv_product.Inv_ProductTypeId);
            return View(inv_product);
        }

        // GET: /Product/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Inv_Product inv_product = db.Inv_Product.Find(id);
            if (inv_product == null)
            {
                return HttpNotFound();
            }
            ViewBag.Inv_ProductTypeId = new SelectList(db.Inv_ProductType, "Inv_ProductTypeId", "ProductTypeName", inv_product.Inv_ProductTypeId);
            return View(inv_product);
        }

        // POST: /Product/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Inv_ProductId,Inv_ProductTypeId,ProductName,ProductCode,ProductDetails,BuyPrice,SellPrice,Tax,Note,CreatedDate,UpdateDate,IsActive,IsDeleted,CompanyId,UserId")] Inv_Product inv_product)
        {
            if (ModelState.IsValid)
            {
                db.Entry(inv_product).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Inv_ProductTypeId = new SelectList(db.Inv_ProductType, "Inv_ProductTypeId", "ProductTypeName", inv_product.Inv_ProductTypeId);
            return View(inv_product);
        }

        // GET: /Product/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Inv_Product inv_product = db.Inv_Product.Find(id);
            if (inv_product == null)
            {
                return HttpNotFound();
            }
            return View(inv_product);
        }

        // POST: /Product/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Inv_Product inv_product = db.Inv_Product.Find(id);
            db.Inv_Product.Remove(inv_product);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: /Product/search/5
        public ActionResult Search(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Inv_Product inv_product = db.Inv_Product.Find(id);
            if (inv_product == null)
            {
                return HttpNotFound();
            }
            var list = JsonConvert.SerializeObject(inv_product,
    Formatting.None,
    new JsonSerializerSettings()
    {
        ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
    });

            return Content(list, "application/json");

            return Json(inv_product, JsonRequestBehavior.AllowGet);
            string json = JsonConvert.SerializeObject(inv_product);
            return Json(json);
            return Json(new { foo = "bar", baz = "Blech" });
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
