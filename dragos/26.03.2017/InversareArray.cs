using System;

namespace Duminica
{
    class Program
    {
        static void Main(string[] args)
        {
            // introduc datele astfel:
            // 1 2 3 4 5 6

            // citesc toate numerele de la consola si obtin sirul de caractere: "1 2 3 4 5 6"
            string s = Console.ReadLine();

            // Split() desparte un sir de caractere dupa spatiu:
            // ca sa fie mai clar, propozitia: "ana are mere" va fi impartita in:
            // string[] cuvinte = {"ana", "are", "mere"};
            // cuvinte[0] = "ana", cuvinte[1] = "are", cuvinte[2] = "mere"
            string[] nrs = s.Split();

            // nrs.Length = cate numere a citit, asa ca folosim aceasta informatie cand cerem sa creeze v
            int n = nrs.Length;

            // acum, nrs = { 1, 2, 3, 4, 5, 6 }
            // dar noi avem numere, asa ca avem nevoie de un array in care sa le pastram:
            int[] v = new int[n];

            for (int i = 0; i < n; i++)
            {
                // iau elementul din nrs[i] si il transform in int
                // ex: nrs[0] = "1" va fi transformat in v[0] = 1
                v[i] = int.Parse(nrs[i]);
            }

            // inversare array:
            for (int i = 0; i < n / 2; i++)
            {
                int tmp = v[i]; // temporar, pun v[i] deoparte ca sa pot sa fac schimbul
                v[i] = v[n - 1 - i]; // n - 1 este ultimul element (pentru ca array incepe de la 0)
                v[n - 1 - i] = tmp; // v[n - 1 - i] devine tmp care este de fapt v[i] salvat anterior
            }

            // afisare
            for (int i = 0; i < n; i++)
            {
                // un mod mai frumos de a aranja un string:
                // string.Format va inlocui {0}, {1}, {2}, etc... cu parametrul dat pe pozitia respectiva
                //
                // ex:
                // string.Format("{0} {1} {2} {3}", "ab", 2, "cd", 4) va da ca rezultat: "ab 2 cd 4"

                string str = string.Format("{0} ", v[i]); // numar + spatiu
                Console.Write(str);
            }
        }
    }
}
