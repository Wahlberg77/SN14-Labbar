//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Bibliotek
{
    using System;
    using System.Collections.Generic;
    
    public partial class Bok
    {
        public Bok()
        {
            this.Kopias = new HashSet<Kopia>();
        }
    
        public int BokId { get; set; }
        public int Forfattare { get; set; }
        public string Titel { get; set; }
        public System.DateTime Publicerades { get; set; }
        public string Genre { get; set; }
        public string Sprak { get; set; }
        public string ISBN { get; set; }
    
        public virtual Forfattare Forfattare1 { get; set; }
        public virtual ICollection<Kopia> Kopias { get; set; }
    }
}