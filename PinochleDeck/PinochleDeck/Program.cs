using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PinochleDeck
{
    class Program
    {
        static void Main(string[] args)
        {
            Deck deck = new Deck();
            TestEmpty(deck);

        }

        static public void TestEmpty(Deck d)
        {
           
            bool empty = d.Empty;
            int count = d.Count;
            Console.WriteLine(empty.ToString() + " " + count.ToString());
            Console.ReadLine();

        }

        static public void FunwithStrings()
        {
            Deck d1 = new Deck();
            Deck d2 = new Deck();

            var deck1 = d1.FillStringArrayCards();

            var deck2 = d2.FillListCards();

            string[] message1 = new string[80];
            string[] message2 = new string[80];

            string build1;
            string build2;

            int index1 = 0;
            int index2 = 0;

            foreach (var _d1 in deck1)
            {
                build1 = string.Format("Deck1: card from method: FillStringArrayCards {0} ", _d1);
                message1.SetValue(build1, index1);
                index1++;
            }

            foreach (var _d2 in deck2)
            {
                build2 = string.Format("Deck2: card from method: FillListCards Value:{0} Suit:{1} Index:{2}", _d2.Value, _d2.Suit, _d2.SameCardIndex);
                message2.SetValue(build2, index2);
                index2++;
            }

            for (var i = 0; i < message1.Count(); i++)
            {
                var m1 = message1[i];
                var m2 = message2[i];

                string full = m1 + " \n\n " + m2;

                Console.WriteLine(full);
            }

            Console.ReadLine();
        }
    }
}
