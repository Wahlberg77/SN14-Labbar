using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb2_Niva_A
{
    class Program
    {
        static void Main(string[] args)
        {
            //Loop på 25 rader
            for (int rad = 0; rad < 25; rad++)
            {
                if (rad % 2 == 1)
                {
                    Console.Write(" "); //Skriver ut mellanrummet mellan *
                }

                //Skriver ut dem tre olika färgerna
                switch (rad % 3)
                {
                    case 0:
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        {
                            break;
                        }
                    case 1:
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        {
                            break;
                        }
                    case 2:
                        Console.ForegroundColor = ConsoleColor.Green;
                        {
                            break;
                        }
                }

                //Loop på 39 kolumner som är inuti den första loopen med rader. 
                for (int kol = 0; kol < 39; kol++)
                {
                    Console.Write("* ");
                }
                Console.WriteLine();
            }
            //Återställer färgerna i konsollen
            Console.ResetColor();
        }

    }
}

