using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SPA.Models
{
    public class Login
    {
        public string UserName { get; set; }
        public string Pass { get; set; }

        public Login( string UserName,string Pass)
        {
            this.UserName = UserName;
            this.Pass = Pass;
        }

        public Login()
        {

        }

    }
}


