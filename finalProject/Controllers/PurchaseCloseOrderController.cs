using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Http;
using System.Data;
using System.Collections;
using SPA.Models;
using finalProject.Models;

namespace finalProject.Controllers
{
    public class PurchaseCloseOrderController : ApiController
    {
        [System.Web.Http.HttpGet]
        public IEnumerable<ClosePurchaseOrder> ClosePurchase()
        {
            List<ClosePurchaseOrder> results = new List<ClosePurchaseOrder>();
            Hashtable prms = new Hashtable();
            DataSet ds = DAL.GetData("sp_get_Close_Purchase_order_by_aggregtion_part_customer_vendor_yearly:monthly", prms, "sp_get_Close_Purchase_order_by_aggregtion_part_customer_vendor_yearly:monthly.cs->");
            if (ds != null && ds.Tables.Count > 0)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    ClosePurchaseOrder itemEntity = new ClosePurchaseOrder
                    (row["ProductName"].ToString(), Int32.Parse(row["Quantity"].ToString()),
                    decimal.Parse(row["payment"].ToString()),
                    row["VendorName"].ToString(),
                    row["ReturnOrderPurchaseOrder"].ToString(),
                    row["OpenClose"].ToString(),
                    row["Year"].ToString(),
                    row["Month"].ToString());


                    results.Add(itemEntity);
                    itemEntity = null;
                    GC.Collect();
                }
            }

            return results;
        }
    }
}