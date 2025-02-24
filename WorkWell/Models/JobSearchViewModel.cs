using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WorkWell.Models
{
    public class JobSearchViewModel
    {
        public string Location { get; set; }
        public string Experience { get; set; }
        public string Skills { get; set; }

        // List of job vacancies to display
        public List<JobSearch> JobVacancies { get; set; }
    }
}