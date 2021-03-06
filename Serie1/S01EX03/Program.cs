﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S01EX03
{
    class Program
    {
        static void Main(string[] args)
        {
            FileStream fileStream = new FileStream(@"..\..\Mesures.txt", FileMode.Open);
            StreamReader reader = new StreamReader(fileStream);

            List<int> mesures = new List<int>();
            while (!reader.EndOfStream)
            {
                mesures.Add(Convert.ToInt32(reader.ReadLine()));
            }

            int i = 0;
            foreach (int mesure in mesures)
            {
                Console.Write($"{mesure}");
                if (i < 9)
                { 
                    Console.Write(",");
                    i++;
                }
                else
                {
                    i = 0;
                    Console.Write("\n");
                }
            }
            Console.ReadKey();
        }
    }
}
