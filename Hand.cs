using System;
using System.Collections.Generic;

namespace OOP_assessment_3
{
    class Hand
    {
        private List<Card> _hand;
        public List<Card> hand
        {
            get
            {
                if (_hand == null)
                {
                    _hand = new List<Card>(10);
                }
                return _hand;
            }
            set { _hand = value; }
        }
    }
}
