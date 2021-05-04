using System;
using System.Collections.Generic;

namespace OOP_assessment_3
{
    class Hand
    {
        private List<Card> _hand;
        public List<Card> hand
        {
            get { return _hand; }
            set { _hand = value; }
        }

        public Hand()
        {
            hand = new List<Card>(10);
        }
    }
}
