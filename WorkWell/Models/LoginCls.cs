using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WorkWell.Models
{
    public class LoginCls
    {
        [Required(ErrorMessage = "enter the Username")]
        public string Uname { set; get; }
        [Required(ErrorMessage = "enter the password")]
        public string pass { set; get; }
        public string msg { set; get; }
        public string utype { set; get; }
    }
}