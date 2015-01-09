﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rita

{
    class Program
    {
        static void Main(string[] args)
        {
            do
            {
                Console.Clear();
                byte b = ReadOddByte(Strings.Input_Prompt, 71);
                RenderDiamond(b);
            }
            while (IsContinuing());
        }

        static void RenderDiamond(byte maxCount)
        {
            for (int i = 0; i < maxCount; i++)
            {
                int count = 0;
                if (i <= maxCount / 2)
                    count = i * 2 + 1;
                else
                    count = (maxCount - i) * 2 - 1;
                RenderRow(maxCount, count);
            }
        }

        static void RenderRow(int maxCount, int asteriskCount)
        {
            int start = maxCount / 2 - asteriskCount / 2;
            Console.CursorLeft = start;
            for (int i = 0; i < asteriskCount; i++)
            {
                Console.Write("*");
            }
            Console.WriteLine();
        }

        static byte ReadOddByte(string prompt = null, byte maxValue = 255)
        {
            while (true)
            {
                if (prompt != null)
                    Console.Write(prompt);
                byte b = maxValue;
                if (byte.TryParse(Console.ReadLine(), out b))
                {
                    if (b >= 1 && b <= maxValue && b % 2 == 1)
                        return b;
                }
                ShowMessage(string.Format(Strings.Number_Error, maxValue), true);
            }
        }

        static bool IsContinuing()
        {
            ShowMessage(Strings.Continue_Prompt);    // TODO Replace with resource later.
            if (Console.ReadKey().Key == ConsoleKey.Escape)
                return false;
            return true;
        }

        static void ShowMessage(string message, bool error = false)
        {
            if (error)
                Console.BackgroundColor = ConsoleColor.Red;
            else
                Console.BackgroundColor = ConsoleColor.Green;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine(message);
            Console.ResetColor();
        }
    }
}