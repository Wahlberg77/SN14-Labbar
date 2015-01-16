using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VaxelpengarNiva_B
{
    class Program
    {
        static void Main(string[] args)
        {
            //-----------------------------------------------------------------------------------------------------
            //-----------------------------Andreas Wahlberg - Växelpengar Nivå B ----------------------------------
            //--------------------------------------------MAIN-----------------------------------------------------

            Console.Title = "Växelpengar - Nivå B";

            uint betalade = 0;              // Erhållna beloppet
            double totalsum = 0d;           // Totala bellopet
            uint subTotal;                  // Öresavrundningen 
            uint tillbaka = 0;              // Tillbaka till kund
            double avrundning;              // Tillhör öresavrundningen

            do
            {
                totalsum = (double)LasPositivDouble("Ange total summa:    ");

                //Öresavrundning
                subTotal = (uint)Math.Round(totalsum);
                avrundning = subTotal - totalsum;

                betalade = LasUInt("Ange erhåller belopp: ", subTotal);

             
                // Räknar ut Växeln
                tillbaka = betalade - subTotal;


                //Kvitto
                Console.WriteLine("\nKVITTO");
                Console.WriteLine("-------------------------------");
                Console.WriteLine("{0,-15} : {1,10:c2} ", "Totalt", totalsum);
                Console.WriteLine("{0,-15} : {1,10:c2} ", "Öresavrundning", avrundning);
                Console.WriteLine("{0,-15} : {1,10:c0} ", "Att betala", subTotal);
                Console.WriteLine("{0,-15} : {1,10:c0} ", "Kontant", betalade);
                Console.WriteLine("{0,-15} : {1,10:c0} ", "Tillbaka", tillbaka);
                Console.WriteLine("-------------------------------");


                DelaUppIFaktorer(tillbaka);


                Console.BackgroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("\nTryck ESC för att avsluta eller valfri knapp för en ny beräkning.");
                Console.ResetColor();
            }
            while (Console.ReadKey(true).Key != ConsoleKey.Escape);
        }



        //-----------------------------------------------------------------------------------------------------
        //--------------------------------------LasPosivivDouble-----------------------------------------------
        //-----------------------------------------------------------------------------------------------------

        static double LasPositivDouble(string title)
        {
            string betaladeString = null;
            double betalade;
            string error;
            double totalsum = 0d;

            while (true)
            {
                Console.Write(title);

                try
                {
                    betaladeString = Console.ReadLine();
                    betalade = double.Parse(betaladeString);

                    if (betalade >= 1)
                    {
                        break;
                    }
                    else
                    {
                        error = String.Format("Fel '{0}' kan inte tolkas som en giltlig summa pengar", betaladeString);
                        ErrorMeddelande(error);
                    }
                    return totalsum;
                }
                              
                    catch (Exception)
                    {
                            ErrorMeddelande("Okänt konstigt fel, försök gärna igen");
                    }
            }
            return betalade;

        }


        //-----------------------------------------------------------------------------------------------------
        //-----------------------------------------------uint--------------------------------------------------
        //-----------------------------------------------------------------------------------------------------



        static uint LasUInt(string title, uint minVarde)
        {

            uint summa;
            string summaTotalString = null;
            string error;

            while (true)
            {
                try
                {

                    Console.Write(title);
                    summaTotalString = Console.ReadLine();
                    summa = uint.Parse(summaTotalString);

                    if (summa >= minVarde)
                    {
                        break;
                    }
                    else
                    {
                        error = String.Format("Fel '{0}' är för litet belopp", summaTotalString);
                        ErrorMeddelande(error);
                    }
                }
               
                catch (Exception)
                    {
                        ErrorMeddelande("Okänt jättemysko fel, försök gärna igen om du vågar");
                    }
            }
            return summa;
        }


        //-----------------------------------------------------------------------------------------------------
        //--------------------------------------DelaUppIFaktorer-----------------------------------------------
        //--------------------Skriver endast ut dem sedlar som kunden får tillbaka!----------------------------

        static void DelaUppIFaktorer(uint vaxel)
        {

            uint[] vaxeltillbaka = { 500, 100, 50, 20, 10, 5, 1 };
            uint antalPengar;
            string[] valorer = { "lappar", "lappar", "lappar", "lappar", "kronor", "kronor", "kronor" };

            for (int i = 0; i < vaxeltillbaka.Length; i++)
            {
                antalPengar = vaxel / vaxeltillbaka[i];
                vaxel = vaxel % vaxeltillbaka[i];

                if (antalPengar > 0)
                {
                    Console.WriteLine("{0,4}-{1}\t:  {2}", vaxeltillbaka[i], valorer[i], antalPengar);
                }

            }

        } //Avslutar DelaUppFaktorer


        //----------------------------------------------------------------------------------------------------
        //-------------------------------Skapat ett för ErrorMeddelande---------------------------------------
        //----------------------------------------------------------------------------------------------------

        public static void ErrorMeddelande(string title)
        {
            Console.BackgroundColor = ConsoleColor.Red;
            Console.WriteLine(title);
            Console.ResetColor();
        }

    } //Avslutar Class Program
}
