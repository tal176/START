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
        public string VendorCountrey { get; set; }
        public string VendorType { get; set; }
        public string VendorPhone { get; set; }
        public string VendorMail { get; set; }
        public int Record { get; set; }

        public Vendor()
        {
        }

        public Vendor(string VendorName, string VendorCountrey, string VendorType, string VendorPhone, string VendorMail,
                    int Record)
        {
            this.VendorName = VendorName;
            this.VendorCountrey = VendorCountrey;
            this.VendorType = VendorType;
            this.VendorPhone = VendorPhone;
            this.VendorMail = VendorMail;
            this.Record = Record;
        }
    }
}  






