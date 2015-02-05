using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb2_Niva_B
{                       //-----------------------------------------------------------------------------------
    //-------------------------Andreas Wahlberg Labb 2 Nivå B----------------------------
    //-----------------------------------------------------------------------------------
    class Program
    {
        const string title = "Ange det udda antalet asterisker (max 79) i triangelns bas: ";

        //Denna metod ska anropa metoderna ReadOddByte och RenderTriangle. Anropen ska placeras
        //i en ”do-while”-sats som avslutas då användaren trycker på Escape-tangenten
        private static void Main(string[] args)
            {
                byte basen = ReadOddByte(title);
                //DrawTriangle(basen);

               
            do
                   { 
                        Console.WriteLine();
                        Console.BackgroundColor = ConsoleColor.DarkGreen;
                        Console.WriteLine("Tryck valfri tangent för en ny beräkning - ESC avslutar.");
                        Console.ResetColor();

                    } 
                        while (Console.ReadKey().Key != ConsoleKey.Escape);
                            Console.Clear();
            }

        //Returnerar ett udda heltal av typen byte.
        //Felhantering och ligger i intervallet 1 - 79. 
        //Visa felmeddelande och göra en ny inmatning igen.
        private static byte ReadOddByte(string title)
        {
            byte number = 0;

            while (true)
            {
                byte readOddByte =0;
                //number = byte.Parse(strTest);

                if (readOddByte < 1 && readOddByte > 79 && number % 2 == 0)
                {
                    //Fixa udda talet med modulus och kasta undantag.
                    Console.WriteLine();
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.WriteLine("Fel! Det inmatade värdet är inte ett udda heltal mellan 1 och 79.");
                    Console.ResetColor();
                }
            }
        }

        //parametern cols som ger antalet asterisker triangelns bas ska innehålla. 
        //Använd nässlade for-satser. 
        private static void RenderTriangle(byte cols)
        {
            string strTest = ("");
            string stars = ("*");
            Console.WriteLine("fis" ,stars);
        }
    }
}
