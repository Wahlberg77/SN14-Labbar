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

            for (int rad = 0; rad < 25; rad++)
            {
                if (rad % 2 == 1)
                {
                    Console.Write(" ");
                }

                switch (rad % 3)
                {
                    case 0:
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        break;

                    case 1:
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        break;

                    case 2:
                        Console.ForegroundColor = ConsoleColor.Green;
                        break;
                        
                }

                for (int kol = 0; kol < 39; kol++)
                    
                {
                    Console.Write("* ");
                    
                }
                Console.WriteLine();
            }
            
            Console.ResetColor();
        }

    }
}

