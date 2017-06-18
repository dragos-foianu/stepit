using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clase
{
    /* Clasa care modeleaza o biblioteca */
    class Biblioteca
    {
        public string Nume { get; } /* are un nume, dar care nu poate fi setat, doar citit */
        private List<Carte> Carti { get; set; } /* si o lista de carti privata (interna) */

        public Biblioteca(string nume)
        {
            /* Initial, numele bibliotecii este cel din parametru, si lista de carti este goala */
            Nume = nume;
            Carti = new List<Carte>();
        }

        public void adaugaCarte(Carte c)
        {
            /* Ca sa adaug o carte, apelez metoda Add a listei */
            Carti.Add(c);
        }

        public void stergeCarte(Carte c)
        {
            /* Ca sa sterg o carte, apelez metoda Remove a listei */
            Carti.Remove(c);
        }

        public void listeazaCarti()
        {
            /* Afisez spatii pentru aspect si numele bibliotecii */
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Numele bibliotecii: " + Nume);
            Console.WriteLine();
            Console.WriteLine();

            /* Pentru fiecare carte din lista de carti */
            foreach (var carte in Carti) {
                /* Afisez proprietatile cartii si o linie goala pentru aspect */
                Console.WriteLine("Titlu: " + carte.Titlu);
                Console.WriteLine("Autor: " + carte.Autor);
                Console.WriteLine("Nr Pagini: " + carte.NrPagini);
                Console.WriteLine();
            }
        }
    }

    /* Clasa care modeleaza o carte */
    class Carte
    {
        public string Titlu { get; set; }
        public string Autor { get; set; }
        public int NrPagini { get; set; }

        /* Ca sa construiesc o carte, am nevoie de titlu, autor si nrPagini */
        public Carte(string titlu, string autor, int nrPagini) 
        {
            /* Initializez proprietatile clasei cu datele primite ca parametru in constructor */
            Titlu = titlu;
            Autor = autor;
            NrPagini = nrPagini;
        }

        public void citeste()
        {
            Console.WriteLine("Am citit " + Titlu);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            /* Creez o biblioteca, cu numele StepIt */
            var biblioteca = new Biblioteca("StepIt");

            /* Creez trei carti */
            Carte c1 = new Carte("Lord of the Rings", "J. R. R. Tolkien", 1000);
            Carte c2 = new Carte("A Song of Ice and Fire", "G. R. R. Martin", 800);
            Carte c3 = new Carte("Morometii", "Marin Preda", 600);

            /* Adaug cele trei carti la biblioteca */
            biblioteca.adaugaCarte(c1);
            biblioteca.adaugaCarte(c2);
            biblioteca.adaugaCarte(c3);

            /* Listez cartile */
            biblioteca.listeazaCarti();
        }
    }
}
