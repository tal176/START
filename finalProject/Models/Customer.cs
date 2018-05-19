using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections;

namespace finalProject.Models
{
    public class Customer
    {
        public int CustomerId { get;set; }
        public string CompanyName { get; set; }
        public string CustomerName { get; set; }
        public string StreetAdress { get; set; }
        public string City { get; set; }
        public string Phonework { get; set; }
        public string DateLastInvited { get; set; }
        public string Email { get; set; }

        public Customer()
        {

        }
        public Customer(int CustomerId, string CompanyName, string CustomerName,  string StreetAdress, string City, 
            string Phonework,string DateLastInvited, string Email)

        {
            this.CustomerId = CustomerId;
            this.CompanyName = CompanyName;
            this.CustomerName = CustomerName;
            this.StreetAdress = StreetAdress;
            this.City = City;
            this.Phonework = Phonework;
            this.DateLastInvited = DateLastInvited;
            this.Email = Email;
        }
    }
}