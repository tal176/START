using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections;

namespace finalProject.Models
{
    public class OpenPurchaseOrder
    {
        public int PurchaseOrderId { get; set; }
        public int OrderLine { get; set; }
        public int Quantity { get; set; }
        public decimal Payment { get; set; }
        public string ProductName { get; set; }
        public string VendorName { get; set; }
        public string ShipTo { get; set; }
        public string PhoneContact { get; set; }
        public string SupposedToArrive { get; set; }
        public string ReturnOrderPurchaseOrder { get; set; }
        public string OpenClose { get; set; }
        public string Year { get; set; }
        public string Quarter { get; set; }


        public OpenPurchaseOrder()
        {

        }


        public OpenPurchaseOrder(int PurchaseOrderId, int OrderLine, int Quantity, decimal Payment, string ProductName, string VendorName,
                    string ShipTo, string PhoneContact, string SupposedToArrive,
                    string ReturnOrderPurchaseOrder, string OpenClose, string Year,
                    string Quarter)

        {
            this.PurchaseOrderId = PurchaseOrderId;
            this.OrderLine = OrderLine;
            this.Quantity = Quantity;
            this.Payment = Payment;
            this.ProductName = ProductName;
            this.VendorName = VendorName;
            this.ShipTo = ShipTo;
            this.PhoneContact = PhoneContact;
            this.SupposedToArrive = SupposedToArrive;
            this.ReturnOrderPurchaseOrder = ReturnOrderPurchaseOrder;
            this.OpenClose = OpenClose;
            this.Year = Year;
            this.Quarter = Quarter;
        }
    }
}