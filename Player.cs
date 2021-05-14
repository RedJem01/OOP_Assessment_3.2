using System;
using System.Collections.Generic;

namespace OOP_assessment_3
{
    //Interface
    interface IPlayer
    {
        public int Score { get; set; }

        public Hand handList { get; set; }

        public abstract int Play(List<Card> hand);

        public abstract int cardNumCheck(Card card);
    }

    //Player class
    abstract class Player : IPlayer
    {
        //Player attributes
        private int _Score;
        public int Score
        {
            get { return _Score; }
            set { _Score = value; }
        }

        private Hand _handList;
        public Hand handList
        {
            get
            {
                if (_handList == null)
                {
                    _handList = new Hand();
                }
                return _handList;
            }
            set { _handList = value; }
        }

        //Player methods
        public abstract int Play(List<Card> hand);
        public int cardNumCheck(Card card)
        {
            int card_num = 0;
            if (card.num == "Ace")
            {
                card_num = 14;
            }
            else if (card.num == "2")
            {
                card_num = 2;
            }
            else if (card.num == "3")
            {
                card_num = 3;
            }
            else if (card.num == "4")
            {
                card_num = 4;
            }
            else if (card.num == "5")
            {
                card_num = 5;
            }
            else if (card.num == "6")
            {
                card_num = 6;
            }
            else if (card.num == "7")
            {
                card_num = 7;
            }
            else if (card.num == "8")
            {
                card_num = 8;
            }
            else if (card.num == "9")
            {
                card_num = 9;
            }
            else if (card.num == "10")
            {
                card_num = 10;
            }
            else if (card.num == "Jack")
            {
                card_num = 11;
            }
            else if (card.num == "Queen") 
            {
                card_num = 12;
            }
            else if (card.num == "King")
            {
                card_num = 13;
            }
            return card_num;
        }

        public int cardNumCheck(string card)
        {
            int card_num = 0;
            if (card == "Ace")
            {
                card_num = 14;
            }
            else if (card == "2")
            {
                card_num = 2;
            }
            else if (card == "3")
            {
                card_num = 3;
            }
            else if (card == "4")
            {
                card_num = 4;
            }
            else if (card == "5")
            {
                card_num = 5;
            }
            else if (card == "6")
            {
                card_num = 6;
            }
            else if (card == "7")
            {
                card_num = 7;
            }
            else if (card == "8")
            {
                card_num = 8;
            }
            else if (card == "9")
            {
                card_num = 9;
            }
            else if (card == "10")
            {
                card_num = 10;
            }
            else if (card == "Jack")
            {
                card_num = 11;
            }
            else if (card == "Queen")
            {
                card_num = 12;
            }
            else if (card == "King")
            {
                card_num = 13;
            }
            return card_num;
        }
    }

    //Human class inherited from Player class
    class Human : Player
    {
        public override int Play(List<Card> hand)
        {
            int j = 1;
            Console.WriteLine("Here is your hand: ");
            foreach (Card i in hand)
            {
                Console.WriteLine($"{j}: {i.num} of {i.suit}");
                j++;
            }
            Console.WriteLine("\nPlease choose 2 cards by writing out the number before the card");

            //Input for card 1
            Console.WriteLine("Card 1: ");
            int cardValue = cardGet(hand);


            int k = 1;
            Console.WriteLine("\nHere is your hand: ");
            foreach (Card i in hand)
            {
                Console.WriteLine($"{k}: {i.num} of {i.suit}");
                k++;
            }

            //Input for card 2
            Console.WriteLine("Card 2: ");
            int cardValue2 = cardGet(hand);

            int total = cardValue + cardValue2;
            
            return total;
        }

        public int cardGet(List<Card> hand)
        {
            bool loop_done = true;
            while (loop_done == true)   //Loop to reinput if input is wrong
            {
                try
                {
                    string cardChoice = Console.ReadLine();
                    try
                    {
                        int icardChoice = int.Parse(cardChoice);
                        if (icardChoice > hand.Count || icardChoice < 1)
                        {
                            throw new WrongInputException("That is the wrong input. Please input a number in front of the card.");
                        }
                        else
                        {
                            Card card = hand[icardChoice - 1];
                            hand.RemoveAt(icardChoice - 1);
                            loop_done = false;
                            int cardValue = cardNumCheck(card);
                            return cardValue;
                        }
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("That is not a number. Please input a number in front of the card.");
                    }
                    
                }
                catch (WrongInputException e)
                {
                    //Ouputs exception message and then loops again
                    Console.WriteLine(e.Message);
                }
            }
            return 1;
        }
    }

    //Computer class
    class Computer : Player
    {
        public override int Play(List<Card> hand)
        {
            Console.WriteLine("\nComputers turn");
            Random rnd = new Random();

            //Selecting a random card
            int rnum1 = rnd.Next(0, hand.Count - 1);
            Card cp_card1 = hand[rnum1];
            hand.Remove(hand[rnum1]);
            Card cpCard1 = cp_card1; 
            int cp_card1_num = cardNumCheck(cpCard1.num);

            //Selecting a second random card
            int rnum2 = rnd.Next(0, hand.Count - 1);
            Card cp_card2 = hand[rnum2];
            hand.Remove(handList.hand[rnum2]);
            Card cpCard2 = cp_card2;
            int cp_card2_num = cardNumCheck(cpCard2.num);

            int total = cp_card1_num + cp_card2_num;

            return total;
        }
    }
}
