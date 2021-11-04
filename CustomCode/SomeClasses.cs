using System;

namespace FakesDemo
{
    internal class SomeClasses : ISomeClasses
    {
        public bool DoSomething(bool flag)
        {
            if (flag)
            {
                Console.WriteLine("true");
            }
            else
            {
                Console.WriteLine("false");
            }

            return flag;
        }

        public bool InvertFlag(bool flagToInvert)
        {
            if (flagToInvert)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public int ReturnMeSomeInt()
        {
            return 5;
        }
    }
}
