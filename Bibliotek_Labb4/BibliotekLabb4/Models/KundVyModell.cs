using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BibliotekLabb4.Models
{
    public class KundVyModell
    {
        public string ForNamn { get; set; }
        public string EfterNamn { get; set; }
        public string MobilTelefon { get; set; }
        public string Epost { get; set; }
        public int AntalLan { get; set; }
        public int KundId { get; set; }

        public IList<KundBokModell> Bocker { get; set; }
    }
}