using System;
using System.Threading;

class Program
{
    static void MorseString (string s)
    {
        foreach (var c in s)
        {
            MorseChar(MorseTable.GetMorseCode(c)); 
        }
    }

    static void MorseChar ( string symbols )
    {
        foreach (var symbol in symbols)
        {
            switch (symbol)
            {
                case '.': FlashConsoleWindow(200); break;
                case '-': FlashConsoleWindow(3 * 200); break;
                case ' ': Thread.Sleep(7 * 200); break;
                    default: throw new Exception("Unexpected morse symbol " + symbol);

            }
        }
    }
    static void FlashConsoleWindow (int delay) 
    {
        Console.BackgroundColor = ConsoleColor.Green;
        Console.Clear();

        Thread.Sleep(delay);

        Console.BackgroundColor = ConsoleColor.Black;
        Console.Clear();

        Thread.Sleep (700);
    }

    static void Main(string[] args)
    {
        Console.Write("To morse -> ");
        MorseString(Console.ReadLine());
    }
}