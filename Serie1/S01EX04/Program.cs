using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S01EX04
{
    class Program
    {
        static void PairImpair(int[] tab, ref int[] tabImp, ref int[] tabPai)
        {
            List<int> listImp = new List<int>();
            List<int> listPai = new List<int>();

            for (int i = 0; i < tab.Length; i++)
            {
                if (tab[i] % 2 == 0)
                {
                    listPai.Add(tab[i]);
                }
                else
                {
                    listImp.Add(tab[i]);
                }
            }

            tabImp = listImp.ToArray();
            tabPai = listPai.ToArray();
        }
        static void Main(string[] args)
        {
            int[] tab = new int[20];
            int[] tabImp = new int[20];
            int[] tabPai = new int[20];
            Random random = new Random();

            for (int i = 0; i < 20; i++)
            {
                tab[i] = random.Next() % 100;
                //Console.WriteLine(tab[i]);
            }

            PairImpair(tab, ref tabImp, ref tabPai);

            Console.WriteLine("Pair : ");
            for (int i = 0; i< tabPai.Length;i++)
            {
                Console.WriteLine(tabPai[i]);
            }
            Console.WriteLine("\nImpair : ");
            for (int i = 0; i < tabImp.Length; i++)
            {
                Console.WriteLine(tabImp[i]);
            }
            
            Console.ReadKey();
        }
    }
}
