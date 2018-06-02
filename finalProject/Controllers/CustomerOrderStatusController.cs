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
    public class CustomerOrderStatusController : ApiController
    {

        // GET: OrderStatus
        [System.Web.Http.HttpGet]
        public IEnumerable<CustomerOrderStatus> StatusOrder()
        {
            List<CustomerOrderStatus> results = new List<CustomerOrderStatus>();
            Hashtable prms = new Hashtable();
            DataSet ds = DAL.GetData("sp_get_Customer_order_status", prms, "HomePageController.cs->getItemTable()");
            if (ds != null && ds.Tables.Count > 0)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    CustomerOrderStatus itemEntity = 
                    new CustomerOrderStatus(Int32.Parse(row["OrderId"].ToString()), Int32.Parse(row["OrderLine"].ToString()),
                    Int32.Parse(row["Quantity"].ToString()), decimal.Parse(row["Payment"].ToString()),
                    row["ProductName"].ToString(),
                    row["CustomerName"].ToString(),
                    row["DAY"].ToString(),
                    row["ShipTo"].ToString(),
                    row["PhoneContact"].ToString());

                    results.Add(itemEntity);
                    itemEntity = null;
                    GC.Collect();
                }
            }

            return results;
        }
    }
}