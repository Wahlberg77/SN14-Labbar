using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Beskriver olika metoder!

namespace Ange_fornamn_efternamn
{
    class Program
    {
        static void Main(string[] args)
        {

            string firstName;
            string lastName;
            string fullName;

            Console.Write("Ange förnamn: ");
            firstName = Console.ReadLine();

            Console.Write("Ange efternamn: ");
            lastName = Console.ReadLine();

            fullName = String.Format("{0} {1}", firstName, lastName);

            Console.WriteLine("Ditt fullständiga namn är: {0}", fullName);
        }
    }
}
