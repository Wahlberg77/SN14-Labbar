using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BibliotekLabb4.Models
{
    public class KundTaBortModell
    {
        public string  ForNamn { get; set; }
        public string EfterNamn { get; set; }
        public bool HarLan { get; set; }
        public int KundId { get; set; }
    }
}