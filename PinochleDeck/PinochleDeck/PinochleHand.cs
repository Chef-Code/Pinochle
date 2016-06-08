using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PinochleDeck
{
    public class PinochleHand
    {
        private List<Card> hand;
        private int meld;

        public PinochleHand()
        {
            this.hand = new List<Card>();
        }

        public PinochleHand(int Meld)
        {
            this.hand = new List<Card>();
            this.meld = Meld;
        }

        public int Meld
        {
            get; //TODO: write this

            set;
        }

        public Card this[int index]
        {
            get
            {
                return hand[index];
            }
        }

        public int this[Card card]
        {
            get
            {
                return hand.FindIndex(c =>
                c.Value == card.Value &&
                c.Suit == card.Suit &&
                c.SameCardIndex == card.SameCardIndex);
            }
        }
        public bool IsRun()
        {
            return false;
        }

        public bool IsRoyalMarriage()
        {
            return false;
        }

        public bool IsMarriage()
        {
            return false;
        }

        public bool IsPinochle()
        {
            return false;
        }

        public bool IsAcesAround()
        {
            return false;
        }

        public bool IsKingsAround()
        {
            return false;
        }

        public bool IsQueensAround()
        {
            return false;
        }

        public bool IsJacksAround()
        {
            return false;
        }
    }
}
