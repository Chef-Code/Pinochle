using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PinochleDeck
{
    class Deck
    {
        public string face;
        public string suit;
        public string indexedCard;

        public string[] suits = new string[4] { "clubs", "diamonds", "hearts", "spades" };
        public string[] faces = new string[5] { "jack", "queen", "king", "ten", "ace" };
        public string[] indexedCards = new string[80];

        public int deckIndex;
        public int[] sameCardIndex = new int[4] {1,2,3,4};

        public List<Card> listCards = new List<Card>();

        public Deck()
        {
            this.Cards = new List<Card>();
        }

        public int Count { get; set; }

        public List<Card> Cards { get; set; }

        public string[] FillStringArrayCards()
        {
            deckIndex = 0;

            for(int x = 0; x <= 3; x++)
            {
                for (int i = 0; i < faces.Count(); i++)
                {
                    face = faces[i].ToString();

                    for (int k = 0; k < suits.Count(); k++)
                    {
                        suit = suits[k].ToString();
                        indexedCard = face + suit + sameCardIndex[x].ToString();

                        indexedCards[deckIndex] += indexedCard;
                        deckIndex++;
                    }
                }     
            }

            return indexedCards;
        }

        public List<Card> FillListCards()
        {
            for (int x = 0; x <= 3; x++)
            {
                for (int i = 0; i < faces.Count(); i++)
                {
                    for (int k = 0; k < suits.Count(); k++)
                    {
                        Card newCard = new Card(suits[k], faces[i], sameCardIndex[x]);
                        listCards.Add(newCard);
                    }
                }
            }

            return listCards;
        }


    }
}
