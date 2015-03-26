using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BibliotekLabb4.Models
{
    public class Lanabok
    {
        public int LanId { get; set; }
        public int BokId { get; set; }
        public int KundId { get; set; }
        public int KopiaId { get; set; }
        public string Titel { get; set; }
    }
}