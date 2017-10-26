using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S01EX05
{
    class Program
    {
        static void Main(string[] args)
        {
            string s1 = "Hello World";
            string s2 = "Hello World";
            string s3 = s1;
            Print(s1, s2, s3);

            s3 += '!';
            Console.WriteLine("Modification...");

            Print(s1, s2, s3);

            Console.ReadKey();

            /* Conclusion :
                     String est immuable, si on le change, la référence change, donc un nouvel objet est créé.
            */
        }

        private static void Print(string s1, string s2, string s3)
        {
            Console.WriteLine("S1 equals S2: " + s1.Equals(s2));
            Console.WriteLine("S1 equals S3: " + s1.Equals(s3));
            Console.WriteLine("S2 equals S3: " + s2.Equals(s3));
            Console.WriteLine("S1 compareTo S2: " + s1.CompareTo(s2));
            Console.WriteLine("S1 compareTo S3: " + s1.CompareTo(s3));
            Console.WriteLine("S2 compareTo S3: " + s2.CompareTo(s3));
            Console.WriteLine("S1 System.ReferenceEquals S2: " + Object.ReferenceEquals(s1, s2));
            Console.WriteLine("S1 System.ReferenceEquals S3: " + Object.ReferenceEquals(s1, s3));
            Console.WriteLine("S2 System.ReferenceEquals S3: " + Object.ReferenceEquals(s2, s3));
        }
    }
}
