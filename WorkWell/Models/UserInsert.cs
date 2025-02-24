using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WorkWell.Models
{
    public class UserInsert
    {
        public int uid { set; get; }
        [Required(ErrorMessage = "enter the name")]
        public string name { set; get; }
        [Range(18,60,ErrorMessage ="age must be in the given limit")]
        public int age { set; get; }
        [Required(ErrorMessage = "Address required")]
        public string add { set; get; }
        [Required(ErrorMessage = "phone no required")]
        [RegularExpression(@"^(\d{10})$", ErrorMessage = "enter valid number")]
        public string phone { set; get; }
        [EmailAddress(ErrorMessage = "ener a valid email id")]
        public string email { set; get; }
        [Range(0,20,ErrorMessage = "enter the experience in years")]
        public string exp { set; get; }
        [Required(ErrorMessage = "enter the skills")]
        public string skills { set; get; }
        public string resume { set; get; }
        [Required(ErrorMessage = "enter the birthdate")]
        public string dob { set; get; }
        public string photo { set; get; }
        [Required(ErrorMessage = "enter the uname")]
        public string username { set; get; }
        public string pass { set; get; }
        [Compare("pass", ErrorMessage = "password mismatch")]
        public string cpass { set; get; }
        public string Usermsg { set; get; }

    }
}