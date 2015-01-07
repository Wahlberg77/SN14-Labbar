using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb2_Niva_B
{
    class Program
    {
        static void Main(string[] args)
        {
            int i, j, n, temp;
            Console.Write("Ange det udda antalet asterisker (max 79) i triangelns bas: ");
            n = Convert.ToInt32(Console.ReadLine());
         
            temp = n;
            for (i = 1; i <= n; i++)
            {
                for (j = 1; j < temp; j++)
                    Console.Write(" ");

                temp--;
                for (j = 1; j <= 2 * i - 1; j++)
                    Console.Write("*");

                Console.WriteLine();
               
            }
            
            Console.ReadLine();
            
        }
        
    }
}
