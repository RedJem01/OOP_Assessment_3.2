using System;
using System.Collections.Generic;

namespace OOP_assessment_3
{
    //Program class
    class Program
    {
        class WrongInputException : Exception
        {
            public WrongInputException(string message) : base(message) { }

        }
        //Where the program runs
        static void Main(string[] args)
        {
            //Making objects so we can use the class attributes
            Deck d = new Deck();
            Human h = new Human();
            Computer cp = new Computer();

            string opponent;

            Console.WriteLine("Welcome to Lincoln. A card game where you and your opponent choose two cards and whoever has the highest total wins the round.");

            //bool done = true;
            //while (done == true)
            //{
            //    try
            //    {
            //        Console.WriteLine("Would you like  to play against another player or the computer? (P or C?)");
            //        string choice = Console.ReadLine();
            //        if ((input == "P") || (input == "p"))
            //        {
            //            opponent = "P";
            //        }
            //        else if ((input == "C") || (input == "c"))
            //        {
            //            opponent = "C";
            //        }
            //        else
            //        {
            //            throw new WrongInputException("That is the wrong input. Please input P or C.");

            //        }
            //    }
            //    catch (WrongInputException e)
            //    {
            //        Console.WriteLine(e.Message);
            //    }
            //}
            //Shuffling the deck
            d.Shuffle();
            d.Deal();
            Console.WriteLine($"Here is your hand: {h.hand}");
            Console.WriteLine("Please choose 2 cards.");
        }
    }
}