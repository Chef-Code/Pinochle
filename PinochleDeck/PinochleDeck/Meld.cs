using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PinochleDeck
{
    public class Meld
    {
        #region fields
        private List<MeldType> meldTypes;
        private List<MeldCombination> meldCombinations; 
        private int multiplier;
        #endregion

        #region Constructors
        public Meld()
        {
            meldCombinations = MeldCombinations;
            meldTypes = MeldTypes;
            multiplier = Multiplier;
        }
        public Meld(PinochleHand Hand)
        {
            TrumpSuit = Hand.TrumpSuit;
            meldCombinations = MeldCombinations;
            meldTypes = MeldTypes;
            multiplier = Multiplier;
            HandInQuestion = Hand;
        }
        #endregion

        #region Properties
        public PinochleHand HandInQuestion { get; set; }
        public Suit TrumpSuit { get; set; }
        public List<MeldCombination> MeldCombinations
        {
            get { return meldCombinations; }
            set { meldCombinations = value; }
        }
        public List<MeldType> MeldTypes
        {
            get { return meldTypes; }
            set { meldTypes = value; }
        }
        public int Multiplier
        {
            get { return multiplier; }
            set { multiplier = value; }
        }
        #endregion

        #region Methods
        public int Runs() //Run: Ace, Ten, King, Queen, Jack of trumps
        {
            var h = HandInQuestion;
            var tc = h.TrumpCards;

            if (tc.HasAce<Card>() && tc.HasKing<Card>() && tc.HasQueen<Card>() && tc.HasJack<Card>() && tc.HasTen<Card>())
            {
                var aces = tc.Where(c => c.IsAce()).ToList();      // this can be refactored to tc.Count() which will eliminate 
                var kings = tc.Where(c => c.IsKing()).ToList();    // the extra computation and the lengths[][] array
                var queens = tc.Where(c => c.IsQueen()).ToList();
                var jacks = tc.Where(c => c.IsJack()).ToList();
                var tens = tc.Where(c => c.IsTen()).ToList();

                var lengths = new List<List<Card>>() { aces, kings, queens, jacks, tens };

                lengths.OrderBy(i => i.Count).ToList(); //lengths[4] has the least amount when using OrderBy

                if(lengths[4].Count == lengths[0].Count)
                {
                    return lengths[0].Count;
                }
                else if(lengths[4].Count == lengths[1].Count)
                {
                    return lengths[1].Count;
                }
                else if(lengths[4].Count == lengths[2].Count)
                {
                    return lengths[2].Count;
                }
                else if (lengths[4].Count == lengths[3].Count)
                {
                    return lengths[3].Count;
                }
                else
                {
                    return lengths[4].Count;
                }
            }

            return 0;
        }

        public int RoyalMarriages() //Royal Marriage: King and Queen of trumps
        {
            var h = HandInQuestion;
            var tc = h.TrumpCards;
            var royalMarriages = 0;

            var kings = tc.Count(c => c.IsKing());
            var queens = tc.Count(c => c.IsQueen());

            var runs = Runs();

            if(kings > runs && queens > runs)
            {
                if(kings > queens)
                {
                    royalMarriages = queens - runs;
                }
                else if(queens > kings)
                {
                    royalMarriages = kings - runs;
                }
                else
                {
                    royalMarriages = kings - runs; //this could be either kings || queens - runs
                }
            }

            return royalMarriages;
        }

        public int Marriages() //Marriage: Kings and Queen of the SAME suit, *NOT trumps*
        {
            var h = HandInQuestion;
            var ntc = h.NonTrumpCards;

            var kings = ntc.Where(c => c.IsKing()).ToList();
            var queens = ntc.Where(c => c.IsQueen()).ToList();

            var kingOfClubs = new List<Card>();
            var kingOfDiamonds = new List<Card>();
            var kingOfHearts = new List<Card>();
            var kingOfSpades = new List<Card>();
            var queenOfClubs = new List<Card>();
            var queenOfDiamonds = new List<Card>();
            var queenOfSpades = new List<Card>();
            var queenOfHearts = new List<Card>();

            var marriages = 0;

            kingOfClubs = kings.Where(c => c.Suit.Name == "clubs").ToList();
            kingOfDiamonds = kings.Where(c => c.Suit.Name == "diamonds").ToList();
            kingOfHearts = kings.Where(c => c.Suit.Name == "hearts").ToList();
            kingOfSpades = kings.Where(c => c.Suit.Name == "spades").ToList();

            queenOfClubs = queens.Where(c => c.Suit.Name == "clubs").ToList();
            queenOfDiamonds = queens.Where(c => c.Suit.Name == "diamonds").ToList();
            queenOfHearts = queens.Where(c => c.Suit.Name == "hearts").ToList();
            queenOfSpades = queens.Where(c => c.Suit.Name == "spades").ToList();

            var clubMarriages = MarriagesHelper(kingOfClubs, queenOfClubs);
            var diamondMarriages = MarriagesHelper(kingOfDiamonds, queenOfDiamonds);
            var heartMarriages = MarriagesHelper(kingOfHearts, queenOfHearts);
            var spadeMarriages = MarriagesHelper(kingOfSpades, queenOfSpades);

            marriages = (clubMarriages + diamondMarriages + heartMarriages + spadeMarriages);

            return marriages;
        }
        private int MarriagesHelper(List<Card> Kings, List<Card> Queens)
        {
            var marriages = 0;
            var kings = Kings.Count;
            var queens = Queens.Count;

            if (kings >= 1 && queens >= 1)
            {
                if (kings > queens)
                {
                    marriages = queens;
                }
                else if (queens > kings)
                {
                    marriages = kings;
                }
                else
                {
                    marriages = kings; //this could be either kings || queens 
                }
            }

            return marriages;
        }
        public int Pinochles() //Pinochle: Jack of diamonds & Queen of spades
        {
            var pinochles = 0;

            var hand = this.HandInQuestion;

            var jackOfDiamonds = hand.Cards.Count(c => c.IsJack() && c.Suit.Name == "diamonds");
            var queenOfSpades = hand.Cards.Count(c => c.IsQueen() && c.Suit.Name == "spades");

            if (jackOfDiamonds >= 1 && queenOfSpades >= 1)
            {
                if (jackOfDiamonds > queenOfSpades)
                {
                    pinochles = queenOfSpades;
                }
                else if (queenOfSpades > jackOfDiamonds)
                {
                    pinochles = jackOfDiamonds;
                }
                else
                {
                    pinochles = jackOfDiamonds; //this could be either jackOfDiamonds || queenOfSpades 
                }
            }

            return pinochles;
        }
        public int AcesAround() //Aces around: An Ace in each suit
        {
            var acesAround = 0;
            var hand = this.HandInQuestion;

            var aces = hand.Cards.Where(c => c.IsAce()).ToList();

            acesAround = AroundHelper(aces);

            return acesAround;
        }
        public int KingsAround() //Kings around: A King in each suit
        {
            var kingsAround = 0;
            var hand = this.HandInQuestion;


            var kings = hand.Cards.Where(c => c.IsKing()).ToList();

            kingsAround = AroundHelper(kings);

            return kingsAround;
        }
        public int QueensAround() //Queens around: A Queen in each suit
        {
            var queensAround = 0;
            var hand = this.HandInQuestion;

            var queens = hand.Cards.Where(c => c.IsQueen()).ToList();

            queensAround = AroundHelper(queens);

            return queensAround;
        }
        public int JacksAround() //Jacks around: A Jack in each suit
        {
            var jacksAround = 0;
            var hand = this.HandInQuestion;

            var jacks = hand.Cards.Where(c => c.IsJack()).ToList();

            jacksAround = AroundHelper(jacks);

            return jacksAround;
        }
        private int AroundHelper(List<Card> list)
        {
            var arounds = 0;

            if (list.HasClub<Card>() && list.HasDiamond<Card>() && list.HasHeart<Card>() && list.HasSpade<Card>())
            {
                var clubs = list.Where(c => c.IsClubs()).ToList();
                var diamonds = list.Where(c => c.IsDiamonds()).ToList();
                var hearts = list.Where(c => c.IsHearts()).ToList();
                var spades = list.Where(c => c.IsSpades()).ToList();

                var lengths = new List<List<Card>> { clubs, diamonds, hearts, spades };

                lengths.OrderBy(i => i.Count).ToList(); //lengths[4] has the least amount when using OrderBy

                if (lengths[3].Count == lengths[0].Count)
                {
                    return lengths[0].Count;
                }
                else if (lengths[3].Count == lengths[1].Count)
                {
                    return lengths[1].Count;
                }
                else if (lengths[3].Count == lengths[2].Count)
                {
                    return lengths[2].Count;
                }
                else
                {
                    return lengths[3].Count;
                }
            }
            return arounds;
        }
        #endregion

    }
}
