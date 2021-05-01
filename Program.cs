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
            Program p = new Program();
            p.Menu();
        }

        public void Menu()
        {
            //Menu
            Console.WriteLine("*****************************");
            Console.WriteLine("* 1. Rules                  *");
            Console.WriteLine("* 2. Play against computer  *");
            Console.WriteLine("* 3. Play against player    *");
            Console.WriteLine("*****************************");
            Console.WriteLine("\n Please input your choice");
            //Checking if they want to play against a computer or another player or want to see the rules
            bool done = true;
            while (done == true)
            {
                try
                {
                    string choice = Console.ReadLine();
                    if (choice == "1")
                    {
                        //IRules
                        Console.WriteLine("Rules: Each player gets 10 cards. When it's your go you choose two cards. The program adds up your two cards and the other player's two cards and whoever's total is higher wins the hand.");
                    }
                    else if (choice == "2")
                    {
                        string opponent = "P";
                        PvC(opponent);
                    }
                    else if (choice == "3")
                    {
                        string opponent = "C";
                        PvP(opponent);
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
            //Class objects
            Human h = new Human();
            Computer c = new Computer();
            Deck d = new Deck();

            //Shuffling the deck
            d.Shuffle();
            h.hand.Clear();
            h.hand2.Clear();

            //Dealing the cards out
            d.Deal(opponent);

            //Calling the play function for the player and the computer
            (int hCardValue1, int hCardValue2) = h.Play(h.hand);
            int humanTotal = hCardValue1 + hCardValue2;
            Console.WriteLine($"The total of your two cards is {humanTotal}");

            (int cCardValue1, int cCardValue2) = c.Play(c.hand2);
            int computerTotal = cCardValue1 + cCardValue2;
            Console.WriteLine($"The total of the computer's two cards is {computerTotal}");

            //Checking which total is bigger and who won the hand
            if (humanTotal > computerTotal)
            {
                Console.WriteLine("You have the highest total so you win this hand");
                h.Score += 1;
            }
            else
            {
                Console.WriteLine("The computer has the highest total so it wins this hand");
                c.Score2 += 1;
            }
        }

        //For player vs player
        public void PvP(string opponent)
        {
            //Class objects
            Human h = new Human();
            Deck d = new Deck();

            //Shuffling the deck
            d.Shuffle();
            h.hand.Clear();
            h.hand2.Clear();

            //Dealing the cards out
            d.Deal(opponent);

            //Calling the play functions for each player
            Console.WriteLine("Player 1's turn");
            (int h1CardValue1, int h1CardValue2) = h.Play(h.hand);
            int h1Total = h1CardValue1 + h1CardValue2;
            Console.WriteLine($"Player 1: The total of your two cards is {h1Total}");

            Console.WriteLine("Player 2's turn");
            (int h2CardValue1, int h2CardValue2) = h.Play(h.hand);
            int h2Total = h2CardValue1 + h2CardValue2;
            Console.WriteLine($"Player 2:The total of your two cards is {h2Total}");

            //Checking which total is bigger and who won the hand
            if (h1Total > h2Total)
            {
                Console.WriteLine("Player 1: You have the highest total so you win this hand");
                h.Score += 1;
            }
            else
            {
                Console.WriteLine("Player 2:You have the highest total so you win this hand");
                h.Score2 += 1;
            }
        }
    }
}