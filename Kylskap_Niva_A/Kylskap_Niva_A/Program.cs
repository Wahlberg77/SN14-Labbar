using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kylskap_Niva_A
{
    class Program
    {

        //-------------------------------------------------------------------------------------------------------
        //----------------------------Kylskål Nivå A - Andreas Wahlberg SN14-------------------------------------
        //-------------------------------------------------------------------------------------------------------

        private const string HorizontalLine = "═════════════════════════════════════════════════════════════════════";

        //Metoden ska instansiera objekt av klassen Cooler och testa konstruktorerna, egenskaperna
        //och metoderna
        static void Main(string[] args)
        {
            //----TEST NR 1----
            Cooler test1 = new Cooler();
            ViewTestHeader("Test 1. \nTest av standardkonstruktorn.");
            Console.WriteLine(test1.ToString());
            Console.WriteLine();

            //----TEST NR 2----
            Cooler test2 = new Cooler(24.5m, 4m);
            ViewTestHeader("Test 2. \nTest av konstruktorn med två parametrar, <24,5 och 4>");
            Console.WriteLine(test2.ToString());
            Console.WriteLine();

            //----TEST NR 3----
            Cooler test3 = new Cooler(19.5m, 4m, true, false);
            ViewTestHeader("Test 3. \nTest av konstruktorn med två parametrar, <19,5 och 4, True och False>");
            Console.WriteLine(test3.ToString());
            Console.WriteLine();

            //----TEST NR 4----
            Cooler test4 = new Cooler(5.3m, 4m, true, false);
            ViewTestHeader("Test 4. \nTest av kylning med metoden Tick");
            Console.WriteLine();
            Console.WriteLine(test4.ToString());
            Run(test4, 10);

            //----TEST NR 5----
            Cooler test5 = new Cooler(5.3m, 4m, false, false);
            ViewTestHeader("Test 5. \nTest av avstängt kylskåp med metoden Tick, vara avslaget och ha stängd dörr");
            Console.WriteLine();
            Console.WriteLine(test5.ToString());
            Run(test5, 10);

            //----TEST NR 6----
            Cooler test6 = new Cooler(10.2m, 4m, true, true);
            ViewTestHeader("Test 6. \nTest av påslaget kylskåp med metoden Tick, vara på och ha öppen dörr");
            Console.WriteLine();
            Console.WriteLine(test6.ToString());
            Run(test6, 10);

            //----TEST NR 7----
            Cooler test7 = new Cooler(19.7m, 4m, false, true);
            ViewTestHeader("Test 7. \nTest av avslaget kylskåp med metoden Tick, ha öppen dörr");
            Console.WriteLine();
            Console.WriteLine(test7.ToString());
            Run(test7, 10);

            //----TEST NR 8----
            try //Test av felaktig innertemperatur 
            {
                ViewTestHeader("Test 8. \nTest av egenskaperna så att undantag kastas då innertemperaturen och \nmåltemperaturen tilldelas felaktiga värden.");
                Cooler test8 = new Cooler();
                test8.InsideTemperature = 90.0m;
                Run(test8, 10);
            }
            catch (Exception)
            {
                ViewErrorMessage("\nInnertemperaturen är inte i intervallen 0 - 45°C");
            }
            try //Test av felaktig måltemperatur 
            {
                Cooler test8 = new Cooler();
                test8.TargetTemperature = -19.0m;
                Run(test8, 10);
            }
            catch (Exception)
            {
                ViewErrorMessage("Måltemperaturen är inte i intervallen 0 - 45°C");
            }

            //----TEST NR 9----
            try
            {
                ViewTestHeader("Test 9. \nTest av egenskaperna så att undantag kastas då innertemperaturen och \nmåltemperaturen tilldelas felaktiga värden.");
                Cooler test9 = new Cooler(85.5m, 10m, true, true);
                Run(test9, 10);
            }
            catch (Exception)
            {
                ViewErrorMessage("\nInnertemperaturen är inte i intervallen 0 - 45°C");
            }

            try
            {
                Cooler test9 = new Cooler(6.0m, -5m, true, true);
                Run(test9, 10);
            }
            catch (Exception)
            {
                ViewErrorMessage("Måltemperaturen är inte i intervallen 0 - 45°C");
            }
        }

        //Privat statisk metod som har två parametrar. Ref till Cooler x2.
        private static void Run(Cooler clock, int minutes)
        {
            for (int ticks = 0; ticks < minutes; ticks++)
            {
                clock.Tick();
                Console.WriteLine(clock.ToString());
            }
        }

        //Privat statisk metod som tar en sträng som argument och presenterar strängen
        private static void ViewTestHeader(string header)
        {
            Console.WriteLine(HorizontalLine);
            Console.WriteLine(header);

        }

        //Privat statisk metoden som tar ett felmeddelande som argument och presenterar det.
        private static void ViewErrorMessage(string message)
        {
            Console.BackgroundColor = ConsoleColor.Red;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(message);
            Console.ResetColor();
        }


    }

}
