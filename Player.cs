using System;
using System.Collections.Generic;

namespace OOP_assessment_3
{
    //Player class
    abstract class Player
    {
        //Player attributes
        private int _Score;
        public int Score
        {
            get { return _Score; }
            set { _Score = value; }
        }

        private int _ID;
        public int ID
        {
            get { return _ID; }
            set { _ID = value; }
        }

        private List<Card> _hand;
        public List<Card> hand
        {
            get { return _hand; }
            set { _hand = value; }
        }

        private List<Card> _hand2;
        public List<Card> hand2
        {
            get { return _hand2; }
            set { _hand2 = value; }
        }

        private List<Card> _chand;
        public List<Card> chand
        {
            get { return _chand; }
            set { _chand = value; }
        }

        public Player()
        {
            hand = new List<Card>(10);
            hand2 = new List<Card>(10);
            chand = new List<Card>(10);
        }

        //Player methods
        public abstract (int, int) Play(List<Card> hand);
        public int cardNumCheck(Card _card)
        {
            string card = _card.ToString();
            int card_num = 0;
            if (card.Contains("Ace") == true)
            {
                card_num = 14;
            }
            else if (card.Contains("2") == true)
            {
                card_num = 2;
            }
            else if (card.Contains("3") == true)
            {
                card_num = 3;
            }
            else if (card.Contains("4") == true)
            {
                card_num = 4;
            }
            else if (card.Contains("5") == true)
            {
                card_num = 5;
            }
            else if (card.Contains("6") == true)
            {
                card_num = 6;
            }
            else if (card.Contains("7") == true)
            {
                card_num = 7;
            }
            else if (card.Contains("8") == true)
            {
                card_num = 8;
            }
            else if (card.Contains("9") == true)
            {
                card_num = 9;
            }
            else if (card.Contains("10") == true)
            {
                card_num = 10;
            }
            else if (card.Contains("Jack") == true)
            {
                card_num = 11;
            }
            else if (card.Contains("Queen") == true)
            {
                card_num = 12;
            }
            else if (card.Contains("King") == true)
            {
                card_num = 13;
            }
            return card_num;
        }
    }

    //Human class inherited from Player class
    class Human : Player
    {
        public override (int, int) Play(List<Card> hand)
        {
            Deck d = new Deck(); //Making an object from the deck class
            Console.WriteLine("Here is your hand: ");
            foreach (Card i in hand)
            {
                Console.WriteLine(i.num + " of " + i.suit);
            }
            Console.WriteLine("Please choose 2 cards by writing out the exact card. (rank) of (suit)");
            bool loop_done = true;
            while (loop_done == true)   //Loop to reinput if input is wrong
            {
                try
                {
                    //Input for card 1
                    Console.WriteLine("Card 1 rank: ");
                    string card1Rank = Console.ReadLine();
                    Console.WriteLine("Card 1 suit: ");
                    string card1Suit = Console.ReadLine();
                    foreach (Card i in hand)
                    {
                        if ((i.num == card1Rank) && (i.suit == card1Suit))
                        {
                            loop_done = false;
                        }
                        else
                        {
                            //If they are not in the hand then throw exception
                            throw new WrongInputException("That is the wrong input. Please input a card in your hand.");
                        }

                    }

                    //Input for card 2
                    Console.WriteLine("Card 2: ");
                    object _card2 = Console.ReadLine();
                    Card card2 = (Card)_card2;
                    //Checking if the cards that were inputted are in the hand
                    if ((hand.Contains(card1) == true) && (hand.Contains(card2)))
                    {
                        loop_done = false;
                        //Call the cardNumCheck to find out the value of the card
                        int card1_num = cardNumCheck(card1);
                        int card2_num = cardNumCheck(card2);
                        return (card1_num, card2_num);
                    }
                    else
                    {
                        //If they are not in the hand then throw exception
                        throw new WrongInputException("That is the wrong input. Please input a card in your hand.");
                    }
                }
                catch (WrongInputException e)
                {
                    //Ouputs exception message and then loops again
                    Console.WriteLine(e.Message);
                }
            }
            return (1, 1);
        }
    }

    //Computer class
    class Computer : Player
    {
        public override (int, int) Play(List<Card> hand)
        {
            Console.WriteLine("Computers turn");
            Random rnd = new Random();

            //Selecting a random card
            int rnum1 = rnd.Next(1, 10);
            Card cp_card1 = hand[rnum1];
            hand.Remove(hand[rnum1]);
            int cp_card1_num = cardNumCheck(cp_card1);

            //Selecting a second random card
            int rnum2 = rnd.Next(1, 10);
            Card cp_card2 = hand[rnum2];
            hand.Remove(hand[rnum2]);
            int cp_card2_num = cardNumCheck(cp_card2);

            return (cp_card1_num, cp_card2_num);
        }
    }
}
