using System;
using System.Collections.Generic;
using System.Text;

namespace Millionaires
{
    class Score
    {
        public int Number { get; private set; }

        public Score(int number)
        {
            Number = number;
        }

        public void Multiply()
        {
            if (Number == 0) Number = 100;
            else Number *= 2;
        }
    }
}
