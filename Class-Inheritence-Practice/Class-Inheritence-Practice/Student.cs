using System;
using System.Collections.Generic;
using System.Text;

namespace Class_Inheritence_Practice
{
    internal class Student : Human
    {
        public string UserName;
        public string Password;
        public int Grade;
        private int _age;

        public int Age
        {
            get { return _age; }
            set
            {
                if(value>14)
                    _age = value;
            }
        }
    }
}
