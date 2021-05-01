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

        private int _Score2;
        public int Score2
        {
            get { return _Score2; }
            set { _Score2 = value; }
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

        public Player()
        {
            hand = new List<Card>(10);
            hand2 = new List<Card>(10);
        }

        //Player methods
        public abstract (int, int) Play(List<Card> hand);
        public int cardNumCheck(string card)
        {
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
                            int cardValue = cardNumCheck(card1Rank);
                        }
                        else
                        {
                            //If they are not in the hand then throw exception
                            throw new WrongInputException("That is the wrong input. Please input a card in your hand.");
                        }
                    }
                }
                catch (WrongInputException e)
                {
                    //Ouputs exception message and then loops again
                    Console.WriteLine(e.Message);
                }
            }
            loop_done = true;
            while (loop_done == true)
            {
                try
                {
                    //Input for card 2
                    Console.WriteLine("Card 2 rank: ");
                    string card2Rank = Console.ReadLine();
                    Console.WriteLine("Card 2 suit: ");
                    string card2Suit = Console.ReadLine();
                    foreach (Card i in hand)
                    {
                        if ((i.num == card2Rank) && (i.suit == card2Suit))
                        {
                            loop_done = false;
                            int cardValue2 = cardNumCheck(card2Rank);
                        }
                        else
                        {
                            //If they are not in the hand then throw exception
                            throw new WrongInputException("That is the wrong input. Please input a card in your hand.");
                        }
                    }
                }
                catch (WrongInputException e)
                {
                    //Ouputs exception message and then loops again
                    Console.WriteLine(e.Message);
                }
            }
            return (cardValue, cardValue2);
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
            int rnum1 = rnd.Next(0, 9);
            Card cp_card1 = hand[rnum1];
            hand.Remove(hand[rnum1]);
            string cpCard1Rank = cp_card1.num; 
            int cp_card1_num = cardNumCheck(cpCard1Rank);

            //Selecting a second random card
            int rnum2 = rnd.Next(0, 9);
            Card cp_card2 = hand[rnum2];
            hand.Remove(hand[rnum2]);
            string cpCard2Rank = cp_card2.num;
            int cp_card2_num = cardNumCheck(cpCard2Rank);

            return (cp_card1_num, cp_card2_num);
        }
    }
}
