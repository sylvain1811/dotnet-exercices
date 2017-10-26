using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S02EX01
{
    class Program
    {
        static void Main(string[] args)
        {
            int num1, num2;
            decimal result;
            Console.WriteLine("DIVISION. Entrez 2 nombres, je calcule le quotient");

            try
            {
                Console.WriteLine("Entrez le 1er nombre: ");
                num1 = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Entrez le 2 ème nombre: ");
                num2 = Convert.ToInt32(Console.ReadLine());
                result = (decimal)num1 / (decimal)num2;
                Console.WriteLine("Divide : " + result.ToString());
            }
            catch (FormatException e1)
            {
                Console.WriteLine("Erreur de format : " + e1.Message);
            }
            catch (OverflowException e2)
            {
                Console.WriteLine("Overflow : " + e2.Message);
            }
            catch (DivideByZeroException e3)
            {
                Console.WriteLine("Division par 0 : " + e3.Message);
            }
            Console.ReadLine();
        }
    }
}
