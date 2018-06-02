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

        // Search: Vendor
        [System.Web.Http.HttpGet]
        public IEnumerable<Vendor> SearchVendors()
        {
            List<Vendor> results = new List<Vendor>();
            Hashtable prms = new Hashtable();
            DataSet ds = DAL.GetData("sp_get_Vendors", prms, "HomePageController.cs->SearchVendors()");
            if (ds != null && ds.Tables.Count > 0)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    Vendor VendorEntity = new Vendor(row["VendorName"].ToString(), row["VendorCompany"].ToString(), row["VendorCountrey"].ToString(),
                    row["VendorType"].ToString(), row["VendorPhone"].ToString(), row["VendorMail"].ToString(), row["Record"].ToString());

                    results.Add(VendorEntity);
                    VendorEntity = null;
                    GC.Collect();
                }
            }

            return results;
        }


        // Set: Vendor
        [System.Web.Http.HttpGet]
        public IEnumerable<Error> AddVendor(string VendorName, string VendorCountrey, string VendorType, string VendorPhone, string VendorMail)
        {
            List<Error> results = new List<Error>();

            Hashtable prms = new Hashtable();
            prms.Add("VendorName", VendorName);
            prms.Add("VendorCountrey", VendorCountrey);
            prms.Add("VendorType", VendorType);
            prms.Add("VendorPhone", VendorPhone);
            prms.Add("VendorMail", VendorMail);

            Hashtable outputParams = new Hashtable();
            outputParams.Add("returnVal", "");

            DAL.RunBatch("Sp_add_new_Vendor", prms, ref outputParams, SqlDbType.Int, "HomePageController.cs->AddVendor()");
            if (outputParams.Count > 0)
            {
                foreach (DictionaryEntry item in outputParams)
                {
                    Error err = new Error();
                    switch (item.Value)
                    {
                        case 1:
                            err.ErrNumber = 1;
                            err.ErrMsg = "Vendor already exist";
                            break;
                        case 2:
                            err.ErrNumber = 2;
                            err.ErrMsg = "All done, new vendor in your site";
                            break;
                    }
                    results.Add(err);
                }

            }

            return results;
        }


        // Set: Comment
        [System.Web.Http.HttpGet]
        public IEnumerable<Error> AddRecordVendor(string VendorName, string VendorCountrey, string VendorType, int CustomerRating)
        {
            List<Error> results = new List<Error>();

            Hashtable prms = new Hashtable();
            prms.Add("VendorName", VendorName);
            prms.Add("VendorCountrey", VendorCountrey);
            prms.Add("VendorType", VendorType);
            prms.Add("CustomerRating", CustomerRating);

            Hashtable outputParams = new Hashtable();
            outputParams.Add("returnVal", "");

            DAL.RunBatch("Sp_Rating_Vendors", prms, ref outputParams, SqlDbType.Int, "HomePageController.cs->AddRecordVendor()");
            if (outputParams.Count > 0)
            {
                foreach (DictionaryEntry item in outputParams)
                {
                    Error err = new Error();
                    switch (item.Value)
                    {
                        case 1:
                            err.ErrNumber = 1;
                            err.ErrMsg = "Vendor record can`t be negative";
                            break;
                        case 2:
                            err.ErrNumber = 2;
                            err.ErrMsg = "All done, new record for vendor";
                            break;
                    }
                    results.Add(err);
                }

            }

            return results;
        }

    }
}