using System;
using System.Collections.Generic;
using System.Text;

namespace Class_Inheritence_Practice.Exceptions
{
    public class MistakeEnteredValueException : Exception
    {
        public MistakeEnteredValueException(string msg) : base(msg)
        {

        }
    }
}
