using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S02EX02
{
    class Program
    {
        static void Main(string[] args)
        {
            BoardGame boardGame = new BoardGame();

            Console.WriteLine("THE BOARDGAME");

            Console.WriteLine(boardGame.ToString());

            Console.WriteLine("\nTHE PAWNS");

            for (int i = 1; i <= boardGame.PawnNumber; i++)
            {
                Console.Write(i + ":" + boardGame[i] + ", ");
            }






            Console.ReadKey();

        }
    }
}
