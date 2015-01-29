using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solida_Volymer_Niva_A
{
    enum SolidType { CircularCone, Cylinder }

    class Program
    {
        static void Main(string[] args)
        {

        }

        private static Solid CreateSolid(SolidType solidType)
        {

        }

        private static double ReadDoubleGreaterThanZero(string prompt)
        {

        }

        private static void ViewMenu()
        {
            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("╔══════════════════════════════════════════════════════╗");
            Console.WriteLine("║                                                      ║");
            Console.WriteLine("║                   Solida Volymer                     ║");
            Console.WriteLine("║                                                      ║");
            Console.WriteLine("╚══════════════════════════════════════════════════════╝");
            Console.ResetColor();
            Console.WriteLine();
            Console.WriteLine("0. Avsluta.\n");
            Console.WriteLine("1. Kon.\n");
            Console.WriteLine("2. Cylinder.\n");
            Console.WriteLine("════════════════════════════════════════════════════════");
            Console.Write("Ange ditt menyval [0-2]: ");
        }

        private static void ViewSolidDetail(Solid solid)
        {
            Console.WriteLine();
            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("╔══════════════════════════════════════════════════════╗");
            Console.WriteLine("║                        Detaljer                      ║");
            Console.WriteLine("╚══════════════════════════════════════════════════════╝");
            Console.ResetColor();
            Console.WriteLine();
            Console.WriteLine(solid.ToString());
            Console.WriteLine();
            Console.WriteLine("════════════════════════════════════════════════════════");
        }
    }
}
