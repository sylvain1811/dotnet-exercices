using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S01EX02
{
    class Program
    {
        static void Main(string[] args)
        {
            bool ok = false;
            double a = 0;
            while (!ok) {
                try
                {
                    Console.WriteLine("Entrer un nombre réel positif: ");
                    a = Convert.ToDouble(Console.ReadLine());
                    if (a > 0)
                        ok = true;
                }
                catch
                {
                    Console.WriteLine("Erreur de saisie.");
                }
            }

            int debut = DateTime.Now.Millisecond;
            int cpt = 0;
            double limite = a * Math.Pow(10, -9);
            double sqrt = Math.Sqrt(a);
            double x1 = a, x2;

            while(true)
            {
                x2 = (x1 + a / x1) / 2;
                Console.WriteLine("approximation de la racine carrée de " + a + " est " + x2);
                x1 = x2;
                cpt++;
                if (Math.Abs(sqrt - x1) < limite)
                    break;
            }

            int fin = DateTime.Now.Millisecond;
            int tempsPasse = fin - debut;

            Console.WriteLine("Itérations : " + cpt + "\nErreur résiduelle : " + Math.Abs(sqrt - x1) + "\nTemps passé : " + tempsPasse);
            Console.ReadKey();
        }
    } 
}
