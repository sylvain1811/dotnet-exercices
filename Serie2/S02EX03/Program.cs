using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace S02EX03
{
    class Program
    {
        static void PublishDatas(int[] tab)
        {
            System.IO.StreamWriter streamWriter = new System.IO.StreamWriter("test.txt");
            foreach (var v in tab)
            {
                streamWriter.WriteLine(v);
            }
            streamWriter.Close();
        }

        static void Main(string[] args)
        {

            System.IO.StreamReader streamReader = null;
            while (true)
            {
                try
                {
                    Console.WriteLine("Chemin du fichier de données : ");
                    string fileName = Console.ReadLine();
                    streamReader = new System.IO.StreamReader(fileName, System.Text.Encoding.ASCII);
                    break;
                }
                catch
                {
                    Console.WriteLine("Fichier non trouvé, rentrer le bon nom de fichier.");
                }
            }

            string datasSource = streamReader.ReadToEnd();
            streamReader.Close();
            string[] lines = datasSource.Split('\n');
            List<int> dataList = new List<int>();
            int lineNumber = 0;
            foreach (var line in lines)
            {
                if (Regex.IsMatch(line, @"^[0-9]|-[0-9]"))
                {
                    try
                    {
                        dataList.Add(System.Convert.ToInt32(line));
                        Console.WriteLine(line);
                    }
                    catch
                    {
                        Console.WriteLine($"Impossible de convertir la ligne {lineNumber} en entier");
                    }
                }
                lineNumber++;
            }

            int[] datas = dataList.ToArray();

            int[] tabComputedDatas = new int[datas.Length - 2];
            for (int i = 0; i < datas.Length - 2; i++)
            {
                try
                {
                    tabComputedDatas[i] = datas[i] / (datas[i + 1] - datas[i + 2]);
                }
                catch (DivideByZeroException e)
                {
                    Console.WriteLine($"Erreur de division par zéro : {datas[i]} / ({datas[i + 1]} - {datas[i + 2]})");
                }
            }

            foreach (var v in tabComputedDatas)
            {
                Console.Write($"{v}, ");
            }

            Console.WriteLine();

            PublishDatas(tabComputedDatas);

            Console.ReadKey();
        }
    }
}
