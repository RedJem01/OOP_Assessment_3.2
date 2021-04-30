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

            ////Making objects so we can use the class attributes
            Deck d = new Deck();
            Program p = new Program();
            //For testing purposes
            //foreach (Card i in d.Cards)
            //{
            //    Console.WriteLine(i.num + " of " + i.suit);
            //}

            string opponent;

            //Introduction and instructions
            Console.WriteLine("Welcome to Lincoln. A card game where you and your opponent choose two cards and whoever has the highest total wins the round.");

            //Shuffling the deck
            d.Shuffle();

            //Checking if they want to play against a computer or another player
            bool done = true;
            while (done == true)
            {
                try
                {
                    Console.WriteLine("Would you like  to play against another player or the computer? (P or C?)");
                    string input = Console.ReadLine();
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
        }
        //For player vs computer 
        public void PvC(string opponent)
        {
            Human h = new Human();
            Computer c = new Computer();
            Deck d = new Deck();
            //Dealing the cards out
            d.Deal(opponent);
            //Calling the play function for the player and the computer
            h.Play(h.hand);
            c.Play(c.chand);
        }

        //For player vs player
        public void PvP(string opponent)
        {
            Human h = new Human();
            Deck d = new Deck();
            //Dealing the cards out
            d.Deal(opponent);
            Console.WriteLine("Player 1's turn.");
            h.Play(h.hand);
            Console.WriteLine("Player 2's turn.");
            h.Play(h.hand);
        }
    }
}