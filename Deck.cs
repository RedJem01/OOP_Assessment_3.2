﻿using System;
using System.Collections.Generic;

namespace OOP_assessment_3
{ 
    //Deck class
    class Deck
    {

        //Deck class attribute
        private List<Card> _Cards;
        public List<Card> Cards
        {
            get { return _Cards; }
            set { _Cards = value; }
        }

        // initializing the Cards list
        public Deck()
        {
            Cards = new List<Card>(52);
            for (int i = 1; i < 5; i++)
            {
                for (int j = 1; j < 14; j++)
                {
                    Cards.Add(new Card(j, i));
                }
            }
            return;
        }

        //If the deck is empty
        public void isEmpty()
        {
            Console.WriteLine("There are no more cards left.");
        }
        //Shuffling the deck fucntion
        public void Shuffle()
        {
            Console.WriteLine("Shuffling the deck.");
            Random rnd = new Random();
            for (int i = 0; i < 53; i++)
            {
                int rnum1 = rnd.Next(1, 52);
                int rnum2 = rnd.Next(1, 52);
                object a = Cards[rnum1];
                object b = Cards[rnum2];
                Cards[rnum2] = (Card)a;
                Cards[rnum1] = (Card)b;
            }
        }

        //Dealing out the cards function
        public void Deal(string opponent)
        {
            Human h = new Human();
            Computer c = new Computer();

            if (opponent == "P")
            {
                for (int i = 0; i > 10; i++)
                {
                    h.hand.Add(Cards[i]);
                    Cards.Remove(Cards[i]);
                }
                for (int i = 0; i > 10; i++)
                {
                    h.hand2.Add(Cards[i]);
                }
            }
            else
            {
                for (int i = 0; i > 10; i++)
                {
                    h.hand.Add(Cards[i]);
                    Cards.Remove(Cards[i]);
                }
                for (int i = 0; i > 10; i++)
                {
                    c.chand.Add(Cards[i]);
                }
            }

        }
    }
}
