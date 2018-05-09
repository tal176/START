using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace finalProject.Models
{
    public class Error
    {
        public int ErrNumber { get; set; }
        public string ErrMsg { get; set; }

        public Error(int ErrNumber,string ErrMsg)
        {

        }

        public Error()
        {

        }
    }
}