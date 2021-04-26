using System;
using System.Collections.Generic;

namespace OOP_assessment_3
{
    //Card class
    class Card
    {
        //Card class attributes
        private string _num;
        public string num
        {
            get { return _num; }
            set { _num = value; }
        }
        private string _suit;
        public string suit
        {
            get { return _suit; }
            set { _suit = value; }
        }

        public Cards(string num, string suit)
        {
            switch (suit)
            {
                case 1: c.suit = "Spades"; break;
                case 2: c.suit = "Clubs"; break;
                case 3: c.suit = "Diamonds"; break;
                case 4: c.suit = "Hearts"; break;
            }

            switch (num)
            {
                case 1: c.num = "Ace"; break;
                case 2: c.num = "2"; break;
                case 3: c.num = "3"; break;
                case 4: c.num = "4"; break;
                case 5: c.num = "5"; break;
                case 6: c.num = "6"; break;
                case 7: c.num = "7"; break;
                case 8: c.num = "8"; break;
                case 9: c.num = "9"; break;
                case 10: c.num = "10"; break;
                case 11: c.num = "Jack"; break;
                case 12: c.num = "Queen"; break;
                case 13: c.num = "King"; break;
            }
        return;
        }
    }
}