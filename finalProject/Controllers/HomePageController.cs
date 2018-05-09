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
   
        [System.Web.Http.HttpGet]
        //Get some data??
        public IEnumerable<LoginToSystem> GetSomeData()
        {
            DataSet tmp = DAL.GetData("select * from UserSign", "");
            Hashtable prms = new Hashtable();
            List<LoginToSystem> newUser = new List<LoginToSystem>();
            if (tmp != null && tmp.Tables != null && tmp.Tables.Count > 0)
            {
                newUser = tmp.Tables[0].AsEnumerable().Select(row => new LoginToSystem()
                {
                    NameContact = row.Field<string>("NameContact"),
                    UserName = row.Field<string>("UserName"),
                    Company = row.Field<string>("Company"),
                    Pass = row.Field<string>("Pass"),
                    Email = row.Field<string>("Email"),
                    Location = row.Field<string>("Location"),
                    Phone = row.Field<string>("Phone"),
                }).ToList();
            }

            return newUser;
        }

        [System.Web.Http.HttpGet]
        //Get some data??
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

            DAL.RunBatch("Sp_register_to_system", prms,ref outputParams,SqlDbType.Int, "HomePageController.cs->Register()");
            if(outputParams.Count>0)
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
    }
    
}


