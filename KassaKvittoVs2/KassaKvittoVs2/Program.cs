using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VaxelpengarNivaA
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.Title = "Växelpengar - Nivå A";

            int betalade = 0;           // Erhållna beloppet
            double totalsum = 0d;       // Totala bellopet
            uint subTotal;              // Öresavrundningen 
            int tillbaka = 0;           // Tillbaka till kund
            int resultat = 0;
            double roundingOffAmount;   // Tillhör öresavrundningen
           
            while (true)
            {
                try
                {
                    // Totala samt erhållna beloppet

                    Console.Write("Ange totalsumma     : ");
                    totalsum = double.Parse(Console.ReadLine());

                    // Felhanteringen följer nedan!

                    if (totalsum < 1)
                    {
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("\n");
                        Console.WriteLine("Totalsumman är för liten. Köpet kunde inte genomföras.");
                        Console.WriteLine("\n");
                        Console.ResetColor();
                        Environment.Exit(0);
                    }
                    else
                        break;
                }
                catch
                {

                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("\n");
                    Console.WriteLine("Var vänlig och ange belopp i form av en siffra!");
                    Console.WriteLine("\n");
                    Console.ResetColor();
                }
            }


            while (true)
            {
                try
                {
                    Console.Write("Ange erhållet belopp: "); betalade = int.Parse(Console.ReadLine());


                    if
                        (betalade < totalsum)
                    {
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("\n");
                        Console.WriteLine("Totalsumman är för liten. Köpet kunde inte genomföras.");
                        Console.WriteLine("\n");
                        Console.ResetColor();
                        Environment.Exit(0);
                    }
                    else
                        break;
                }

                catch
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("\n");
                    Console.WriteLine("FEL Erhållet belopp felaktigt.");
                    Console.WriteLine("\n");
                    Console.ResetColor();
                }
            }



            //Kvitto
            Console.WriteLine("\nKVITTO");
            Console.WriteLine("-------------------------------");

            Console.WriteLine("{0,-15} : {1,13:c} ", "Totalt", totalsum);

            //Öresavrundning
            subTotal = (uint)Math.Round(totalsum, 2);
            roundingOffAmount = subTotal - totalsum;
            Console.WriteLine("{0,-15} : {1,10:f2} kr", "Öresavrundning", roundingOffAmount);

            // Räknar ut Växeln
            tillbaka = betalade - (int)totalsum;
            Console.WriteLine("{0,-15} : {1,10} kr", "Att betala", subTotal);
            Console.WriteLine("{0,-15} : {1,13:c0} ", "Kontant", betalade);
            Console.WriteLine("{0,-15} : {1,10} kr", "Tillbaka", tillbaka);

            Console.WriteLine("-------------------------------");

            resultat = tillbaka / 500;

            if (resultat > 0)
            {
                Console.WriteLine("{0,-15} : {1,1}", " 500-lappar", resultat);
                tillbaka = tillbaka % 500;
            }

            resultat = tillbaka / 100;

            if (resultat > 0)
            {
                Console.WriteLine("{0,-15} : {1,1}", " 100-lappar", resultat);
                tillbaka = tillbaka % 100;
            }

            resultat = tillbaka / 50;

            if (resultat > 0)
            {
                Console.WriteLine("{0,-15} : {1,1}", "  50-lappar", resultat);
                tillbaka = tillbaka % 50;
            }

            resultat = tillbaka / 20;

            if (resultat > 0)
            {
                Console.WriteLine("{0,-15} : {1,1}", "  20-lappar", resultat);
                tillbaka = tillbaka % 20;
            }

            resultat = tillbaka / 5;

            if (resultat > 0)
            {
                Console.WriteLine("{0,-15} : {1,1}", "   5-kronor", resultat);
                tillbaka = tillbaka % 5;
            }

            resultat = tillbaka / 1;

            if (resultat > 0)
            {
                Console.WriteLine("{0,-15} : {1,1}", "   1-kronor", resultat);
                tillbaka = tillbaka % 1;


            }
            Console.WriteLine();
            Console.WriteLine();
            
            
        }
    }
}
