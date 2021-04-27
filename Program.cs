using System;
using System.Collections.Generic;

namespace OOP_assessment_3
{
    //For exception handling
    class WrongInputException : Exception
    {
        public WrongInputException(string message) : base(message) { }

    }
    //Program class
    class Program
    {

        //Where the program runs
        static void Main(string[] args)
        {
            //Making objects so we can use the class attributes
            Deck d = new Deck();
            Human h = new Human();
            Computer cp = new Computer();
            Program p = new Program();

            string opponent;

            Console.WriteLine("Welcome to Lincoln. A card game where you and your opponent choose two cards and whoever has the highest total wins the round.");
            Console.WriteLine("Would you like to play 2 player or against a computer? P or C?");
            string input = Console.ReadLine();

            bool done = true;
            while (done == true)
            {
                try
                {
                    Console.WriteLine("Would you like  to play against another player or the computer? (P or C?)");
                    string choice = Console.ReadLine();
                    if ((input == "P") || (input == "p"))
                    {
                        opponent = "P";
                        p.PvP(opponent);
                        done = false;
                    }
                    else if ((input == "C") || (input == "c"))
                    {
                        opponent = "C";
                        p.PvC(opponent);
                        done = false;
                    }
                    else
                    {
                        throw new WrongInputException("That is the wrong input. Please input P or C.");

                    }
                }
                catch (WrongInputException e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            //Shuffling the deck
            d.Shuffle();
        }
        //For player vs computer 
        public void PvC(string opponent)
        {
            Human h = new Human();
            Computer c = new Computer();
            Deck d = new Deck();
            //Dealing the cards out
            d.Deal(opponent);
            Console.WriteLine($"Here is your hand: {h.hand}");        //Fix the hands you need to make a computer hand and a player 2 hand
        }

        //For player vs player
        public void PvP(string opponent)
        {
            Human h = new Human();
            Human h2 = new Human();
            Deck d = new Deck();
            //Dealing the cards out
            d.Deal(opponent);
            Console.WriteLine("Player 1's turn.");
            h.Play(h.hand);
            h.Play(h2.hand);
        }
    }
}