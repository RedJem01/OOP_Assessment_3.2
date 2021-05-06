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
            Console.WriteLine("\nShuffling the deck\n");
            Random rnd = new Random();
            for (int i = 0; i < 53; i++)
            {
                //making two random numbers and then swapping the cards a those numbers position
                int rnum1 = rnd.Next(52);
                int rnum2 = rnd.Next(52);
                object a = Cards[rnum1];
                object b = Cards[rnum2];
                Cards[rnum2] = (Card)a;
                Cards[rnum1] = (Card)b;
                
            }
            //foreach (Card j in Cards)
            //{
            //    Console.WriteLine($"{j.num} of {j.suit}");
            //}
        }

        //Dealing out the cards function
        public (List<Card>, List<Card>) Deal(List<Card> hand1, List<Card> hand2)
        {
            Random rnd = new Random();

            for (int i = 0; i < 10; i++)
            {
                int rnum = rnd.Next(52 - i);
                Card cardToAdd = Cards[rnum];
                hand1.Add(cardToAdd);
                Cards.Remove(cardToAdd);
            }
            //foreach (Card i in h.handList.hand)
            //{
            //    Console.WriteLine($"{i.num} of {i.suit}");
            //}
            for (int i = 0; i < 10; i++)
            {
                int rnum = rnd.Next(52 - (i + 10));
                Card cardToAdd = Cards[rnum];
                hand2.Add(cardToAdd);
            }
            //foreach (Card i in c.handList.hand)
            //{
            //    Console.WriteLine($"{i.num} of {i.suit}");
            //}
            return (hand1, hand2);
        }
    }
}
