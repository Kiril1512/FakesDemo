using System;

namespace FakesDemo
{
    public static class SomePublicClass
    {
        public static bool DoSomething(bool flag)
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
    }
}
