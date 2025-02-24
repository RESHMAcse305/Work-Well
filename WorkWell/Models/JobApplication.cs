using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WorkWell.Models
{
    public class JobApplication
    {
       
        public int UserId { get; set; }
        public int CompanyId { get; set; }
        public int JobId { get; set; }
        
        public string resume { get; set; }
        public string Applied_date { get; set; }

        public string applymsg { get; set; }
    }
}