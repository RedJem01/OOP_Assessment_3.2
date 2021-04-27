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

        private List<Hand> _hand;
        public List<Hand> hand
        {
            get { return _hand; }
            set { _hand = value; }
        }

        public Player()
        {
            hand = new List<Hand>(10);
        }

        public abstract int Play(List<Hand> handy);
	}

    //Hand class
    class Hand 
    {
        //Hand class attribute
        private List<string> _hand;
        public List<string> hand
        {
            get { return _hand; }
            set { _hand = value; }
        }

        public Hand()
        {
            hand = new List<string>(10);
        }
    }

    class Human : Player 
    {
        public override int Play(List<Hand> handy)
        {
            Deck d = new Deck();
            int total = 0;
            Console.WriteLine($"Here is your hand: {handy}");
            bool loop_done = true;
            while (loop_done == true)
            {
                try
                {
                    Console.WriteLine("Please choose 2 cards.");
                    Console.WriteLine("Card 1: ");
                    string card1 = Console.ReadLine();
                    foreach (object i in d.Cards)
                    {
                        int j = Convert.ToInt32(i);
                        object temp = handy[j];
                        if (temp.ToString() == card1)
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
            return total;
        }
    }

    class Computer : Player
    {
        public override int Play(List<Hand> handy)
        {
            int total = 0;
            Console.WriteLine("Computers turn");
            Random rnd = new Random();
            int rnum1 = rnd.Next(1, 10);
            object cp_card1 = handy[rnum1];
            int rnum2 = rnd.Next(1, 10);
            return total;
        }
    }
}
