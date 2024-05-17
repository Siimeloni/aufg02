using System;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;
using System.Threading;

public class Program
{
    //AUFGABE 1 :
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
    
    // AUFGABE 2 :
    enum Kategorie{THERMO, ELEKTRO, NONE}
    class Aufg2{
        private string bezeichnung;
        private int nr;
        private double leistung;
        private Kategorie kategorie;

        public string GetBezeichnung(){return bezeichnung;}
        public void SetBezeichnung(string text){this.bezeichnung = text;}

        //Konstruktor:
        public Aufg2 (){
            this.bezeichnung = "Leer";
            this.nr=0;
            this.leistung=0.0;
            this.kategorie=Kategorie.ELEKTRO;
        }
        public Aufg2 (string bezeichnung, int nr, double leistung, Kategorie kategorie) {
            this.bezeichnung = bezeichnung;
            this.nr = nr;
            this.leistung = leistung;
            this.kategorie = kategorie;
        }
        //public Aufg2 (){}
        public override string ToString(){
            return String.Format("{0,5}; {1,5}; {2,5}; {3,5}", bezeichnung, nr, leistung, kategorie);
        }
    }

    // AUFGABE 3 :
    public struct Size {

        public Size(double w, double h) {
            if (w < 0.0 || h < 0.0) {
                throw new ArgumentException("Only positive numbers are allowed for width and height!");
            }
            this.width = w;
            this.height = h;
        }
        private double width;
        private double height;
        public double Width {
            get => width;
            set{
                if (value < 0.0) {
                    throw new ArgumentException("Only positive numbers are allowed for width!");
                }
                width = value;
            }
        }
        public double Height {
            get => height;
            set{
                if (value < 0.0) {
                    throw new ArgumentException("Only positive numbers are allowed for height!");
                }
                height = value;
            }
        }
    }

    // AUFGABEN MAIN FUNCTIONS
    static void Aufg01() {
        char[] input = Console.ReadLine().ToCharArray();
        Console.Clear();
        char[] morseCode;
        foreach (char c in input) {
            morseCode = MorseTable.GetMorseCode(c).ToCharArray();
            Flash(morseCode);
        }
    }

// Carls Version
    static void Aufg01C() {
        Console.Write("To morse -> ");
        MorseString(Console.ReadLine());
    }
    
    static void Aufg02(){
        Aufg2 test = new Aufg2("Test", 1, 2.3, Kategorie.NONE);
        Aufg2 abc = new Aufg2();
        Console.WriteLine(test.ToString());
        Console.WriteLine(abc.ToString());
    }

    static void Aufg03(){
        Size square = new Size(12, 12.0);
        System.Console.WriteLine("Square is {0} wide and {1} high.\n", square.Width, square.Height);

        System.Console.Write("Please enter Width: ");
        double width = double.Parse(Console.ReadLine());
        System.Console.Write("Please enter Height: ");
        double height = double.Parse(Console.ReadLine());

        Size shape = new Size();
        shape.Width = width;
        shape.Height = height;
        System.Console.WriteLine("The shape is {0} wide and {1} high.", shape.Width, shape.Height);
    }


    static void Main(string[] args)
    {
        //Aufg01();
        //Aufg02();
        Aufg03();
    }
}
