using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections;

namespace finalProject.Models
{

        public class GetFeedbacks
        {
            public string CompanyName { get; set; }
            public string CustomerName { get; set; }
            public string FeedbackDesc { get; set; }
            public string dateToBE { get; set; }
            public int IsRegister { get; set; }
            public string typeIssue { get; set; }
            public int HadRead { get; set; }
            public int Istreated { get; set; }

            public GetFeedbacks()
            {

            }


            public GetFeedbacks(string CompanyName, string CustomerName, string FeedbackDesc, string dateToBE, int IsRegister,
                        string typeIssue, int HadRead, int Istreated)
            {
                this.CompanyName = CompanyName;
                this.CustomerName = CustomerName;
                this.FeedbackDesc = FeedbackDesc;
                this.dateToBE = dateToBE;
                this.IsRegister = IsRegister;
                this.typeIssue = typeIssue;
                this.HadRead = HadRead;
                this.Istreated = Istreated;
            }
        }

    
}