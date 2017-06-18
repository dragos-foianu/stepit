using System;

namespace Duminica
{
    class Program
    {
        // explicatie a metodei de aproximare a lui Archimede
        // https://www.youtube.com/watch?v=_rJdkhlWZVQ

        // pi este definit ca si circumferinta cercului (c) impartita la diametru (d)
        // pi = c / d
        static double approx_pi(int n)
        {
            int sides = 6; // incep cu 6 laturi
            double s = 1; // latura incepe cu lungimea 1

            // impart hexagonul de 10 ori
            for (int i = 0; i < n; i++)
            {
                // teorema lui pitagora pentru a afla 'a'
                double a = Math.Sqrt(1 - (s / 2) * (s / 2));

                // latura 'b' este raza(=1) fara 'a'
                double b = 1 - a;

                // noua dimensiune a laturei poligonului
                s = Math.Sqrt(b * b + (s / 2) * (s / 2));

                // am efectuat impartirea, asa ca acum am numar dublu de laturi
                sides *= 2;
            }

            // s este lungimea unei laturi, iar n este numarul de laturi
            double circumference = sides * s;

            // pi este circumferinta / diametru
            // diametrul este de doua ori raza = 2
            return circumference / 2;
        }


        static void Main(string[] args)
        {
            // incerc aproximarea lui pi impartind hexagonul de 10 ori
            double pi = approx_pi(10);

            Console.WriteLine(pi);
        }
    }
}
