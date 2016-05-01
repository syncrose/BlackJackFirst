using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlackJackFirst
{
    public class Program
    {
        public static void Main(string[] args)
        {

            Console.WriteLine("Would you like to play Blackjack?");
            if (Console.ReadLine() == "yes")
            {

                var player1 = CreatePlayer.createPlayer();
                var dealer = CreatePlayer.createPlayer();

                var deck = CreateDeck.createDeck();


                var newDeck = new List<Card>();

                Random rand = new Random();


                while (deck.Count > 0)
                {
                    var randDeck = rand.Next(deck.Count);

                    newDeck.Add(new Card(deck[randDeck].Id, deck[randDeck].Suit, deck[randDeck].Value, deck[randDeck].Title));

                    deck.RemoveAt(randDeck);

                }

                while (newDeck.Count > 12)
                {
                    //MAIN GAME CODE LOGIC
                    for (var i = 0; i < 2; i++)
                    {
                        player1.Hand.Add(newDeck[i]);
                        newDeck.RemoveAt(i);
                    }
                    for (var i = 0; i < 2; i++)
                    {
                        dealer.Hand.Add(newDeck[i]);
                        newDeck.RemoveAt(i);
                    }



                    Console.WriteLine("You have the {0}", player1.Hand[0].Title);
                    Console.WriteLine("And the {0}", player1.Hand[1].Title);
                    Console.ReadLine();

                    Console.WriteLine("the dealer has the {0}", dealer.Hand[0].Title);
                    Console.ReadLine();

                    var playerScore = player1.getScore();
                    var dealerScore = dealer.getScore();

                    Console.WriteLine("Would you like to hit or stay?");

                    var playing = true;
                    while (playing)
                    {

                        Game.Hit(newDeck, player1, playerScore);

                        if (Console.ReadLine() == "hit")
                        {

                            player1.Hand.Add(newDeck[0]);
                            newDeck.RemoveAt(0);
                            playerScore = playerScore + player1.Hand[2].Value;
                            Console.WriteLine("You have the {0} for a total of {1}", player1.Hand[2].Title, playerScore);
                            Console.ReadLine();

                            if (playerScore > 21)
                            {
                                Console.WriteLine("You have busted! you loser!!");
                                playing = false;
                                //player1.clearHand();
                                //dealer.clearHand();
                            }

                            Console.WriteLine("Would you like to hit or stay?");

                            if (Console.ReadLine() == "hit")
                            {

                                player1.Hand.Add(newDeck[0]);
                                newDeck.RemoveAt(0);
                                playerScore = playerScore + player1.Hand[2].Value;
                                Console.WriteLine("You have the {0} for a total of {1}", player1.Hand[2].Title, playerScore);
                                Console.ReadLine();

                                if (playerScore > 21)
                                {
                                    Console.WriteLine("You have busted! you loser!!");
                                    playing = false;
                                    //player1.clearHand();
                                    //dealer.clearHand();
                                }

                            }

                        }




                        if (dealerScore < 17)
                        {
                            dealer.Hand.Add(newDeck[0]);
                            newDeck.RemoveAt(0);
                            dealerScore = dealerScore + dealer.Hand[2].Value;


                        }

                        if (dealerScore > 21)
                        {
                            Console.WriteLine("The dealer has busted, you have won!");
                            playing = false;
                            //player1.clearHand();
                            //dealer.clearHand();
                        }

                        for (int i = 0; i < dealer.Hand.Count; i++)
                        {
                            Console.WriteLine("The dealer has {0}", dealer.Hand[i].Title);

                            Console.ReadLine();
                        }


                        if (playerScore > dealerScore)
                        {
                            Console.WriteLine("You have won!");
                            playing = false;
                            //player1.clearHand();
                            //dealer.clearHand();
                        }
                        else if (playerScore < dealerScore)
                        {
                            Console.WriteLine("You have lost!");
                            playing = false;
                            //player1.clearHand();
                            //dealer.clearHand();
                        }






                    }

                }


                ///////////////////////////// END OF CODE GAME ////////////////////////////////
            }
            ////////////////////////////ELSE EXIT GAME ///////////////////////////////////

            else
            {
                Console.WriteLine("Bye then jerk, I didn't want to play anyway");
                Console.ReadLine();
            }




        }


    }
    public class ShuffleDeck
    {
        public List<Card> NewDeck { get; set; }

    }

    public class CreateDeck
    {
        public static List<Card> createDeck()
        {
            var cardList = new List<Card>();
            //Spades
            #region
            cardList.Add(new Card(1, "Spade", 2, "Two of Spades"));
            cardList.Add(new Card(2, "Spade", 3, "Three of Spades"));
            cardList.Add(new Card(3, "Spade", 4, "Four of Spades"));
            cardList.Add(new Card(4, "Spade", 5, "Five of Spades"));
            cardList.Add(new Card(5, "Spade", 6, "Six of Spades"));
            cardList.Add(new Card(6, "Spade", 7, "Seven of Spades"));
            cardList.Add(new Card(7, "Spade", 8, "Eight of Spades"));
            cardList.Add(new Card(8, "Spade", 9, "Nine of Spades"));
            cardList.Add(new Card(9, "Spade", 10, "Ten of Spades"));
            cardList.Add(new Card(10, "Spade", 10, "Jack of Spades"));
            cardList.Add(new Card(11, "Spade", 10, "Queen of Spades"));
            cardList.Add(new Card(12, "Spade", 10, "King of Spades"));
            cardList.Add(new Card(13, "Spade", 11, "Ace of Spades"));

            //Clubs
            cardList.Add(new Card(14, "Club", 2, "Two of Clubs"));
            cardList.Add(new Card(15, "Club", 3, "Three of Clubs"));
            cardList.Add(new Card(16, "Club", 4, "Four of Clubs"));
            cardList.Add(new Card(17, "Club", 5, "Five of Clubs"));
            cardList.Add(new Card(18, "Club", 6, "Six of Clubs"));
            cardList.Add(new Card(19, "Club", 7, "Seven of Clubs"));
            cardList.Add(new Card(20, "Club", 8, "Eight of Clubs"));
            cardList.Add(new Card(21, "Club", 9, "Nine of Clubs"));
            cardList.Add(new Card(22, "Club", 10, "Ten of Clubs"));
            cardList.Add(new Card(23, "Club", 10, "Jack of Clubs"));
            cardList.Add(new Card(24, "Club", 10, "Queen of Clubs"));
            cardList.Add(new Card(25, "Club", 10, "King of Clubs"));
            cardList.Add(new Card(26, "Club", 11, "Ace of Clubs"));

            //Diamonds
            cardList.Add(new Card(27, "Diamond", 2, "Two of Diamonds"));
            cardList.Add(new Card(28, "Diamond", 3, "Three of Diamonds"));
            cardList.Add(new Card(29, "Diamond", 4, "Four of Diamonds"));
            cardList.Add(new Card(30, "Diamond", 5, "Five of Diamonds"));
            cardList.Add(new Card(31, "Diamond", 6, "Six of Diamonds"));
            cardList.Add(new Card(32, "Diamond", 7, "Seven of Diamonds"));
            cardList.Add(new Card(33, "Diamond", 8, "Eight of Diamonds"));
            cardList.Add(new Card(34, "Diamond", 9, "Nine of Diamonds"));
            cardList.Add(new Card(35, "Diamond", 10, "Ten of Diamonds"));
            cardList.Add(new Card(36, "Diamond", 10, "Jack of Diamonds"));
            cardList.Add(new Card(37, "Diamond", 10, "Queen of Diamonds"));
            cardList.Add(new Card(38, "Diamond", 10, "King of Diamonds"));
            cardList.Add(new Card(39, "Diamond", 11, "Ace of Diamonds"));

            //Hearts
            cardList.Add(new Card(40, "Heart", 2, "Two of Spades"));
            cardList.Add(new Card(41, "Heart", 3, "Three of Hearts"));
            cardList.Add(new Card(42, "Heart", 4, "Four of Hearts"));
            cardList.Add(new Card(43, "Heart", 5, "Five of Hearts"));
            cardList.Add(new Card(44, "Heart", 6, "Six of Hearts"));
            cardList.Add(new Card(45, "Heart", 7, "Seven of Hearts"));
            cardList.Add(new Card(46, "Heart", 8, "Eight of Hearts"));
            cardList.Add(new Card(47, "Heart", 9, "Nine of Hearts"));
            cardList.Add(new Card(48, "Heart", 10, "Ten of Hearts"));
            cardList.Add(new Card(49, "Heart", 10, "Jack of Hearts"));
            cardList.Add(new Card(50, "Heart", 10, "Queen of Hearts"));
            cardList.Add(new Card(51, "Heart", 10, "King of Hearts"));
            cardList.Add(new Card(52, "Heart", 11, "Ace of Hearts"));
            #endregion

            return cardList;
        }
    }




    public class Card
    {
        public int Id { get; set; }
        public string Suit { get; set; }
        public int Value { get; set; }
        public string Title { get; set; }


        public Card(int id, string suit, int value, string title)
        {
            this.Id = id;
            this.Suit = suit;
            this.Value = value;
            this.Title = title;
        }
    }

    public class Player
    {
        public string Name { get; set; }
        public List<Card> Hand { get; set; }
        public int Score { get; set; }

        public Player(string name, List<Card> hand, int score)
        {
            this.Name = name;
            this.Hand = hand;
            this.Score = score;
        }
        public int getScore()
        {

            return Hand[0].Value + Hand[1].Value;


        }

        public void clearHand()
        {
            this.Hand.Clear();
        }


    }

    public class CreatePlayer
    {
        public static Player createPlayer()
        {
            var newPlayer = new Player("Player 1", new List<Card>(), 0);
            return newPlayer;
        }
    }

    public class Game
    {

        public static void Hit(List<Card> deck, Player player, int score)
        {
            if (Console.ReadLine() == "hit")
            {

                player.Hand.Add(deck[0]);
                deck.RemoveAt(0);
                score = score + player.Hand[2].Value;
                Console.WriteLine("You have the {0} for a total of {1}", player.Hand[2].Title, score);
                Console.ReadLine();

            }

        }
    }
}







