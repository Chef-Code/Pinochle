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

        public int Rank(Card a)
        {
            if (IsAce(a) || IsTen(a) || IsKing(a))
                return 1;
            else
                return 0;
        }

        public bool SameSuit(Card a, Card b)
        {
            if (a.Suit == b.Suit)
                return true;
            else
                return false;
        }
        public bool SameValue(Card a, Card b)
        {
            if (a.Value == b.Value)
                return true;
            else
                return false;
        }

        public bool SameSuitAndValue(Card a, Card b)
        {
            if (SameSuit(a, b) && SameValue(a, b))
                return true;
            else
                return false;
        }

        public bool SameIndex(Card a, Card b)
        {
            if (a.SameCardIndex == b.SameCardIndex)
                return true;
            else
                return false;
        }

        public bool SameCard(Card a, Card b)
        {
            if (SameSuitAndValue(a,b) && SameIndex(a,b))
                return true;
            else
                return false;
        }

        public bool IsJack()
        {
            if (this.Value == "jack")
                return true;
            else
                return false;
        }
        public bool IsJack(Card a)
        {
            if (a.Value == "jack")
                return true;
            else
                return false;
        }

        public bool IsQueen()
        {
            if (this.Value == "queen")
                return true;
            else
                return false;
        }

        public bool IsQueen(Card a)
        {
            if (a.Value == "queen")
                return true;
            else
                return false;
        }

        public bool IsKing()
        {
            if (this.Value == "king")
                return true;
            else
                return false;
        }

        public bool IsKing(Card a)
        {
            if (a.Value == "king")
                return true;
            else
                return false;
        }

        public bool IsTen()
        {
            if (this.Value == "ten")
                return true;
            else
                return false;
        }

        public bool IsTen(Card a)
        {
            if (a.Value == "ten")
                return true;
            else
                return false;
        }

        public bool IsAce()
        {
            if (this.Value == "ace")
                return true;
            else
                return false;
        }

        public bool IsAce(Card a)
        {
            if (a.Value == "ace")
                return true;
            else
                return false;
        }

        public bool IsClubs()
        {
            if (this.Suit == "clubs")
                return true;
            else
                return false;
        }
        public bool IsClubs(Card a)
        {
            if (a.Suit == "clubs")
                return true;
            else
                return false;
        }

        public bool IsDiamonds()
        {
            if (this.Suit == "diamonds")
                return true;
            else
                return false;
        }

        public bool IsDiamonds(Card a)
        {
            if (a.Suit == "diamonds")
                return true;
            else
                return false;
        }

        public bool IsHearts()
        {
            if (this.Suit == "hearts")
                return true;
            else
                return false;
        }

        public bool IsHearts(Card a)
        {
            if (a.Suit == "hearts")
                return true;
            else
                return false;
        }

        public bool IsSpades()
        {
            if (this.Suit == "spades")
                return true;
            else
                return false;
        }

        public bool IsSpades(Card a)
        {
            if (a.Suit == "spades")
                return true;
            else
                return false;
        }
    }
}
