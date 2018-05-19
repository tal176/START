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


        //Get Feedback
        [System.Web.Http.HttpGet]
        public IEnumerable<GetFeedbacks> GetFeedbackList()
        {



            List<GetFeedbacks> results = new List<GetFeedbacks>();
            Hashtable prms = new Hashtable();
            DataSet ds = DAL.GetData("Sp_get_feedback", prms, "HomePageController.cs->getItemTable()");
            if (ds != null && ds.Tables.Count > 0)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    GetFeedbacks feedbackEntity = new GetFeedbacks(row["CompanyName"].ToString(), row["CustomerName"].ToString(),
                    row["FeedbackDesc"].ToString(), row["dateToBE"].ToString(),
                    Int32.Parse(row["IsRegister"].ToString()),
                    row["typeIssue"].ToString(),
                    Int32.Parse(row["HadRead"].ToString()),
                    Int32.Parse(row["Istreated"].ToString()));
                   

                    results.Add(feedbackEntity);
                    feedbackEntity = null;
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





    }
    
}


