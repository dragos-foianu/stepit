using System;

namespace Duminica
{
    class Program
    {
        // functia factorial este definita astfel: factorial(n) = 1 * 2 * 3 * 4 * ... * n
        static double factorial(int n)
        {
            double r = 1; // rezultatul incepe de la 1 pentru ca facem inmultire

            // incep de la 2 pentru ca nu are rost sa inmultesc cu 1
            // folosim '<=' pentru ca vrem sa ajungem pana la n ('<' l-ar fi exclus pe n)
            for (int i = 2; i <= n; i++)
            {
                r *= i;
            }

            return r;
        }

        // aproximez constanta matematica e = 2.718...
        // unde n reprezinta numarul de termeni, mai multi termeni inseamna mai mult calcul, dar o aproximare mai exacta
        // definitie:
        //    e = 1 / 0! + 1 / 1! + 1 / 2! + 1 / 3! + ...
        static double approx_e(int n)
        {
            double r = 0; // rezultatul incepe de la 0 pentru ca fac o suma

            for (int i = 0; i <= n; i++)
            {
                r += 1 / factorial(i);
            }

            return r;
        }

        static void Main(string[] args)
        {
            // incerc aproximarea lui e folosind primii 30 de termeni
            double e = approx_e(30);

            Console.WriteLine(e);
        }
    }
}
