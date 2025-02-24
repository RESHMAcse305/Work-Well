using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace WorkWell.Models
{
    public class JobSearch
    {
        public int jobid { get; set; }
        public int cid { get; set; }
        public string jtitle { get; set; }
        public string desc { get; set; }
        public string exp { set; get; }
        public  string skills { set; get; }
        public string location { set; get; }
        public string sal { get; set; }
        public string closedate { get; set; }
        public string jobmsg { get; set; }
    }

}