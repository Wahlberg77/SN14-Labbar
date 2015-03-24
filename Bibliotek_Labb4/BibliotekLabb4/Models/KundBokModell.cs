using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BibliotekLabb4.Models
{
    public class KundBokModell
    {
        public string Titel { get; set; }
        public DateTime LaneDatum { get; set; }
        public DateTime? LamnasTillbaka { get; set; }
        public int BokId { get; set; }

    }
}