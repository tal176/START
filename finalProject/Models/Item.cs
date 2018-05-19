using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections;

namespace finalProject.Models
{
    public class Item
    {
        public string CompanyName { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public int MinStock { get; set; }
        public string DateLastInvit { get; set; }
        public int ManufItemKey { get; set; }
        public string CompanyOfTheManufcter { get; set; }
        public int isAviable { get; set; }


        public Item()
        {

        }


        public Item(string CompanyName, int ProductId, string ProductName, int Quantity, int MinStock,
                    string DateLastInvit, int ManufItemKey, string CompanyOfTheManufcter,
                    int isAviable )
        {
            this.CompanyName = CompanyName;
            this.ProductId = ProductId;
            this.ProductName = ProductName;
            this.Quantity = Quantity;
            this.MinStock = MinStock;
            this.DateLastInvit = DateLastInvit;
            this.ManufItemKey = ManufItemKey;
            this.CompanyOfTheManufcter = CompanyOfTheManufcter;
            this.isAviable = isAviable;
        }
    }
}