using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections;

namespace finalProject.Models
{
    public class Vendor
    {
        
        public string VendorName { get; set; }
        public string VendorCompany { get; set; }
        public string VendorCountrey { get; set; }
        public string VendorType { get; set; }
        public string VendorPhone { get; set; }
        public string VendorMail { get; set; }
        public string Record { get; set; }

        public Vendor()
        {
        }

        public Vendor(string VendorName, string VendorCompany, string VendorCountrey, string VendorType, string VendorPhone, string VendorMail, string Record)
        {
            this.VendorName = VendorName;
            this.VendorCompany = VendorCompany;
            this.VendorCountrey = VendorCountrey;
            this.VendorType = VendorType;
            this.VendorPhone = VendorPhone;
            this.VendorMail = VendorMail;
            this.Record = Record;
        }
    }
}  






