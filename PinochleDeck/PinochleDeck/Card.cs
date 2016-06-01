using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PinochleDeck
{
    public class Card
    {
        public Card()
        {
            this.Suit = Suit;
            this.Value = Value;
            this.SameCardIndex = SameCardIndex;
        }

        public Card(string Suit, string Value, int SameCardIndex)
        {
            this.Suit = Suit;
            this.Value = Value;
            this.SameCardIndex = SameCardIndex;
        }
        public string Suit { get; set; }

        public string Value { get; set; }

        public int SameCardIndex { get; set; }
    }
}
