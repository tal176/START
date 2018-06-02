using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections;


namespace finalProject.Models
{
    public class CustomerOrderStatus
    {
        public int OrderId { get; set; }
        public int OrderLine { get; set; }
        public int Quantity { get; set; }
        public decimal Payment { get; set; }
        public string ProductName { get; set; }
        public string CustomerName { get; set; }
        public string DAY { get; set; }
        public string ShipTo { get; set; }
        public string PhoneContact { get; set; }
        
        public CustomerOrderStatus()
        {

        }


        public CustomerOrderStatus(int OrderId, int OrderLine, int Quantity, decimal Payment,
                           string ProductName, string CustomerName,
                           string DAY, string ShipTo, string PhoneContact)

        {
            this.OrderId = OrderId;
            this.OrderLine = OrderLine;
            this.Quantity = Quantity;
            this.Payment = Payment;
            this.ProductName = ProductName;
            this.CustomerName = CustomerName;
            this.DAY = DAY;
            this.ShipTo = ShipTo;
            this.PhoneContact = PhoneContact;

        }
    }
}