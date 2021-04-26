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

        private List<Hand> _pHand;

        public List<Hand> pHand
        {
           get { return _pHand; }
            set { _pHand = value; }
        }

        private List<Hand> _cHand;
        public List<Hand> cHand
        {
            get { return _cHand; }
            set { _cHand = value; }
        }

        public Player()
        {
            pHand = new List<Hand>(10);
            cHand = new List<Hand>(10);
        }

        public abstract void Play();
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
            object cp_card1 = cHand[rnum1];
            int rnum2 = rnd.Next(1, 10);
        }
    }
}
