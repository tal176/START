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
    public class VendorController : ApiController
    {

        //// Search: Vendor
        //[System.Web.Http.HttpGet]
        //public IEnumerable<Item> SearchItem()
        //{
        //    List<Item> results = new List<Item>();
        //    Hashtable prms = new Hashtable();
        //    DataSet ds = DAL.GetData("sp_get_Items", prms, "HomePageController.cs->getItemTable()");
        //    if (ds != null && ds.Tables.Count > 0)
        //    {
        //        foreach (DataRow row in ds.Tables[0].Rows)
        //        {
        //            Item itemEntity = new Item(row["CompanyName"].ToString(), Int32.Parse(row["ProductId"].ToString()),
        //            row["ProductName"].ToString(), Int32.Parse(row["Quantity"].ToString()),
        //            Int32.Parse(row["MinStock"].ToString()),
        //            row["DateLastInvit"].ToString(),
        //            Int32.Parse(row["ManufItemKey"].ToString()),
        //            row["CompanyOfTheManufcter"].ToString(),
        //            Int32.Parse(row["isAviable"].ToString()));

        //            results.Add(itemEntity);
        //            itemEntity = null;
        //            GC.Collect();
        //        }
        //    }

        //    return results;
        //}


        //// Set: Vendor
        //[System.Web.Http.HttpGet]
        //public IEnumerable<Error> AddItem(string CompanyName, int ProductId, string ProductName, int Quantity, int MinStock, int ManufItemKey, string CompanyOfTheManufcter)
        //{
        //    List<Error> results = new List<Error>();

        //    Hashtable prms = new Hashtable();
        //    prms.Add("CompanyName", CompanyName);
        //    prms.Add("ProductId", ProductId);
        //    prms.Add("ProductName", ProductName);
        //    prms.Add("Quantity", Quantity);
        //    prms.Add("MinStock", MinStock);
        //    prms.Add("ManufItemKey", ManufItemKey);
        //    prms.Add("CompanyOfTheManufcter", CompanyOfTheManufcter);

        //    Hashtable outputParams = new Hashtable();
        //    outputParams.Add("returnVal", "");

        //    DAL.RunBatch("Sp_add_product", prms, ref outputParams, SqlDbType.Int, "HomePageController.cs->AddItem()");
        //    if (outputParams.Count > 0)
        //    {
        //        foreach (DictionaryEntry item in outputParams)
        //        {
        //            Error err = new Error();
        //            switch (item.Value)
        //            {
        //                case 1:
        //                    err.ErrNumber = 1;
        //                    err.ErrMsg = "Duplication";
        //                    break;
        //                case 2:
        //                    err.ErrNumber = 2;
        //                    err.ErrMsg = "Item stock can`t be negative";
        //                    break;
        //                case 3:
        //                    err.ErrNumber = 3;
        //                    err.ErrMsg = "All done, new item in stock";
        //                    break;
        //            }
        //            results.Add(err);
        //        }

        //    }

        //    return results;
        //}

    }
}