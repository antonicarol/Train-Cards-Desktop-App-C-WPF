using System;
using System.Collections.Generic;
using System.Text;

namespace TrainCards
{
    class Card
    {
        int value;

        // (♦), spades (♠), hearts (♥) and clubs (♣) 
        string type;

        // 1 is for red color
        // 2 is for black color
        bool color;

        public Card(int v, string t, bool c)
        {
            value = v;
            type = t;
            color = c;
        }

        public Card()
        {

        }

        public int GetValue()
        {
            return value;
        }
        public string GetType()
        {
            return type;
        }
        public bool GetColor()
        {
            return color;
        }

        public string ToString()
        {
            
            return "_"+value + "_of_"+ type;
        }
    }
}
