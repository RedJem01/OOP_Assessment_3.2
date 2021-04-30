using System;
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

        //Initializing the Cards list using the deck class constructor
        public Deck()
        {
            //Making each card and adding it to the list
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
                //making two random numbers and then swapping the cards a those numbers position
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
            //Objects for humand and computer class
            Human h = new Human();
            Computer c = new Computer();
            Random rnd = new Random();

            //If it is pvp then add 10 cards to the two human hands
            if (opponent == "P")  
            {
                for (int i = 0; i < 10; i++)
                {
                    int rnum = rnd.Next(1, 52);
                    Card cardToAdd = Cards[rnum];
                    h.hand.Add(cardToAdd);
                    Cards.Remove(cardToAdd);
                }
                for (int i = 0; i < 10; i++)
                {
                    int rnum = rnd.Next(1, 52);
                    Card cardToAdd = Cards[rnum];
                    h.hand2.Add(cardToAdd);
                }
            }
            //If it is pvc then add 10 cards to the human and the computer hand
            else
            {
                for (int i = 0; i > 10; i++)
                {
                    int rnum = rnd.Next(1, 52);
                    Card cardToAdd = Cards[rnum];
                    h.hand.Add(cardToAdd);
                    Cards.Remove(cardToAdd);
                }
                for (int i = 0; i > 10; i++)
                {
                    int rnum = rnd.Next(1, 52);
                    Card cardToAdd = Cards[rnum];
                    h.chand.Add(cardToAdd);
                }
            }

        }
    }
}
