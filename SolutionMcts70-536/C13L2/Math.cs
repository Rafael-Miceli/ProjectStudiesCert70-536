using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace MathLibrary
{
    public class Math
    {
        [ComVisible(false)]
        public int _value = 0;

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
