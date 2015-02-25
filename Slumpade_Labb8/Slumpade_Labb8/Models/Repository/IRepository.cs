using Slumpade_Labb8.Models;
using System;
using System.Collections.Generic;

namespace Slumpade_Labb8
{
    public interface IRepository
    {
        List<Kontakter> GetKontakt();
        Kontakter GetKontakt(Guid id);
        void Skapa(Kontakter kontakt);
        void Uppdatera(Kontakter kontakt);
        void TaBort(Kontakter kontakt);
        void Spara();
        List<Kontakter> GetSenasteKontakten(int count = 20);
    }
}
