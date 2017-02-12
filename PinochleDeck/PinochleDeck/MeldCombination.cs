using System.Collections.Generic;

namespace PinochleDeck
{
    public class MeldCombination
    {
        public MeldCombination()
        {
            CardCombination = new List<Card>();
        }
        public MeldCombination(Suit TrumpSuit)
        {
            this.TrumpSuit = TrumpSuit;
            CardCombination = new List<Card>();
        }
        public int Id { get; set; }
        public int MeldTypeId { get; set; }
        public string Name { get; set; }
        public List<Card> CardCombination { get; set; }
        public MeldType MeldType { get; set; }
        public Suit TrumpSuit { get; set; }
    }
   
}