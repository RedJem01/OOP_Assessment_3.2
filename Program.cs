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
            Human h = new Human();
            //Menu
            Console.WriteLine("*****************************");
            Console.WriteLine("* 1. Rules                  *");
            Console.WriteLine("* 2. Play against computer  *");
            Console.WriteLine("* 3. Play against player    *");
            Console.WriteLine("* 4. Exit program           *");
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
                        //Rules
                        Console.WriteLine("Rules: Each player gets 10 cards. When it's your go you choose two cards. The program adds up your two cards and the other player's two cards and whoever's total is higher wins the hand.");
                        Menu();
                    }
                    else if (choice == "2")
                    {
                        string opponent = "P";
                        for (int i = 1; i < 11; i++)
                        {
                            Console.WriteLine($"Round {i}: ");
                            PvP(opponent);
                            if (h.Score > h.Score2)
                            {
                                Console.WriteLine($"Player 1 won with a score of {h.Score}. Player 2's score was {h.Score2}.");
                            }
                            else if (h.Score < h.Score2)
                            {
                                Console.WriteLine($"Player 2 won with a score of {h.Score2}. Player 1's score was {h.Score}.");
                            }
                            else
                            {
                                bool loop = true;
                                while (loop == true)
                                {
                                    (int cardNum, int cardNum2) = Draw(opponent);
                                    if (cardNum > cardNum2)
                                    {
                                        Console.WriteLine($"Player 1 won with a score of {h.Score}. Player 2's score was {h.Score2}.");
                                    }
                                    else if (cardNum < cardNum2)
                                    {
                                        Console.WriteLine($"Player 2 won with a score of {h.Score}. Player 1's score was {h.Score2}.");
                                    }
                                }

                            }
                        }

                    }
                    else if (choice == "3")
                    {
                        string opponent = "C";
                        PvC(opponent);
                        if (h.Score > h.Score2)
                        {
                            Console.WriteLine($"You won with a score of {h.Score}. The computer's score was {h.Score2}");
                        }
                        else if (h.Score < h.Score2)
                        {
                            Console.WriteLine($"The computer won with a score of {h.Score2}. Your score was {h.Score}");
                        }
                        else
                        {
                            bool loop = true;
                            while (loop == true)
                            {
                                (int cardNum, int cardNum2) = Draw(opponent);
                                if (cardNum > cardNum2)
                                {
                                    Console.WriteLine($"Player 1 won with a score of {h.Score}. Player 2's score was {h.Score2}.");
                                }
                                else if (cardNum < cardNum2)
                                {
                                    Console.WriteLine($"Player 2 won with a score of {h.Score}. Player 1's score was {h.Score2}.");
                                }
                            }
                        }
                    }
                    else if (choice == "4")
                    {
                        Environment.Exit(1);
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

            (int cCardValue1, int cCardValue2) = c.Play(h.hand2);
            int computerTotal = cCardValue1 + cCardValue2;
            Console.WriteLine($"The total of the computer's two cards is {computerTotal}");

            //Checking which total is bigger and who won the hand
            if (humanTotal > computerTotal)
            {
                Console.WriteLine("You have the highest total so you win this hand");
                h.Score += 1;
            }
            else if (humanTotal < computerTotal)
            {
                Console.WriteLine("The computer has the highest total so it wins this hand");
                h.Score2 += 1;
            }

            //If there is a draw
            else
            {
                bool loop = true;
                while (loop == true)
                {
                    Console.WriteLine("Both the totals were the same");
                    (int cardNum, int cardNum2) = Draw();
                    if (cardNum > cardNum2)
                    {
                        h.Score += 1;
                        loop = false;
                    }
                    else if (cardNum < cardNum2)
                    {
                        h.Score2 += 1;
                        loop = false;
                    }
                }
            }
        }

        //Draw function for if the players have the same total or same score at the end
        public (int, int) Draw()
        {
            Deck d = new Deck();
            Human h = new Human();
            Computer c = new Computer();

            d.Shuffle();

            Console.WriteLine("Player 1 here is your random card:");
            Console.WriteLine(d.Cards[0]);

            Console.WriteLine("Here is the computer's card:");
            Console.WriteLine(d.Cards[1]);

            int cardNum = h.cardNumCheck(d.Cards[0]);
            int cardNum2 = c.cardNumCheck(d.Cards[1]);

            return (cardNum, cardNum2);
        }
    }
}