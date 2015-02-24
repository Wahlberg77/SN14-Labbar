using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace Slumpade_Labb8.Models.Repository
{
    public class XmlRepository : IRepository
    {
        private static readonly string PhysicalPath;
        private XDocument _document;

        private XDocument Document //LazyLoad - Läs inte upp mer än vad man behöver. Vid behov.
        {
            get
            {
                return _document ?? (_document = XDocument.Load(PhysicalPath));
            }
        }

        static XmlRepository()
        {
            var dataDir = AppDomain.CurrentDomain.GetData("DataDirectory");
            PhysicalPath = Path.Combine(dataDir.ToString(), "contacts.xml");
        }

        public List<Kontakter> GetProducts()
        {
            //Hämta från Document
            var products = Document.Descendants("Kontakter")
                           .Select(element => new Kontakter
                           {
                               //Guid och Decimal.Parse används för att ändra från String till Decimal eller Guid. 
                               Fornamn = element.Element("FirstName").Value,
                               Efternamn = element.Element("LastName").Value,
                               Epost = element.Element("Email").Value,
                           }).OrderBy(p => p.Efternamn).ToList();

            return products;

        }

        public void AddProduct(Kontakter kontakt)
        {
            {
                var element = new XElement("contacts",
                new XElement("FirstName", kontakt.Fornamn),
                new XElement("Lastname", kontakt.Efternamn),
                new XElement("Email", kontakt.Epost));
                
                Document.Root.Add(element);
            }
        }

        public void Save()
        {
            Document.Save(PhysicalPath);
        }


        public Kontakter GetKontakt(Guid id)
        {
            return (from kontakt in Document.Descendants("Kontakt")
                    where Guid.Parse(kontakt.Attribute("Id").Value).Equals(id) //Kolla upp. Har jag något ID kvar? Guid?
                    select new Kontakter
                    {
                        Fornamn = kontakt.Element("FirstName").Value,
                        Efternamn = kontakt.Element("LastName").Value,
                        Epost = kontakt.Element("Email").Value,
                    })
              .FirstOrDefault();
        }

        public void UpdateProduct(Kontakter kontakt)
        {
            if (kontakt == null)
            {
                throw new ArgumentNullException("kontakt");
            }
            var element = Document.Descendants("Kontakter")
                   .Where(el => Guid.Parse(el.Attribute("Id").Value) == kontakt.KontakterId)
                   .FirstOrDefault();
            if (element != null)
            {
                element.Element("FirstName").Value = kontakt.Fornamn;
                element.Element("LastName").Value = kontakt.Efternamn;
                element.Element("Email").Value = kontakt.Epost;
            }
        }

        //Plockar bort produkten när den hittar det som matchar. 
        public void DeleteProduct(Kontakter kontakt)
        {
            var elementToDelete = Document.Descendants("Kontakter")
                .Where(element => Guid.Parse(element.Attribute("Id").Value) == kontakt.KontakterId)
                .FirstOrDefault();

            if (elementToDelete != null)
            {
                elementToDelete.Remove();
            }
        }
    }
}