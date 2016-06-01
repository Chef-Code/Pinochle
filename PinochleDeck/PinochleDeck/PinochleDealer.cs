using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PinochleDeck
{
    public class PinochleDealer
    {
        private Deck deck;
        public PinochleDealer()
        {
            deck = new Deck();
        }

        public Deck Shuffle()
        {
            var shuffledDeck = new Deck();
            var tmpCard = new Card();

            Random rand = new Random();
            
            deck.FillListCards();
            while(!deck.Empty)
            {
                var i = rand.Next(0, deck.Count);
                var card = deck[deck[i]];
            }
            

            return shuffledDeck;
        }
    }
}
