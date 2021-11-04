using System;
using System.Collections.Generic;
using System.Text;

namespace FakesDemo
{
    internal interface ISomeClasses
    {
        bool DoSomething(bool flag);

        bool InvertFlag(bool flagToInvert);

        int ReturnMeSomeInt();
    }
}
