using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WorkWell.Models
{
    public class CompanyInsert
    {
        [Required(ErrorMessage ="enter the name")]
        public string cname { set; get; }
        [Required(ErrorMessage = "enter the name")]
        public string cadd { set; get; }
        [Required(ErrorMessage = "phone no required")]
        [RegularExpression(@"^(\d{10})$",ErrorMessage ="enter valid number")]
        public string cphone { set; get; }
        [EmailAddress(ErrorMessage ="ener a valid email id")]
        public string cemail { set; get; }
        [Required(ErrorMessage = "enter the uname")]
        public string username { set; get; }
        public string pass { set; get; }
        [Compare("pass",ErrorMessage ="password mismatch")]
        public string cpass { set; get; }
        public string admsg { set; get; }
    }
}