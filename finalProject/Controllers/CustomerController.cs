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
    public class CustomerController : ApiController
    {
        // Search: Customer
        [System.Web.Http.HttpGet]
        public IEnumerable<Customer> SearchCustomers()
        {
            List<Customer> results = new List<Customer>();
            Hashtable prms = new Hashtable();
            DataSet ds = DAL.GetData("sp_getCustomers", prms, "HomePageController.cs->getCustomersTable()");
            if (ds != null && ds.Tables.Count > 0)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    Customer cust = new Customer(Int32.Parse(row["CustomerId"].ToString()), row["CompanyName"].ToString(), 
                        row["CustomerName"].ToString(), row["StreetAdress"].ToString(),
                        row["City"].ToString(), row["Phonework"].ToString(), 
                        row["DateLastInvited"].ToString(), 
                        row["Email"].ToString());

                    results.Add(cust);
                    cust = null;
                    GC.Collect();
                }
            }

            return results;
        }


        //CustomerOrder
        [System.Web.Http.HttpGet]
        public IEnumerable<Error> CusotmerOrder(string Orderid, string CompanyName, int Quantity, string ProductName, string CustomerName, string ShipTo, string PhoneContact, string SupposedToArrive)
        {
            List<Error> results = new List<Error>();

            Hashtable prms = new Hashtable();
            prms.Add("Orderid", Orderid);
            prms.Add("CompanyName", CompanyName);
            prms.Add("Quantity", Quantity);
            prms.Add("ProductName", ProductName);
            prms.Add("CustomerName", CustomerName);
            prms.Add("ShipTo", ShipTo);
            prms.Add("PhoneContact", PhoneContact);
            prms.Add("SupposedToArrive", SupposedToArrive);

            Hashtable outputParams = new Hashtable();
            outputParams.Add("returnVal", "");

            DAL.RunBatch("Sp_create_customer_order", prms, ref outputParams, SqlDbType.Int, "HomePageController.cs->CUsotmerOrder()");
            if (outputParams.Count > 0)
            {
                foreach (DictionaryEntry item in outputParams)
                {
                    Error err = new Error();
                    switch (item.Value)
                    {
                        case 1:
                            err.ErrNumber = 1;
                            err.ErrMsg = "Stock is not aviable";
                            break;
                        case 2:
                            err.ErrNumber = 2;
                            err.ErrMsg = "Not enoght quantity";
                            break;
                        case 3:
                            err.ErrNumber = 3;
                            err.ErrMsg = "New order complite";
                            break;
                    }
                    results.Add(err);
                }

            }

            return results;
        }

     
        // Set:Customer
        [System.Web.Http.HttpGet]
        public IEnumerable<Error> AddCustomer(string CompanyName, string CustomerName, string StreetAdress, string City, string Phonework, string Email)
        {
            List<Error> results = new List<Error>();

            Hashtable prms = new Hashtable();
            prms.Add("CompanyName", CompanyName);
            prms.Add("CustomerName", CustomerName);
            prms.Add("StreetAdress", StreetAdress);
            prms.Add("City", City);
            prms.Add("Phonework", Phonework);
            prms.Add("Email", Email);

            Hashtable outputParams = new Hashtable();
            outputParams.Add("returnVal", "");

            DAL.RunBatch("Sp_add_new_customer", prms, ref outputParams, SqlDbType.Int, "HomePageController.cs->AddCustomer()");
            if (outputParams.Count > 0)
            {
                foreach (DictionaryEntry item in outputParams)
                {
                    Error err = new Error();
                    switch (item.Value)
                    {
                        case 1:
                            err.ErrNumber = 1;
                            err.ErrMsg = "Customer already exist";
                            break;
                        case 2:
                            err.ErrNumber = 2;
                            err.ErrMsg = "All done, new Customer in your site";
                            break;
                    }
                    results.Add(err);
                }

            }

            return results;
        }


    }
}