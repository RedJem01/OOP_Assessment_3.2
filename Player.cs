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
        public Player(Hand hand)
        {
            _hand = hand;
        }

        public abstract void Play();
	}

    //Hand class
    class Hand 
    {
        //Hand class attribute
        private List<string> _handy;
        public List<string> handy
        {
            get { return _handy; }
            set { _handy = value; }
        }

        public Hand()
        {
            handy = new List<string>(10);
        }
    }

    class Human : Player 
    {
        public override void Play()
        {
            
        }
    }

    class Computer : Player
    {
        public override void Play()
        {
            Console.WriteLine("Computers turn");
            Random rnd = new Random();
            int rnum1 = rnd.Next(1, 10);
            string cp_card1 = 
            int rnum2 = rnd.Next(1, 10);
        }
    }
}
