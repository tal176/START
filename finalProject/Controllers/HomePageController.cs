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
    public class HomePageController : ApiController
    {
        //[System.Web.Http.HttpGet]
        //public IEnumerable<bool> LoginToSystem(String USER)
        //{
        //    DataSet tmp = DAL.GetData("select * from UserSign WHERE userName='" + USER + "'", "");
           
        //    List<Login> newUser = new List<Login>();
        //    if (tmp != null && tmp.Tables != null && tmp.Tables.Count > 0)
        //    {
        //        //User identified
        //        //newUser = tmp.Tables[0].AsEnumerable().Select(row => new Login()
        //        //{
        //        //    UserName = row.Field<string>("UserName"),
        //        //    Pass = row.Field<string>("Pass"),
        //        //}).ToList();
        //    }
        //    return newUser;
        //}

        [System.Web.Http.HttpGet]
        public IEnumerable<Customer> SearchCustomers()
        {
            List<Customer> results = new List<Customer>();
            Hashtable prms = new Hashtable();
            DataSet ds = DAL.GetData("sp_getCustomers", prms, "HomePageController.cs->getCustomersTable()");
            if(ds!=null && ds.Tables.Count>0)
            {
                foreach(DataRow row in ds.Tables[0].Rows)
                {
                    Customer cust = new Customer(Int32.Parse(row["CustomerId"].ToString()), row["CompanyName"].ToString(), row["CustomerName"].ToString(), row["AgentName"].ToString(), 
                        row["StreetAdress"].ToString(),
                        row["City"].ToString(), row["Phonework"].ToString(), Int32.Parse(row["DateLastInvitedYear"].ToString()), Int32.Parse(row["DateLastInvitedMonth"].ToString()),
                        Int32.Parse(row["DateLastInvitedDay"].ToString()), row["phone"].ToString(),Int32.Parse(row["CanSee"].ToString()));

                    results.Add(cust);
                    cust = null;
                    GC.Collect();
                }
            }

            return results;
        }

        [System.Web.Http.HttpGet]
        public IEnumerable<Error> Register(string NameContact, string UserName, string Company, string Pass, string Email, string Location, string Phone)
        {
            List<Error> results = new List<Error>();

            Hashtable prms = new Hashtable();
            prms.Add("NameContact", NameContact);
            prms.Add("UserName", UserName);
            prms.Add("Company", Company);
            prms.Add("Pass", Pass);
            prms.Add("Email", Email);
            prms.Add("Location", Location);
            prms.Add("Phone", Phone);

            Hashtable outputParams = new Hashtable();
            outputParams.Add("returnVal", "");

            DAL.RunBatch("Sp_register_to_system", prms, ref outputParams, SqlDbType.Int, "HomePageController.cs->Register()");
            if (outputParams.Count > 0)
            {
                foreach (DictionaryEntry item in outputParams)
                {
                    Error err = new Error();
                    switch (item.Value)
                    {
                        case 1:
                            err.ErrNumber = 1;
                            err.ErrMsg = "OK";
                            break;
                        case 2:
                            err.ErrNumber = 2;
                            err.ErrMsg = "Duplication";
                            break;
                        case 3:
                            err.ErrNumber = 3;
                            err.ErrMsg = "Other Error";
                            break;
                    }

                    results.Add(err);
                }
            }

            return results;
        }



        [System.Web.Http.HttpGet]
        public IEnumerable<Error> AddItem(string CompanyName, int ProductId, string ProductName, int Quantity, int MinStock, int ManufItemKey, string CompanyOfTheManufcter)
        {
            List<Error> results = new List<Error>();

            Hashtable prms = new Hashtable();
            prms.Add("CompanyName", CompanyName);
            prms.Add("ProductId", ProductId);
            prms.Add("ProductName", ProductName);
            prms.Add("Quantity", Quantity);
            prms.Add("MinStock", MinStock);
            prms.Add("ManufItemKey", ManufItemKey);
            prms.Add("CompanyOfTheManufcter", CompanyOfTheManufcter);

            Hashtable outputParams = new Hashtable();
            outputParams.Add("returnVal", "");

            DAL.RunBatch("Sp_add_product", prms, ref outputParams, SqlDbType.Int, "HomePageController.cs->AddItem()");
            if (outputParams.Count > 0)
            {
                foreach (DictionaryEntry item in outputParams)
                {
                    Error err = new Error();
                    switch (item.Value)
                    {
                        case 1:
                            err.ErrNumber = 1;
                            err.ErrMsg = "Insert confirm";
                            break;
                        case 2:
                            err.ErrNumber = 2;
                            err.ErrMsg = "Duplication";
                            break;
                        case 3:
                            err.ErrNumber = 3;
                            err.ErrMsg = "Item stock can`t be negative";
                            break;
                        case 4:
                            err.ErrNumber = 4;
                            err.ErrMsg = "Connection Issue";
                            break;
                    }
                    results.Add(err);
                }

            }

            return results;
        }


        //[System.Web.Http.HttpGet]
        //public IEnumerable<Error> CUsotmerOrder(string Orderid, string CompanyName, int Quantity, string ProductName, string CustomerName, string ShipTo, string PhoneContact, string SupposedToArrive)
        //{
        //    List<Error> results = new List<Error>();

        //    Hashtable prms = new Hashtable();
        //    prms.Add("Orderid", Orderid);
        //    prms.Add("CompanyName", CompanyName);
        //    prms.Add("Quantity", Quantity);
        //    prms.Add("ProductName", ProductName);
        //    prms.Add("CustomerName", CustomerName);
        //    prms.Add("ShipTo", ShipTo);
        //    prms.Add("PhoneContact", PhoneContact);
        //    prms.Add("SupposedToArrive", SupposedToArrive);

        //    Hashtable outputParams = new Hashtable();
        //    outputParams.Add("returnVal", "");

        //    DAL.RunBatch("Sp_create_customer_order", prms, ref outputParams, SqlDbType.Int, "HomePageController.cs->CUsotmerOrder()");
        //    if (outputParams.Count > 0)
        //    {
        //        foreach (DictionaryEntry item in outputParams)
        //        {
        //            Error err = new Error();
        //            switch (item.Value)
        //            {
        //                case 1:
        //                    err.ErrNumber = 1;
        //                    err.ErrMsg = "Order already exist";
        //                    break;
        //                case 2:
        //                    err.ErrNumber = 2;
        //                    err.ErrMsg = "Line number already exist for spesfic order";
        //                    break;
        //                case 3:
        //                    err.ErrNumber = 3;
        //                    err.ErrMsg = "Stock is not aviable";
        //                    break;
        //                case 4:
        //                    err.ErrNumber = 4;
        //                    err.ErrMsg = "Not enoght quantity, return quantity that avaible";
        //                    break;
        //                case 5:
        //                    err.ErrNumber = 4;
        //                    err.ErrMsg = "Connection Issue";
        //                    break;
        //            }


        //            results.Add(err);
        //        }

        //    }

        //    return results;
        //}


    }
    
}


