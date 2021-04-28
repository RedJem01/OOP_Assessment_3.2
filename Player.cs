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

        public abstract int Play(List<Card> hand);
    }

    class Human : Player
    {
        public override int Play(List<Card> hand)
        {
            Deck d = new Deck();
            int total = 0;
            Console.WriteLine($"Here is your hand: {hand}");
            Console.WriteLine("Please choose 2 cards.");
            bool loop_done = true;
            while (loop_done == true)
            {
                try
                {
                    Console.WriteLine("Card 1 rank: ");
                    string card1_rank = Console.ReadLine();
                    foreach (string i in hand)
                    {
                        if (card1_rank == i.suit)
                        {
                            loop_done = false;
                        }
                        else
                        {
                            throw new WrongInputException("That is the wrong input. Please input a card in your hand.");
                        }

                    }
                }
                catch (WrongInputException e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            loop_done = true;
            while (loop_done == true)
            {
                try
                {
                    Console.WriteLine("Card 2: ");
                    string card2 = Console.ReadLine();
                    foreach (object i in d.Cards)
                    {
                        int j = Convert.ToInt32(i);
                        object temp = hand[j];
                        if (temp.ToString() == card2)
                        {
                            loop_done = false;
                        }
                        else
                        {
                            throw new WrongInputException("That is the wrong input. Please input a card in your hand.");
                        }

                    }
                }
                catch (WrongInputException e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            int card1_num;
            int card2_num;
            return total;
        }
        public void cardNumCheck(string card)
        {
            int card_num;
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
        }
    }

    class Computer : Player
    {
        public override int Play(List<Card> hand)
        {
            int total = 0;
            Console.WriteLine("Computers turn");
            Random rnd = new Random();
            int rnum1 = rnd.Next(1, 10);
            object cp_card1 = hand[rnum1];
            int rnum2 = rnd.Next(1, 10);
            return total;
        }
    }
}
