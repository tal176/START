using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections;



namespace finalProject.Models
{
    public class ClosePurchaseOrder
    {
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public decimal payment { get; set; }
        public string VendorName { get; set; }
        public string ReturnOrderPurchaseOrder { get; set; }
        public string OpenClose { get; set; }
        public string Year { get; set; }
        public string Month { get; set; }

        public ClosePurchaseOrder()
        {

        }


        public ClosePurchaseOrder(string ProductName, int Quantity, decimal payment, string VendorName, 
                                  string ReturnOrderPurchaseOrder, string OpenClose,
                                  string Year, string Month)


        {
            this.ProductName = ProductName;
            this.Quantity = Quantity;
            this.payment = payment;
            this.VendorName = VendorName;
            this.ReturnOrderPurchaseOrder = ReturnOrderPurchaseOrder;
            this.OpenClose = OpenClose;
            this.Year = Year;
            this.Month = Month;
        }
    }
}