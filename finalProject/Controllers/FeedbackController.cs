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
    public class FeedbackController : ApiController
    {
        //CustomerFeedback
        [System.Web.Http.HttpGet]
        public IEnumerable<Error> CustomerFeedback(string CompanyName, string CustomerName, string typeIssue, string FeedbackDesc)
        {
            List<Error> results = new List<Error>();

            Hashtable prms = new Hashtable();
            prms.Add("CompanyName", CompanyName);
            prms.Add("CustomerName", CustomerName);
            prms.Add("typeIssue", typeIssue);
            prms.Add("FeedbackDesc", FeedbackDesc);


            Hashtable outputParams = new Hashtable();
            outputParams.Add("returnVal", "");

            DAL.RunBatch("Sp_create_customer_Feedback", prms, ref outputParams, SqlDbType.Int, "HomePageController.cs->CustomerFeedback()");
            if (outputParams.Count > 0)
            {
                foreach (DictionaryEntry item in outputParams)
                {
                    Error err = new Error();
                    switch (item.Value)
                    {
                        case 1:
                            err.ErrNumber = 0;
                            err.ErrMsg = "New feedback created";
                            break;
                    }
                    results.Add(err);
                }

            }

            return results;
        }
    }
}