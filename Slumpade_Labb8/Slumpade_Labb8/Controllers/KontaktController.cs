using Slumpade_Labb8.Models;
using Slumpade_Labb8.Models.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Xml.Linq;

namespace Slumpade_Labb8.Controllers
{
    public class KontaktController : Controller
    {

                //Göra koden testbar, bra att alltid använda. Koda mot en abstraktion.     
        private IRepository _repository;

        public KontaktController()
            : this(new XmlRepository())
        {

        }

        //Mest för testning! 
        public KontaktController(IRepository repository)
        {
            _repository = repository;
        }

        // GET: Products
        public ActionResult Index()
        {
            return View(_repository.GetKontakt());
        }

        // GET: Kontakt / Skapa
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        //POST: Kontakt / Skapa
        [HttpPost]
        [ValidateAntiForgeryToken]
        //Bind för att skydda sig mot OverPost Attacks, dvs folk på externa sidor som matar in massa skit!
        public ActionResult Skapa([Bind(Include = "FirstName, LastName, Email")]Kontakter kontakt)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _repository.Skapa(kontakt);
                    _repository.Save();

                    TempData["success"] = "Kontakten sparad"; //Används för att ge användaren en bekräftelse på sparad produkt! Baka in med TryCatch sats.
                    return RedirectToAction("Index");
                }
            }
            catch (Exception)
            {

                TempData["error"] = "Misslyckades att skapa ny kontakt. Försök igen!";
            }
            return View(kontakt);
        }

        //GET: Metod för att plocka bort en produkt.
        [HttpGet]
        public ActionResult TaBort(Guid? id)
        {
            if (!id.HasValue)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
                        
            return View("Index");
        }

        [HttpGet]
        public ActionResult Editera(Guid? id)
        {
            if (!id.HasValue)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var kontakt = _repository.GetKontakt(id.Value);
            if (kontakt == null)
            {
                return HttpNotFound();
            }
            return View(kontakt);
        }

        //Skicka in den redigerade produkten och finns den ej skicka en 404 sida.
        [HttpPost, ActionName("Editera")]
        [ValidateAntiForgeryToken]
        public ActionResult Editera_POST(Guid id)
        {
            var kontaktAttUppdatera = _repository.GetKontakt(id);
            if (kontaktAttUppdatera == null)
            {
                return HttpNotFound();
            }
            //Skickar med egenskaperna som en sträng, uppdatera med nedan egenskaper och inga andra egenskaper än dem man anger. 
            //Gör man inte detta kan andra egenskaper förstöras då dem blir default om man inte gör enligt nedan. 
            if (TryUpdateModel(kontaktAttUppdatera, string.Empty, new string[] { "FirstName", "LastName", "Email" }))
            {
                try
                {
                    _repository.Uppdatera(kontaktAttUppdatera);
                    _repository.Save();
                    //När det är uppdaterat går vi tillbaka till vår Index sida!
                    TempData["success"] = String.Format("Uppdaterade kontakten {0}", kontaktAttUppdatera.Fornamn);
                    return RedirectToAction("Index");
                }
                catch (Exception)
                {
                    TempData["error"] = String.Format("Misslyckades att uppdatera {0}", kontaktAttUppdatera.Fornamn);
                }
            }
            return View(kontaktAttUppdatera);
        }

        //GET: Metod för att plocka bort en kontakt. 
        [HttpGet]
        public ActionResult TaBortKontakt(Guid? id)
        {
            if (!id.HasValue)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var kontakt = _repository.GetKontakt(id.Value);
            if (kontakt == null)
            {
                return HttpNotFound();
            }
            return View(kontakt);
        }

        //POST: Plocka bort!
        [HttpPost, ActionName ("TaBort")]
        [ValidateAntiForgeryToken]
        public ActionResult TaBortBekrafta(Guid id)
        {
            try
            {
                var kontakt = new Kontakter { KontakterId = id };
                _repository.TaBortKontakt(kontakt);
                _repository.Save();

                TempData["success"] = "Kontakten är borttagen";
            }

            catch (Exception)
            {
                TempData["error"] = "Misslyckades att ta bort kontakten";
                RedirectToAction("TaBort", new { id = id });//Ange id för att man vet vad som ska plockas bort. 
            }
            return RedirectToAction("Index");
        }
        
    }
}