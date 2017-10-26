using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S02EX02
{
    class BoardGame : IEnumerable<char> 
    {
        private int slotNumber = 26;
        public int SlotNumber
        {
            get { return slotNumber; }
        }

        private int pawnNumber = 6;
        public int PawnNumber
        {
            get { return pawnNumber; }
        }
        public bool this[char slot] // indexeur
        {
            get {
                if (dictionary.Keys.ElementAt(slot) != 0)
                {
                    return true;
                }
                else return false;
            }
        }

        public char this[int pawn] // indexeur
        {
            get {
                foreach (KeyValuePair<char, int> kvp in dictionary)
                {
                    if (kvp.Value == pawn)
                        return kvp.Key;
                }
                return '0';
            }
        }

        Dictionary<char, int> dictionary = new Dictionary<char, int>();

        public BoardGame()
        {
            Random random = new Random();
            String[] tab = "A,B,C,D,E,F,G,H,I,J,K,L,M,N,O,P,Q,R,S,T,U,V,W,X,Y,Z".Split(',');
            List<String> list = tab.ToList();
            for (int i = 0; i < slotNumber; i++)
            {
                dictionary.Add(Convert.ToChar(tab[i]), 0);
            }
            for (int i = 1; i <= pawnNumber; i++)
            {
                int index = random.Next(0, list.Count - 1);
                dictionary[Convert.ToChar(list.ElementAt(index))] = i;
                list.RemoveAt(index);
            }
        }

        
        IEnumerator<char> IEnumerable<char>.GetEnumerator()
        {
            // dictionary.GetEnumerator();
            List<char> list = new List<char>(pawnNumber);
            foreach (KeyValuePair<char, int> kvp in dictionary)
            {
                if (kvp.Value != 0)
                {
                    list.Add(kvp.Key);
                }
            }
            return list.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            List<char> list = new List<char>(pawnNumber);
            foreach (KeyValuePair<char, int> kvp in dictionary)
            {
                if (kvp.Value != 0)
                {
                    list.Add(kvp.Key);
                }
            }
            return list.GetEnumerator();
        }

        public override string ToString()
        {
            string ligne1 = "", ligne2 = "";
            foreach(KeyValuePair<char, int> kvp in dictionary)
            {
                ligne1 += kvp.Key.ToString();
                if (kvp.Value != 0)
                {
                    ligne2 += "X";
                }
                else ligne2 += " ";
            }
            return ligne1 + "\n"+ligne2;
        }
    }
}
