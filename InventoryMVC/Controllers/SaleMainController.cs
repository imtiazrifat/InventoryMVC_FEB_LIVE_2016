using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using InventoryMVC.Models.View_Model;
using Models;

namespace InventoryMVC.Controllers
{
    public class SaleMainController : Controller
    {
//this is sale main aaa
        private INV_RIFEntities db = new INV_RIFEntities();
        //
        // GET: /SaleMain/
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetProduct(string aProduct)
        {
            return View();
        }
        // GET: /SaleMain/SellProduct
        public ActionResult SellProduct(SaleMainVM aProduct)
        {
            try
            {
                Inv_Orders aOrders = new Inv_Orders
                {
                    OrderDate = aProduct.OrderDate,
                    TotalPrice = aProduct.TotalPrice,
                    Paid = aProduct.Paid,
                    Due = aProduct.Due,
                    DiscountAmount = aProduct.DiscountAmount,
                    DiscountPercent = aProduct.DiscountPercent,
                    Adjustment = aProduct.Adjustment,
                    TotalUnit = aProduct.TotalUnit,
                    CreatedDate = aProduct.CreatedDate,
                    UpdateDate = aProduct.UpdateDate,

                    IsActive = aProduct.IsActive,
                    IsDeleted = aProduct.IsDeleted,
                    UserId = aProduct.UserId
                };
                var save = db.Inv_Orders.Add(aOrders);
                //db.SaveChanges();


                foreach (var aOP in aProduct.OrderProducts)
                {
                    Inv_OrderProduct aInvOrderProduct = new Inv_OrderProduct
                    {
                        Inv_OrdersId = aOrders.Inv_OrdersId,
                        Inv_ProductId = aOP.Inv_ProductId,
                        CreatedDate = aProduct.CreatedDate,
                        UpdateDate = aProduct.UpdateDate,

                        IsActive = aProduct.IsActive,
                        IsDeleted = aProduct.IsDeleted,
                        UserId = aProduct.UserId
                    };
                    db.Inv_OrderProduct.Add(aInvOrderProduct);
                }
                db.SaveChanges();
                return View();
            }
            catch (Exception ex)
            {
                
                throw;
            }
        }



    }
}