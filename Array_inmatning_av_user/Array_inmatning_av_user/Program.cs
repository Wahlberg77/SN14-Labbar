using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_projekt
{
    class Program
    {
        static void Main(string[] args)
        {
            //=====================================================================================
            //==================== Skapa en Array med inmatning från användaren====================
            //=====================================================================================

            Console.WriteLine("Ange antal temperaturer som du har mätt upp: ");
            string str = Console.ReadLine();
            int size = Convert.ToInt32(str);


            //Skapa Arrayen (Vectorn)
            int[] temperatur = new int[size];

            //Tilldela Array elements olika värden via for-loop:
            for (int i = 0; i < temperatur.Length; i++)
            {
                //Läs in värdet och gör om det till heltal
                Console.Write("Ange temperatur " + i + ": ");
                str = Console.ReadLine(); //Återanvänd variablen str!
                int element = Convert.ToInt32(str);
                //Lägg in värdet i Arrayen på index i
                temperatur[i] = element;
            }

            //Räknar ut summan för alla element
            int sum = 0;
            for (int i = 0; i < temperatur.Length; i++)
                sum = sum + temperatur[i];

            Console.WriteLine("Summan för alla element är: " + sum / temperatur.Length);
        }
    }
}
