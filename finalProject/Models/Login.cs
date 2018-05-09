using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SPA.Models
{
    public class LoginToSystem
    {
        //init by constracot only
        public string NameContact { get; set; }
        public string UserName { get; set; }
        public string Company { get; set; }
        public string Pass { get; set; }
        public string Email { get; set; }
        public string Location { get; set; }
        public string Phone { get; set; }
        //can be updated


        public LoginToSystem(string NameContact, string UserName,string Company,string Pass, string Email, string Location, string Phone)
        {
            this.NameContact = NameContact;
            this.UserName = UserName;
            this.Company = Company;
            this.Pass = Pass;
            this.Email = Email;
            this.Location = Location;
            this.Phone = Phone;

        }

        public LoginToSystem()
        {

        }

    }
}


