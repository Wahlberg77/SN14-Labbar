using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//======================================================================================================================
//======================================= Lönerevison Nivå A / Andreas Wahlberg ========================================
//======================================================================================================================

namespace LonerRevision_Niva_A
{
    class Program
    {
        //LasInt Läsa in antalLoner
        //ProcessaLoner - Anropas och antalet löner, färre än två = felmeddelande
        //Felmeddelande färren än två blir rött, erbjud ny beräkning eller ESC för avslut. Grön text
        static void Main(string[] args)
        {
            do
            {
                int antalLoner = 0;
                while (true)
                {
                    antalLoner = LasInt("Ange antal löner att mata in: ");

                    if (antalLoner >= 2)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine();
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.WriteLine("Du måste mata in minst två löner för att kunna göra en beräkning! ");
                        Console.ResetColor();
                    }
                }

                // nu vet du att det är minst 2 löner
                ProcessaLoner(antalLoner);

                // avsluta eller inte?
                Console.WriteLine();
                Console.BackgroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("Tryck valfri tangent för en ny beräkning - ESC avslutar.");
                Console.ResetColor();

            } while (Console.ReadKey().Key != ConsoleKey.Escape);
            Console.Clear();
        }

        //INT [] Läser in den lokala arrayen
        //Presentera. Valuta C, Listas med tre löner per rad osorterade.
        //Medianlönen sortera array genom en kopia.
        //Tre löner per rad använd modulus % och högerjustera lönerna under varandra
        static void ProcessaLoner(int antal)
        {
            string prompt = "Ange lön nummer";
            Console.WriteLine("\n");
            int[] loner = new int[antal];

            for (int i = 0; i < antal; i++)
            {
                string text = String.Format("{0} {1} : ", prompt, (i + 1));
                loner[i] = LasInt(text);
            }

            decimal genomsnittLon = (decimal)loner.Average();
            int maxLon = loner.Max();
            int minimiLon = loner.Min();
            int loneSpridning = maxLon - minimiLon;

            //Kopia av arrayen 
            int[] lonerSorterade = new int[antal];
            Array.Copy(loner, lonerSorterade, antal);
            Array.Sort(lonerSorterade);

            //Räkna ut medianlönen med modulus %
            int medianLon;
            int mLon = antal / 2;
            if (antal % 2 == 0)
            {
                medianLon = (loner[mLon - 1] + loner[mLon]) / 2;
            }
            else
            {
                medianLon = loner[mLon];
            }

            //Skriva ut i konsollfönstret!
            Console.WriteLine();
            Console.WriteLine("------------------------------");
            Console.WriteLine("Medianlön:{0,14:c0}", medianLon);
            Console.WriteLine("Medellön:{0,15:c0}", genomsnittLon);
            Console.WriteLine("Lönespridning:{0,10:c0}", loneSpridning);
            Console.WriteLine("------------------------------");
            Console.WriteLine();

            //Osorterade löner, tre rader!
            for (int i = 0; i < loner.Length; i++)
            {
                if (i % 3 != 0)
                {
                    Console.Write("{0,10:c0}", loner[i]);
                }
                else
                {
                    Console.WriteLine();
                    Console.Write("{0,10:c0}", loner[i]);
                }
            }
            Console.WriteLine();
        }

        //LasInt (ReadInt) ska returnera ett värde av typen int. Feltolkat värde och felmeddelande
        static int LasInt(string prompt)
        {
            int resultat = 0;
            string strTest = string.Empty;

            while (true)
                try
                {
                    Console.Write(prompt);
                    strTest = Console.ReadLine();
                    resultat = int.Parse(strTest);
                    break;
                }
                catch (Exception)
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("Fel! '{0}' kan inte tolkas som ett heltal", strTest);
                    Console.ResetColor();
                }
            return resultat;
        }
    }
}

