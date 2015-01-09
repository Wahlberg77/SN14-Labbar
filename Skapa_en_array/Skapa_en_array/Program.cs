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
            //========================================================
            //==================== Skapa en Array ====================
            //========================================================

            int[] temperatur = new int[] { 17, -65, -20, 9, 42 };

            //Räknar ut summan för alla element
            int sum = 0;
            for (int i = 0; i < temperatur.Length; i++)
                sum = sum + temperatur[i];

            Console.WriteLine("Medeltemperaturen är: " + sum / temperatur.Length);
        }
    }
}
