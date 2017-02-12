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
            //TestEmpty(deck);
            //FunwithStrings();
            //TestDealer();
            //TestDeckIntIndex();
            //TestHasAceExtensionMethod();
            //TestHasRun();
            //CutCards();
            //MimicPlay();
            //TestRiffleCards();
            TestMeld();
        }

        private static void TestMeld()
        {
            var player = new PinochlePlayer();

            var playerCards = new List<Card>()
            {
                 new Card(new Hearts(), "ace", 1),
                 new Card(new Hearts(), "king", 1),
                 new Card(new Hearts(), "queen", 1),
                 new Card(new Hearts(), "jack", 1),
                 new Card(new Hearts(), "ten", 1),

                 new Card(new Hearts(), "ace", 2),
                 new Card(new Hearts(), "king", 2),
                 new Card(new Hearts(), "queen", 2),
                 new Card(new Hearts(), "jack", 2),
                 new Card(new Hearts(), "ten", 2),

                 new Card(new Clubs(), "ace", 1),
                 new Card(new Clubs(), "king", 1),
                 new Card(new Clubs(), "queen", 1),
                 new Card(new Clubs(), "jack", 1),
                 new Card(new Clubs(), "ten", 1),

                 new Card(new Clubs(), "ace", 2),
                 new Card(new Clubs(), "king", 2),
                 new Card(new Clubs(), "queen", 2),
                 new Card(new Clubs(), "jack", 2),
                 new Card(new Clubs(), "ten", 2),

                 new Card(new Diamonds(), "ace", 1),
                 new Card(new Diamonds(), "king", 1),
                 new Card(new Diamonds(), "jack", 1),

                 new Card(new Spades(), "ace", 1),
                 new Card(new Spades(), "queen", 1),


            };

            foreach (var card in playerCards)
            {
                player.Hand.Cards.Add(card);
            }

            player.DeclareTrumpSuit(new Hearts());

            var meld = new Meld(player.Hand);

            var runs = meld.Runs();

            var royalMarriages = meld.RoyalMarriages();

            var marriages = meld.Marriages();

            var pinochles = meld.Pinochles();

            var acesAround = meld.AcesAround();

            var kingsAround = meld.KingsAround();

            var queensAround = meld.QueensAround();

            var jacksAround = meld.JacksAround();

            Console.WriteLine($"runs: {runs.ToString()} royal marriages: {royalMarriages.ToString()} marriages: {marriages.ToString()} \n" +
                              $"Pinochles: {pinochles.ToString()} \n" +
                              $"Aces Around: {acesAround.ToString()} Kings Around: {kingsAround.ToString()} \n" + 
                              $"Queens Aound: {queensAround.ToString()} Jacks Around: {jacksAround.ToString()}");
            Console.ReadLine();
        }

        private static void MimicPlay()
        {
            var dealer = new PinochleDealer();
            
            var players = new List<PinochlePlayer>()
            {
                new PinochlePlayer() { Name = "Lonnie"},
                new PinochlePlayer() { Name = "Parker"},
                new PinochlePlayer() { Name = "Steph"},
                new PinochlePlayer() { Name = "Mike"},
            };

            dealer.Shuffle();
            dealer.CutCards();

            for (int i = 0; i < 3; i++)
            {
                dealer.RiffleCards();
            }

            while(dealer.Deck.Cards.Count > 0)
            {
                foreach(var player in players)
                {
                    player.Hand.Cards.AddRange(dealer.Deal(5));
                }
                                     
            }

            foreach (var player in players)
            {
                foreach (var card in player.Hand.Cards)
                {
                    Console.WriteLine($"{player.Name}: {card.Value} of {card.Suit.Name} : {card.SameCardIndex.ToString()}");
                }
                Console.WriteLine("\n");
            }

            
            Console.ReadLine();
        }

        private static void CutCards()
        {
            var dealer = new PinochleDealer();

            var dealerCards = dealer.Deck.Cards;

            foreach (var card in dealerCards.Take(5))
            {
                Console.WriteLine($"{card.Value} of {card.Suit.Name} : {card.SameCardIndex.ToString()}");

            }
            Console.WriteLine("\n");
            dealer.CutCards();

            var afterCut = dealer.Deck.Cards;

            foreach(var card in afterCut.Take(5))
            {
                Console.WriteLine($"{card.Value} of {card.Suit.Name} : {card.SameCardIndex.ToString()}");
                
            }
            Console.ReadLine();
        }

        private static void TestHasRun()
        {
            var player = new PinochlePlayer();

            var playerCards = new List<Card>()
            {
                 new Card(new Hearts(), "ace", 1),
                 new Card(new Hearts(), "king", 1),
                 new Card(new Hearts(), "queen", 1),
                 new Card(new Hearts(), "jack", 1),
                 new Card(new Hearts(), "ten", 1),

                 new Card(new Spades(), "ace", 1)
            };

            

            foreach (var card in playerCards)
            {
                player.Hand.Cards.Add(card);
            }

            player.DeclareTrumpSuit(new Hearts());

            var nonTrumpCards = player.Hand.NonTrumpCards;
            var aces = player.Hand.Aces;
            foreach (var item in nonTrumpCards)
            {
                Console.WriteLine($"{item.Value} of {item.Suit.Name} : is a non trump suit");
            }

            var answer = player.Hand.IsRun();

            Console.WriteLine($"{answer.ToString()}, {aces.Count.ToString()}");
            Console.ReadLine();
        }

        private static void TestHasAceExtensionMethod()
        {
            var trumpSuit = new Card(new Hearts());
            var hand = new PinochleHand(trumpSuit.Suit);

            var aceOfHearts = new Card(new Hearts(), "ace", 1);
            var aceOfClubs = new Card(new Clubs(), "ace", 1);

            //hand.Hand.Add(aceOfHearts);
            hand.Cards.Add(aceOfClubs);
            var real = hand.TrumpCards.HasAce<Card>();

            var answer = hand.Cards.HasAce<Card>();
            Console.WriteLine(answer.ToString() + "  " + real.ToString());
            Console.ReadLine();
        }

        static void TestDeckIntIndex()
        {
            var deck = new Deck();
            var card = deck[1];

            Console.WriteLine(card.Value);
            Console.ReadLine();
        }

        static public void TestEmpty(Deck d)
        {

            bool empty = d.Empty;
            int count = d.Count;
            Console.WriteLine(empty.ToString() + " " + count.ToString());
            Console.ReadLine();

        }
        #region FunWithStringsMethod
        static public void FunwithStrings()
        {
            Deck d1 = new Deck();
            Deck d2 = new Deck();

            var deck1 = d1.Cards;//FillStringArrayCards();

            var deck2 = d2.Cards;//FillListCards();

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
        #endregion

        static public void TestDealer()
        {
            var deck = new Deck();
            var dealer = new PinochleDealer();



            dealer.Shuffle();
            var stuff = dealer.ShowCards();
            Console.WriteLine(stuff);
            Console.ReadLine();
        }

        private static void TestRiffleCards()  //TODO: actually test 
        {
            var dealer = new PinochleDealer();

            var dealerCards = dealer.Deck.Cards;

            foreach (var card in dealerCards.Take(5))
            {
                Console.WriteLine($"{card.Value} of {card.Suit.Name} : {card.SameCardIndex.ToString()}");

            }
            Console.WriteLine("\n");
            dealer.RiffleCards();

            var afterRiffle = dealer.Deck.Cards;

            foreach (var card in afterRiffle)
            {
                Console.WriteLine($"{card.Value} of {card.Suit.Name} : {card.SameCardIndex.ToString()}");

            }
            Console.ReadLine();
        }
    }
}
