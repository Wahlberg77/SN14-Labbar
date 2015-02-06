using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb2_Niva_B
{
                           //-------------------------Andreas Wahlberg Labb 2 Nivå B----------------------------

    class Program
    {
        const string title = "Ange det udda antalet asterisker (max 79) i triangelns bas: ";
        const int BaseMax = 79;
        const int BaseMin = 1;

        private static void Main(string[] args)
        {
            do
            {
                Console.Clear();
                byte basen = ReadOddByte(title);
                RenderTriangle(basen);

                Console.BackgroundColor = ConsoleColor.DarkGreen;
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("\n\nTryck valfri tangent för en ny beräkning - ESC eller hårt slag \nav hammare avslutar.");
                Console.ResetColor();
            }
            while (Console.ReadKey().Key != ConsoleKey.Escape);
        }

        private static byte ReadOddByte(string title)
        {
            byte number = 0;
            string strTest = "";
            while (true)
            {
                Console.Write(title);
                strTest = Console.ReadLine();

                byte.TryParse(strTest, out number);
                if ((number > BaseMax) || ((number % 2) != 1))
                {
                    Console.WriteLine();
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("Fel! Det inmatade värdet är inte ett udda heltal mellan 1 och 79.");
                    Console.ResetColor();
                }
                else
                {
                    return number;
                }
            }
        }

        private static void RenderTriangle(byte cols)
        {
            int CountRows = (cols + 1) / 2;
            int iCount = (cols - 1) / 2;
            int printCount = 1;

            for (int row = 0; row < CountRows; row++)
            {
                Console.WriteLine();

                for (int column = 0; column < iCount; column++)
                {
                    Console.Write(" ");
                }
                iCount--;

                for (int column = 0; column < printCount; column++)
                {
                    Console.BackgroundColor = ConsoleColor.Yellow;
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write("*");
                    Console.ResetColor();
                }
                printCount += 2;
            }
            return;
        }
    }
}
