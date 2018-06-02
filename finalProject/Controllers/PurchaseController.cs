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
    public class PurchaseController : ApiController
    {



       [System.Web.Http.HttpGet]
        public IEnumerable<OpenPurchaseOrder> OpenPurchase()
        {
            List<OpenPurchaseOrder> results = new List<OpenPurchaseOrder>();
            Hashtable prms = new Hashtable();
            DataSet ds = DAL.GetData("sp_get_Open_Purchase_order_by_quarter", prms, "HomePageController.cs->sp_get_Open_Purchase_order_by_quarter()");
            if (ds != null && ds.Tables.Count > 0)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    OpenPurchaseOrder itemEntity = new OpenPurchaseOrder
                    (Int32.Parse(row["PurchaseOrderId"].ToString()), Int32.Parse(row["OrderLine"].ToString()),
                    Int32.Parse(row["Quantity"].ToString()),
                    decimal.Parse(row["Payment"].ToString()),
                    row["ProductName"].ToString(),
                    row["VendorName"].ToString(),
                    row["ShipTo"].ToString(),
                    row["PhoneContact"].ToString(),
                    row["SupposedToArrive"].ToString(),
                    row["ReturnOrderPurchaseOrder"].ToString(),
                    row["OpenClose"].ToString(),
                    row["Year"].ToString(),
                    row["Quarter"].ToString());

                    results.Add(itemEntity);
                    itemEntity = null;
                    GC.Collect();
                }
            }

            return results;
        }



        // Set: PurchaseOrder
        [System.Web.Http.HttpGet]
        public IEnumerable<Error> AddPurchaseOrder(int purhcaseOrderId, string CompanyName, 
           int Quantity, string ProductName, string VendorName, string VendorCountrey,string ShipTo, string PhoneContact,
           string Reason)
        {
            List<Error> results = new List<Error>();
            Hashtable prms = new Hashtable();
            prms.Add("purhcaseOrderId", purhcaseOrderId);
            prms.Add("CompanyName", CompanyName);
            prms.Add("Quantity", Quantity);
            prms.Add("Payment", Quantity);
            prms.Add("ProductName", ProductName);
            prms.Add("VendorName", VendorName);
            prms.Add("VendorCountrey", VendorCountrey);
            prms.Add("ShipTo", ShipTo);
            prms.Add("PhoneContact", PhoneContact);
            prms.Add("Reason", Reason); 

            Hashtable outputParams = new Hashtable();
            outputParams.Add("returnVal", "");

            DAL.RunBatch("Sp_create_purchase_order", prms, ref outputParams, SqlDbType.Int, "HomePageController.cs->Sp_create_purchase_order()");
            if (outputParams.Count > 0)
            {
                foreach (DictionaryEntry item in outputParams)
                {
                    Error err = new Error();
                    switch (item.Value)
                    {
                        case 1:
                            err.ErrNumber = 1;
                            err.ErrMsg = "New purchase order has been created ";
                            break;
                        case 2:
                            err.ErrNumber = 2;
                            err.ErrMsg = "Connection problem";
                            break;
                    }
                    results.Add(err);
                }

            }

            return results;
        }



    }



}



