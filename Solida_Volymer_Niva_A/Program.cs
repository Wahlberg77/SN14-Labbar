using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solida_Volymer_Niva_A
//-------------------------------------------------------------------------------------
//----------------------- Andreas Wahlberg - Solida Volymer Nivå A --------------------
//-------------------------------------------------------------------------------------
{


    class Program
    {
        static void Main(string[] args)
        {
            do
            {
                Console.Clear();
                ViewMenu();

                switch (Console.ReadLine())
                {
                    case "0": return;

                    case "1": ViewSolidDetail(CreateSolid(SolidType.CircularCone));
                        break;

                    case "2": ViewSolidDetail(CreateSolid(SolidType.Cylinder));
                        break;

                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\nFEL! Du måste ange ett nummer mellan 1-2.");
                        Console.ResetColor();
                        break;
                }

                Console.BackgroundColor = ConsoleColor.DarkBlue;
                Console.Write("\nTryck tangent för att fortsätta");
                Console.ResetColor();

            }
            while (Console.ReadKey(true).Key != ConsoleKey.Escape);

        }


        private static Solid CreateSolid(SolidType solidType)
        {
            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("╔══════════════════════════════════════════════════════╗");

            // Bestäms om det är en Cylinder eller en Cirdularcone!
            switch (solidType)
            {
                case SolidType.CircularCone: Console.WriteLine
                             ("║═                       Kon                          ═║");
                    break;

                case SolidType.Cylinder: Console.WriteLine
                             ("║═                      Cylinder                      ═║");
                    break;
            }

            Console.WriteLine("╚══════════════════════════════════════════════════════╝\n");
            Console.ResetColor();

            double radius = ReadDoubleGreaterThanZero("Ange radien <r>: ");
            double hight = ReadDoubleGreaterThanZero("Ange höjden <r>: ");

            if (solidType == SolidType.CircularCone)
            {
                return new CircularCone(radius, hight);
            }
            else
            {
                return new Cylinder(radius, hight);
            }

        }

        private static double ReadDoubleGreaterThanZero(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);

                try
                {
                    double var = double.Parse(Console.ReadLine());

                    if (var > 0)
                    {
                        return var;
                    }
                    throw new ApplicationException();
                }
                catch
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nFEL! Ange ett flyttal större än 0.\n");
                    Console.ResetColor();
                }

            }
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
