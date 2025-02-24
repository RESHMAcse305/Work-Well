using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WorkWell.Models
{
    public class DetailsSearch
    {
       
        public string Skills { get; set; }
        public string Experience { get; set; }
        public string Location { get; set; }
        public List<JobSearch> JobSearchDetails { get; set; }
    }
}