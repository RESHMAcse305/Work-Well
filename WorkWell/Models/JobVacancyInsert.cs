using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WorkWell.Models
{
    public class JobVacancyInsert
    {
        public int cId { get; set; }
        [Required(ErrorMessage ="JobTitle is required")]
        public string jtitle { get; set; }
        [Required(ErrorMessage = "required description")]
        public string des { get; set; }
        [Required(ErrorMessage = "EXPERIENCE is required")]
        public string exp { get; set; }
        [Required(ErrorMessage = "skills is required")]
        public string skills { get; set; }
        
        [Required(ErrorMessage = "jobtype is required")]
        public string jtype { set; get; }
        [Required(ErrorMessage = "Location is required")]
        public string location { set; get; }
        [Required(ErrorMessage = "SALARY is required")]
        public string salary { get; set; }
        public string cdate { set; get; }
        public string status { get; set; }
        public string jobmsg { set; get; }
    }
}