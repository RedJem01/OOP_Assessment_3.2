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

        private Hand _hand;
        public Hand hand
        {
            get { return _hand; }
            set { _hand = value; }
        }


        public Player()
        {
            hand = new List<Card>(10);
        }

        //Player methods
        public abstract (int, int) Play(List<Card> hand);
        public static int cardNumCheck(Card card)
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
    }

    //Human class inherited from Player class
    class Human : Player
    {
        public override (int, int) Play(List<Card> hand)
        {
            int j = 1;
            Console.WriteLine("Here is your hand: ");
            foreach (Card i in hand)
            {
                Console.WriteLine($"{j}: {i.num} of {i.suit}");
                j++;
            }
            Console.WriteLine("Please choose 2 cards by writing out the number before the card");
            //Input for card 1
            Console.WriteLine("Card 1: ");
            int cardValue = cardInput();

            //Input for card 2
            Console.WriteLine("Card 2: ");
            int cardValue2 = cardInput();
                    
            
            return (cardValue, cardValue2);
        }

        public int cardInput()
        {
            bool loop_done = true;
            while (loop_done == true)   //Loop to reinput if input is wrong
            {
                try
                {
                    string cardChoice = Console.ReadLine();
                    Card card = hand[int.Parse(cardChoice)];
                    loop_done = false;
                    int cardValue = cardNumCheck(card);
                    return cardValue;
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
        public override (int, int) Play(List<Card> hand)
        {
            Console.WriteLine("Computers turn");
            Random rnd = new Random();

            //Selecting a random card
            int rnum1 = rnd.Next(0, 9);
            Card cp_card1 = hand[rnum1];
            hand.Remove(hand[rnum1]);
            Card cpCard1 = cp_card1; 
            int cp_card1_num = cardNumCheck(cpCard1);

            //Selecting a second random card
            int rnum2 = rnd.Next(0, 9);
            Card cp_card2 = hand[rnum2];
            hand.Remove(hand[rnum2]);
            Card cpCard2 = cp_card2;
            int cp_card2_num = cardNumCheck(cpCard2);

            return (cp_card1_num, cp_card2_num);
        }
    }
}
