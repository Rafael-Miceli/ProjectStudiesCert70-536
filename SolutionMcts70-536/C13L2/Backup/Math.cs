using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MathLibrary
{
    public class Math
    {
        private int _value = 0;

        public int Value
        {
            get
            {
                return _value;
            }
            set
            {
                _value = value;
            }
        }

        public void Add(int n)
        {
            _value += n;
        }

        public void Subtract(int n)
        {
            _value -= n;
        }
    }
}
