using System;
using System.Globalization;
using System.Net.NetworkInformation;
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

    //Aufgabe 4:
    class Smartphone{
        private int ?pin = null;
        private int pin_pruef, n=1;
        private bool gesperrt = false;
        private string text="";
        private void Autentifizierung(){
            if (pin != null && gesperrt == false){
                do{
                    Console.WriteLine("Hier bitte den Pin eingeben: ");
                    pin_pruef = int.Parse(Console.ReadLine());
                    if (pin_pruef == pin){
                        Console.WriteLine("TRUE (Pin war richtig :-) )");
                        gesperrt = false;
                        break;
                    }else{
                        Console.WriteLine("Pin war nicht richtig, Sie haben noch "+ (3-n) +" Versuche !");
                        gesperrt = true;
                    }
                    n++;
                } while (n < 4);

                if (gesperrt == true) {
                    Console.WriteLine("False (Pin war nicht richtig :-( ); Smartphone wird gespert");
                }else{
                    n=1;
                }

            }else{
                Console.WriteLine("Fehler! Pin vorhanden?: " + (pin != null) + 
                "| Smartphone gesperrt?: " + (gesperrt == true));
            }
        }    //Ende void Autentifizierung()

        public void Set_pin(){
            Autentifizierung();
            if (gesperrt == false){
                Console.WriteLine("Hier bitte NEUEN Pin eingeben: ");
                text = Console.ReadLine();
                if(Test(text) == "true"){ pin= null;}

            }else{
                Console.WriteLine("Autentifizierung fehl geschlagen Smartphone bleibt für immer gesperrt!!!");
            }

        } //Ende void Set_pin()

        String Test(string s){
        if (String.IsNullOrEmpty(s))
            return "true";
        else
            return String.Format("false");
        }

    }

    static void Aufg01() {
        char[] input = Console.ReadLine().ToCharArray();
        Console.Clear();
        char[] morseCode;
        foreach (char c in input) {
            morseCode = MorseTable.GetMorseCode(c).ToCharArray();
            Flash(morseCode);
        }
        
    }
    
    static void Aufg02(){
        Aufg2 test = new Aufg2("Test", 1, 2.3, Kategorie.NONE);
        Aufg2 abc = new Aufg2();
        Console.WriteLine(test.ToString());
        Console.WriteLine(abc.ToString());
    }

    static void Aufg04(){
        Smartphone Rudi = new Smartphone();
        Rudi.Set_pin();
    }


    static void Main(string[] args)
    {
        //Aufg01();
        //Aufg02();
        Aufg04();
    }
}