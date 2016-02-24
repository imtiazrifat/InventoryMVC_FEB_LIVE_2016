using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Models;

namespace InventoryMVC.Models.View_Model
{
    public class SaleMainVM:Inv_Orders
    {

        public List<Inv_OrderProduct> OrderProducts { get; set; }
    }
}