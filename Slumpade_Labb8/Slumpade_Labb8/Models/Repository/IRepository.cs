using Slumpade_Labb8.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slumpade_Labb8
{
    interface IRepository
    {
        List<Kontakter> GetKontakt();
        Kontakter GetKontakt(Guid id);
        void Skapa(Kontakter kontakt);
        void Uppdatera(Kontakter kontakt);
        void TaBort(Kontakter kontakt);
        void Save();
    }
}
