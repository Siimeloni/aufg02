using System;
using System.Threading;

public class Program
{
    static void Flash(char[] c){
        int dit = 200;
        int dah = 3*dit;
        int interSymbolBreak = dit;
        int interLetterBreak = 2*dit;
        int space = 4*dit;

        ConsoleColor currentBackground = Console.BackgroundColor;

        foreach (char m in c) {
            switch (m) {
                case '.':
                    Console.BackgroundColor = ConsoleColor.Yellow;
                    Console.Clear();
                    Thread.Sleep(dit);
                    Console.BackgroundColor = currentBackground;
                    Console.Clear();
                    break;

                case '-':
                    Console.BackgroundColor = ConsoleColor.Yellow;
                    Console.Clear();
                    Thread.Sleep(dah);
                    Console.BackgroundColor = currentBackground;
                    Console.Clear();
                    break;

                case ' ':
                    Console.BackgroundColor = ConsoleColor.Yellow;
                    Console.Clear();
                    Thread.Sleep(space);
                    Console.BackgroundColor = currentBackground;
                    Console.Clear();
                    break;

                default:
                    break;
            }
            Thread.Sleep(interSymbolBreak);
        }
        Thread.Sleep(interLetterBreak);
    }

    static void Main(string[] args)
    {
        char[] input = Console.ReadLine().ToCharArray();
        Console.Clear();
        char[] morseCode;
        foreach (char c in input) {
            morseCode = MorseTable.GetMorseCode(c).ToCharArray();
            Flash(morseCode);
        }
    }
}