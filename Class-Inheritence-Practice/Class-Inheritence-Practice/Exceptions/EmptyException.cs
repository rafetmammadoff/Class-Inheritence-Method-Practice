using System;
using System.Collections.Generic;
using System.Text;

namespace Class_Inheritence_Practice.Exceptions
{
    internal class EmptyException : Exception
    {
        public EmptyException(string msg) : base(msg)
        {

        }
    }
}
