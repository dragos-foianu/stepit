using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Duminica
{
    class Program
    {
        static void Main(string[] args)
        {
            /* array de 10 elemente: */
            int[] v = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            int sum = 0; // o variabila cu numele sum unde tinem suma, incepe de la 0

            // trec prin fiecare element din v
            // v.Length = 10
            // numerele se vor afla pe pozitiile 0, 1, ..., 9 (de aceea verificam ca este < strict decat 10)
            for (int i = 0; i < v.Length; i++)
            {
                sum += v[i]; // adaug la suma
            }

            // scriu suma la consola
            Console.WriteLine(sum);
        }
    }
}
