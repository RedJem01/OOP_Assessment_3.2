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

        public Card(int rankNum, int suitNum)
        {
            switch (suitNum)
            {
                case 1: suit = "Spades"; break;
                case 2: suit = "Clubs"; break;
                case 3: suit = "Diamonds"; break;
                case 4: suit = "Hearts"; break;
            }

            switch (rankNum)
            {
                case 1: num = "Ace"; break;
                case 2: num = "2"; break;
                case 3: num = "3"; break;
                case 4: num = "4"; break;
                case 5: num = "5"; break;
                case 6: num = "6"; break;
                case 7: num = "7"; break;
                case 8: num = "8"; break;
                case 9: num = "9"; break;
                case 10: num = "10"; break;
                case 11: num = "Jack"; break;
                case 12: num = "Queen"; break;
                case 13: num = "King"; break;
            }
            return;
        }
    }
}