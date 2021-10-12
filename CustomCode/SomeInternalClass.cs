using System;

namespace FakesDemo
{
    internal static class SomeInternalClass
    {
        internal static void DoSomething(bool flag)
        {
            if (flag)
            {
                Console.WriteLine("true");
            }
            else
            {
                Console.WriteLine("false");
            }
        }
    }
}
