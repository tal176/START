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

        public string AgentName { get; set; }
        public string StreetAdress { get; set; }
        public string City { get; set; }
        public string Phonework { get; set; }
        public int? DateLastInvitedYear { get; set; }
        public int? DateLastInvitedMonth { get; set; }
        public int? DateLastInvitedDay { get; set; }
        public string phone { get; set; }
        public int? CanSee { get; set; }

        public Customer()
        {

        }
        public Customer(int CustomerId, string CompanyName, string CustomerName, string AgentName, string StreetAdress, string City, string Phonework,int? DateLastInvitedYear,
            int? DateLastInvitedMonth, int? DateLastInvitedDay, string phone, int? CanSee)
        {
            this.CustomerId = CustomerId;
            this.CompanyName = CompanyName;
            this.CustomerName = CustomerName;
            this.AgentName = AgentName;
            this.StreetAdress = StreetAdress;
            this.City = City;
            this.Phonework = Phonework;
            this.DateLastInvitedYear = DateLastInvitedYear;
            this.DateLastInvitedMonth = DateLastInvitedMonth;
            this.DateLastInvitedDay = DateLastInvitedDay;
            this.phone = phone;
            this.CanSee = CanSee;
        }
    }
}