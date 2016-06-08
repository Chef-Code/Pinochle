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

        public Card this[int index]  //POST int, GET Card
        {
            get
            {
                return hand[index];
            }
        }

        public int this[Card card] //POST Card, GET int
        {
            get
            {
                return hand.FindIndex(c =>
                c.Value == card.Value &&
                c.Suit == card.Suit &&
                c.SameCardIndex == card.SameCardIndex);
            }
        }

        public bool this[Card card] //POST Card, GET bool  TODO: use reflection to pass in any method avilable to the card to check for the card type.
        {
            get
            {
                foreach(var crd in hand)
                {
                    hand.Any(c =>
                        c.Value == card.Value &&
                        c.Suit == card.Suit &&
                        c.SameCardIndex == card.SameCardIndex);
                }
            }
        }
        public bool HasTen()
        {
            if (this.hand.Any(c => c.IsTen()))
                return true;
            else
                return false;
        }

        public bool HasJack()
        {
            if (this.hand.Any(c => c.IsJack()))
                return true;
            else
                return false;
        }

        public bool HasQueen()
        {
            if (this.hand.Any(c => c.IsQueen()))
                return true;
            else
                return false;
        }

        public bool HasKing()
        {
            if (this.hand.Any(c => c.IsKing()))
                return true;
            else
                return false;
        }

        public bool HasAce()
        {
            if (this.hand.Any(c => c.IsAce()))
                return true;
            else
                return false;
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

        public bool IsPinochle(PinochleHand ph)
        {
            foreach(var card in ph.hand)
            {
                this[card.IsJack()]
            }
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
