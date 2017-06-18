using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proprietati
{
    class Program
    {
        /*
            Important de retinut la proprietati:

            public int Prop { get; set; }

            int x = Prop;   <- aici se apeleaza functia 'get' pentru ca incerc sa obtin proprietatea
            Prop = x;       <- aici se apeleaza functia 'set' pentru ca incerc sa modific proprietatea

            Scopul este de a face modificari la acea informatie la accesare si la scriere.
            De obicei nu este nevoie, dar mai jos este un exemplu unde ar putea fi util:
        */


        /* Avem o clasa care reprezinta o Durata */
        class Durata
        {
            // intern, pastrez durata in secunde 
            // acest camp (reprezentarea interna) ar fi in mod normal private,
            // dar l-am lasat public pentru afisare 
            public int secunde;

            // Am o proprietate "Minute", care ma ajuta sa interpretez si sa
            // manipulez durata in minute
            public int Minute
            {
                get
                {
                    return secunde / 60; // se apeleaza cand din afara fac x = d.Minute
                }
                set
                {
                    secunde = value * 60; // se apeleaza cand din afara fac d.Minute = x;
                }
            }

            // Am o proprietate "Ore", care ma ajuta sa interpretez si sa
            // manipulez durata in ore
            public int Ore
            {
                get
                {
                    return secunde / 3600; // se apeleaza cand din afara fac x = d.Ore
                }
                set
                {
                    secunde = value * 3600; // se apeleaza cand din afara fac d.Ore = x;
                }
            }
        }
        static void Main(string[] args)
        {
            // Creez o durata
            Durata d = new Durata();

            // Setez cinci ore
            // Programul se duce la proprietatea "Ore"
            // si apeleaza functia set. Functia set inmulteste cu 3600 pentru a obtine secunde
            d.Ore = 5;

            // Valorile ar fi acum urmatoarele:
            // d.secunde -> 18000
            // d.Minute -> 300 (se apeleaza functia get de la proprietatea Minute)
            // d.Ore -> 5

            Console.WriteLine("secunde: " + d.secunde);
            Console.WriteLine("minute: " + d.Minute); // se apeleaza functia get de la proprietatea Minute
            Console.WriteLine("ore: " + d.Ore); // se apeleaza functia get de la proprietatea Ore
        }
    }
}
