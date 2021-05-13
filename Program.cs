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
            Console.WriteLine("\nPlease input your choice\n");

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
                        
                        Console.WriteLine("Rules: Each player gets 10 cards. When it's your go you choose two cards. The program adds up your two cards and the other player's two cards and whoever's total is higher wins the hand. Ace is 14, King is 13, Queen is 12, Jack is 11, all the other cards are thier own numbers. You play until your hand is empty.");
                        Menu();
                    }
                   
                    //Playing against computer
                    else if (choice == "2")
                    {
                        //Calling the function to start playing
                        (h.Score, c.Score) = PvC();

                        //Checking who won overall
                        if (h.Score > c.Score)
                        {
                            Console.WriteLine($"You won with a score of {h.Score}. The computer's score was {c.Score}");
                            Menu();
                        }
                        else if (h.Score < c.Score)
                        {
                            Console.WriteLine($"The computer won with a score of {c.Score}. Your score was {h.Score}");
                            Menu();
                        }

                        //In case of draw
                        else
                        {
                            //Loop in case of another draw
                            bool loop = true;
                            while (loop == true)
                            {
                                //Calling the draw function
                                (int cardNum, int cardNum2) = Draw();
                                //Checking who had the highest total
                                if (cardNum > cardNum2)
                                {
                                    Console.WriteLine($"You won with a score of {h.Score}. The computer's score was {c.Score}.");
                                    loop = false;
                                    Menu();
                                }
                                else if (cardNum < cardNum2)
                                {
                                    Console.WriteLine($"The computer won with a score of {h.Score}. Your score was {c.Score}.");
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
                        throw new WrongInputException("That is the wrong input. Please input 1, 2 or 3.");

                    }
                }
                //If input is not 1, 2 or 3 then call an error and the user is asked to input again
                catch (WrongInputException e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }

        //For player vs computer 
        public (int, int) PvC()
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
            (h.handList.hand, c.handList.hand) = d.Deal(h.handList.hand, c.handList.hand);

            bool bloop = true;
            while (bloop == true)
            {
                //Calling the play function for the player and the computer
                int hTotal = h.Play(h.handList.hand);
                Console.WriteLine($"The total of your two cards is {hTotal}");

                int cTotal = c.Play(c.handList.hand);
                Console.WriteLine($"\nThe total of the computer's two cards is {cTotal}");

                //Checking which total is bigger and who won the hand
                if (hTotal > cTotal)
                {
                    Console.WriteLine("\nYou have the highest total so you win this hand\n");
                    h.Score += 1;
                }
                else if (hTotal < cTotal)
                {
                    Console.WriteLine("\nThe computer has the highest total so it wins this hand\n");
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
            return (h.Score, c.Score);
        }

        //Draw function for if the players have the same score at the end
        public (int, int) Draw()
        {
            //Class objects
            Human h = new Human();
            Computer c = new Computer();
            Deck d = new Deck();

            //To shuffle the deck
            d.Shuffle();

            //Random card for the player
            Console.WriteLine("Here is your random card:");
            Console.WriteLine(d.Cards[0]);

            //Random card for the computer
            Console.WriteLine("Here is the computer's card:");
            Console.WriteLine(d.Cards[1]);

            int cardNum = h.cardNumCheck(d.Cards[0]);
            int cardNum2 = c.cardNumCheck(d.Cards[1]);

            return (cardNum, cardNum2);
        }
    }
}