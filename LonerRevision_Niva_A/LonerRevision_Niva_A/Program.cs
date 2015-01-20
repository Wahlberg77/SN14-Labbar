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
        static void Main(string[] args)
            
            //LasInt Läsa in antalLoner
            //ProcessaLoner - Anropas och antalet löner, färre än två = felmeddelande
            //Felmeddelande färren än två blir rött, erbjud ny beräkning eller ESC för avslut. Grön text
        {
            int antalLoner;

            while (true)
            {
                try
                {

                    antalLoner = LasInt("Ange antal löner att mata in: ");
                    Console.WriteLine();

                    if (antalLoner < 2)
                    {
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.WriteLine("Du måste mata in minst två löner för att kunna göra en beräkning!");
                        Console.ResetColor();
                        Console.WriteLine();

                        throw new Exception();
                    }

                    else
                    {
                        ProcessaLoner(antalLoner);
                    }

                    Console.WriteLine();
                }

                catch (Exception)
                {

                    Console.WriteLine();
                    Console.BackgroundColor = ConsoleColor.DarkGreen;
                    Console.WriteLine("Tryck tangent för ny beräkning - ESC avslutar.");
                    Console.ResetColor();

                    //Avslutar med ESC, valfri tangent för att fortsätta!

                    ConsoleKeyInfo cki = Console.ReadKey(true);
                    if (cki.Key == ConsoleKey.Escape)
                    {
                        return; 
                    }

                }

                }
            } 

            //INT [] Läser in den lokala arrayen
            //Presentera. Valuta C, Listas med tre löner per rad osorterade.
            //Medianlönen sortera array genom en kopia.
            //Tre löner per rad använd modulus % och högerjustera lönerna under varandra

             static void ProcessaLoner(int count)
            
                {
                    int [] loner;
                    int [] osorteradeLoner;
                    int medianLon;
                    int genomsnittLon;
                    int loneSpridning;
                    int maxLon;
                    int minimiLon;   

                    loner = new int[count];
                    osorteradeLoner = new int[count];

                    for (int i = 0; i < count; i++)
			        {
			            loner[i] = LasInt(string.Format("Ange Lön nummer {0}: ", i + 1));
                        osorteradeLoner[i] = loner[i];
			        }

                    Array.Sort(loner);
                    
                    genomsnittLon = (int)loner.Average();
                    maxLon = loner.Max();
                    minimiLon = loner.Min();
                    loneSpridning = maxLon - minimiLon;

                    int mLon = count / 2;

                 //Räkna ut medianlönen med modulus %
                 if (count % 2 == 0)
                    {
                     medianLon = (loner[mLon -1] + loner [mLon]) /2;    
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
                    for (int i = 0; i <= count; i++)
                    {
                        Console.Write("{0,10:c0} ", osorteradeLoner[i]);
                        if (i % 3 == 2)
                        {
                            Console.WriteLine();
                        }

                    }
                    Console.WriteLine();
                               
                    //Göra en ny beräkning eller ej, samma som under main!
                    throw new Exception();
                }

            //ReadInt ska returnera ett värde av typen int. 
            //Feltolkat värde och felmeddelande
            //Argument/sträng ange antalet löner här!
            //Läsa in lönen!

        static int LasInt(string prompt)
        {

            int value;

                while (true)
                {
                    string str = "";
                    try
                    {
                        Console.Write(prompt);
                        str = Console.ReadLine();
                        value = int.Parse(str);
                        if (value < 1)
                        {
                            Console.WriteLine();
                            Console.BackgroundColor = ConsoleColor.Red;
                            Console.WriteLine("Skriv in ett värde som är högre än 0.");
                            Console.ResetColor();
                            Console.WriteLine();
                        }
                        else
                        {
                            break;
                        }
                    }
                    catch
                    {
                        Console.WriteLine();
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.WriteLine("Fel format! {0} Försök igen.", str);
                        Console.ResetColor();
                        Console.WriteLine();
                    }
                }
                return value;

        }
           
    }
}
