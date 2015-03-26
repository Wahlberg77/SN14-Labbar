using Bibliotek;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Xml.Linq;
using System.Threading.Tasks;
using BibliotekLabb4.Models;

namespace BibliotekLabb4.Controllers
{
    public class KontaktController : Controller
    {
        // GET: Hämta Kund
        [HttpGet]
        public ActionResult Index()
        {
            IList<KundVyModell> kunderMedLan;
            using (var ctx = new BibliotekDbEntities1())
            {
                var LanPerKund = from k in ctx.Kunds
                                 join l in ctx.Lans on k.KundId equals l.KundId
                                 where l.LamnasTillbaka.HasValue
                                 group k by k.KundId into Grp
                                 select new { key = Grp.Key, Count = Grp.Count() };

                kunderMedLan = (from k in ctx.Kunds
                                join lk in LanPerKund on k.KundId equals lk.key into lks
                                from lk in lks.DefaultIfEmpty()
                                select new KundVyModell { KundId = k.KundId, 
                                                          ForNamn = k.ForNamn, 
                                                          EfterNamn = k.EfterNamn, 
                                                          MobilTelefon = k.MobilTelefon, 
                                                          Epost = k.Epost, 
                                                          AntalLan = lk == null ? 0 : lk.Count })
                                    .ToList();
            }
            return View(kunderMedLan);
        }

        //GET: Editera Kund
        [HttpGet]
        public ActionResult Edit(int id)
        {
            KundVyModell kund;
            using (var ctx = new BibliotekDbEntities1())
            {
                var KundBocker = (from l in ctx.Lans
                                  join k in ctx.Kopias on l.KopiaId equals k.KopiaId
                                  join b in ctx.Boks on k.BokId equals b.BokId
                                  where !l.LamnasTillbaka.HasValue && l.KundId == id
                                  select new KundBokModell
                                  {
                                      BokId = b.BokId,
                                      Titel = b.Titel,
                                      LaneDatum = l.LaneDatum, //Hantera felet i en VY!
                                      LamnasTillbaka = l.LamnasTillbaka.Value
                                  })
                                  .ToList();
                kund = (from k in ctx.Kunds
                        where k.KundId == id
                        select new KundVyModell
                            {
                                KundId = k.KundId,
                                ForNamn = k.ForNamn,
                                EfterNamn = k.EfterNamn,
                                MobilTelefon = k.MobilTelefon,
                                Epost = k.Epost
                            })
                                .FirstOrDefault();

                if (kund != null)
                {
                    kund.Bocker = KundBocker;
                }
            }
            return View(kund);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            KundTaBortModell delete;

            using (var ctx = new BibliotekDbEntities1())
            {
                var harLan = (from l in ctx.Lans
                              join k in ctx.Kopias on l.KopiaId equals k.KopiaId
                              where l.KundId == id && k.Status > 1
                              select l).Any();
                delete = (from k in ctx.Kunds
                          where k.KundId == id
                          select new KundTaBortModell
                          {
                              KundId = k.KundId,
                              ForNamn = k.ForNamn,
                              EfterNamn = k.EfterNamn,
                              HarLan = harLan
                          }).FirstOrDefault();

            }
            return View(delete);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirm(int id)
        {
            try
            {
                using (var ctx = new BibliotekDbEntities1())
                {
                    var harLan = (from l in ctx.Lans
                                  join k in ctx.Kopias on l.KopiaId equals k.KopiaId
                                  where l.KundId == id && k.Status > 1
                                  select l).Any();
                    if (harLan)
                    {
                        throw new InvalidOperationException();
                    }
                    ctx.DeleteKund(id);
                }
            }
            catch (Exception)
            {
                TempData["error"] = "Misslyckades att ta bort kunden, den har ett aktivt lån.";
                RedirectToAction("Delete", new { id = id });
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Lana(int id)
        {
            IList<Lanabok> lanaBok;
            using (var ctx = new BibliotekDbEntities1())
            {
                //var LanadBok = from k in ctx.Kunds
                //               join p in ctx.Kopias on k.KundId equals p.

                lanaBok = (from l in ctx.Lans
                           join p in ctx.Kopias on l.KopiaId equals p.KopiaId
                           join k in ctx.Kunds on l.KundId equals k.KundId
                           join b in ctx.Boks on p.BokId equals b.BokId
                           where k.KundId == id && p.KopiaId == id
                           select new Lanabok
                           {
                               Titel = b.Titel
                           }).ToList();

            }
            return View(lanaBok);
        }

        [HttpPost, ActionName("Lana")]
        public ActionResult LanaConfirmed(int id)
        {
            try
            {
               using (var ctx = new BibliotekDbEntities1())
               {
                   //var LanadBok = from l in ctx.Lans
                   //                join p in ctx.Kopias on l.KopiaId equals p.KopiaId
                   //                where l.LanId == id & l.LanId != p.KopiaId select 1)
                   //                .Any();

                   //if (LanadBok)
                   //{
                   //    throw new InvalidOperationException();
                   //}
                   //ctx.usp_Utlaning(id);
               }

            }
            catch (Exception)
            {
                TempData["error"] = "Misslyckades att Lana bok";
                RedirectToAction("LanaBok", new { id = id });
            }

            return RedirectToAction("Index");
        }




        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirm(int id)
        //{
        //    KundTaBortModell deleteConfirm;

        //    using (var ctx = new BibliotekDbEntities1())



        // }


        // GET: Kontakt / Skapa
        //[HttpGet]
        //public ActionResult Skapa()
        //{
        //    return View();
        //}

        //POST: Kontakt / Skapa
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        ////Bind för att skydda sig mot OverPost Attacks, dvs folk på externa sidor som matar in massa skit!
        //public ActionResult Skapa([Bind(Include = "Fornamn, Efternamn, Epost")]Kontakter kontakt)
        //{
        //    try
        //    {
        //        if (ModelState.IsValid)
        //        {
        //            _repository.Skapa(kontakt);
        //            _repository.Spara();

        //            TempData["success"] = "Kontakten sparad"; //Används för att ge användaren en bekräftelse på sparad produkt! Baka in med TryCatch sats.
        //            return RedirectToAction("Index");
        //        }
        //    }
        //    catch (Exception)
        //    {

        //        TempData["error"] = "Misslyckades att skapa ny kontakt. Försök igen!";
        //    }
        //    return View(kontakt);
        //}

        //[HttpGet]
        //public ActionResult Editera(Guid? id)
        //{
        //    if (!id.HasValue)
        //    {
        //        throw new HttpException(404, "Du begärde ett oglitigt GUID");
        //    }

        //    var kontakt = _repository.GetKontakt(id.Value);
        //    if (kontakt == null)
        //    {
        //        throw new HttpException(404, "Kontakten du begärde finns inte eller har just blivit borttagen");
        //    }
        //    return View(kontakt);
        //}

        //Skicka in den redigerade produkten och finns den ej skicka en 404 sida.
        //[HttpPost, ActionName("Editera")]
        //[ValidateAntiForgeryToken]
        //public ActionResult Uppdatera(Guid id)
        //{
        //    var kontaktAttUppdatera = _repository.GetKontakt(id);
        //    if (kontaktAttUppdatera == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    //Skickar med egenskaperna som en sträng, uppdatera med nedan egenskaper och inga andra egenskaper än dem man anger. 
        //    //Gör man inte detta kan andra egenskaper förstöras då dem blir default om man inte gör enligt nedan. 
        //    if (TryUpdateModel(kontaktAttUppdatera, string.Empty, new string[] { "Fornamn", "Efternamn", "Epost" }))
        //    {
        //        try
        //        {
        //            _repository.Uppdatera(kontaktAttUppdatera);
        //            _repository.Spara();
        //            //När det är uppdaterat går vi tillbaka till vår Index sida!
        //            TempData["success"] = String.Format("Uppdaterade kontakten {0}", kontaktAttUppdatera.Fornamn, kontaktAttUppdatera.Efternamn);
        //            return RedirectToAction("Index");
        //        }
        //        catch (Exception)
        //        {
        //            TempData["error"] = String.Format("Misslyckades att uppdatera {0}", kontaktAttUppdatera.Fornamn, kontaktAttUppdatera.Efternamn);
        //        }
        //    }
        //    return View(kontaktAttUppdatera);
        //}

        ////GET: Metod för att plocka bort en kontakt. 
        //[HttpGet]
        //public ActionResult TaBort(Guid? id)
        //{
        //    if (!id.HasValue)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }

        //    var kontakt = _repository.GetKontakt(id.Value);
        //    if (kontakt == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(kontakt);
        //}

        ////POST: Plocka bort!
        //[HttpPost, ActionName("TaBort")]
        //[ValidateAntiForgeryToken]
        //public ActionResult TaBortBekrafta(Guid id)
        //{
        //    try
        //    {
        //        var kontakt = new Kontakter { KontakterId = id };
        //        _repository.TaBort(kontakt);
        //        _repository.Spara();

        //        TempData["success"] = "Kontakten är borttagen";
        //    }

        //    catch (Exception)
        //    {
        //        TempData["error"] = "Misslyckades att ta bort kontakten";
        //        RedirectToAction("TaBort", new { id = id });//Ange id för att man vet vad som ska plockas bort. 
        //    }
        //    return RedirectToAction("Index");
        //}
    }
}