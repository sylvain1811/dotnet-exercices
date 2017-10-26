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

            Console.WriteLine("THE PAWNS");
            StringBuilder pawns = new StringBuilder();
            for (int i = 1; i <= boardGame.PawnNumber; i++)
            {
                pawns.Append(i);
                pawns.Append(":");
                pawns.Append(boardGame[i]);
                if (i < boardGame.PawnNumber)
                {
                    pawns.Append(", ");
                }
            }
            Console.WriteLine(pawns.ToString());

            Console.ReadKey();
        }
    }
}
