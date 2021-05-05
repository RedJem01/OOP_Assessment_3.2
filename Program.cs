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
            Computer c = new Computer();

            //Menu
            Console.WriteLine("*****************************");
            Console.WriteLine("* 1. Rules                  *");
            Console.WriteLine("* 2. Play against computer  *");
            Console.WriteLine("* 3. Exit program           *");
            Console.WriteLine("*****************************");
            Console.WriteLine("\n Please input your choice");

            //Checking if they want to play against a computer or another player or want to see the rules
            bool done = true;
            while (done == true)
            {
                try
                {
                    string choice = Console.ReadLine();

                    //Rules
                    if (choice == "1")
                    {
                        
                        Console.WriteLine("Rules: Each player gets 10 cards. When it's your go you choose two cards. The program adds up your two cards and the other player's two cards and whoever's total is higher wins the hand.");
                        Menu();
                    }
                   
                    //Playing against computer
                    else if (choice == "2")
                    {
                        //Calling the function to start playing
                        PvC();

                        //Checking who won overall
                        if (h.Score > c.Score)
                        {
                            Console.WriteLine($"You won with a score of {h.Score}. The computer's score was {c.Score}");
                        }
                        else if (h.Score < c.Score)
                        {
                            Console.WriteLine($"The computer won with a score of {c.Score}. Your score was {h.Score}");
                        }

                        //In case of draw
                        else
                        {
                            //Loop in case of another draw
                            bool loop = true;
                            while (loop == true)
                            {
                                (int cardNum, int cardNum2) = Draw();
                                if (cardNum > cardNum2)
                                {
                                    Console.WriteLine($"Player 1 won with a score of {h.Score}. Player 2's score was {c.Score}.");
                                    loop = false;
                                    Menu();
                                }
                                else if (cardNum < cardNum2)
                                {
                                    Console.WriteLine($"Player 2 won with a score of {h.Score}. Player 1's score was {c.Score}.");
                                    loop = false;
                                    Menu();
                                }
                            }
                        }
                    }

                    //To exit the program
                    else if (choice == "3")
                    {
                        Environment.Exit(1);
                    }

                    //If 1,2 or 3 were not entered
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
        public void PvC()
        {
            //Class objects
            Human h = new Human();
            Computer c = new Computer();
            Deck d = new Deck();

            //Shuffling the deck
            d.Shuffle();
            h.handList.hand.Clear();
            c.handList.hand.Clear();

            //Dealing the cards out
            d.Deal();

            bool bloop = true;
            while (bloop == true)
            {
                //Calling the play function for the player and the computer
                int hTotal = h.Play(h.handList.hand);
                Console.WriteLine($"The total of your two cards is {hTotal}");

                int cTotal = c.Play(c.handList.hand);
                Console.WriteLine($"The total of the computer's two cards is {cTotal}");

                //Checking which total is bigger and who won the hand
                if (hTotal > cTotal)
                {
                    Console.WriteLine("You have the highest total so you win this hand");
                    h.Score += 1;
                }
                else if (hTotal < cTotal)
                {
                    Console.WriteLine("The computer has the highest total so it wins this hand");
                    c.Score += 1;
                }

                //If there is a draw
                else
                {
                    //Loop is used in case of another draw
                    bool loop = true;
                    while (loop == true)
                    {
                        Console.WriteLine("Both the totals were the same. Whoever wins the nest round gets 2 hands");

                        //They replay and whoever wins gets 2 added to their score instead of 1
                        int hdTotal = h.Play(h.handList.hand);
                        Console.WriteLine($"The total of your two cards is {hdTotal}");

                        int cdTotal = c.Play(c.handList.hand);
                        Console.WriteLine($"The total of the computer's two cards is {cdTotal}");

                        //Checking who won
                        if (hdTotal > cdTotal)
                        {
                            Console.WriteLine("You have the highest total so you win this hand and the last");
                            h.Score += 2;
                            loop = false;
                        }
                        else if (hdTotal < cdTotal)
                        {
                            Console.WriteLine("The computer has the highest total so it wins this hand and the last");
                            c.Score += 2;
                            loop = false;
                        }
                    }
                }

                //If there are no cards left in the hand
                if ((c.handList.hand.Count == 0) && (h.handList.hand.Count == 0))
                {
                    d.isEmpty();
                    bloop = false;
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

            Console.WriteLine("Here is your random card:");
            Console.WriteLine(d.Cards[0]);

            Console.WriteLine("Here is the computer's card:");
            Console.WriteLine(d.Cards[1]);

            int cardNum = h.cardNumCheck(d.Cards[0]);
            int cardNum2 = c.cardNumCheck(d.Cards[1]);

            return (cardNum, cardNum2);
        }
    }
}