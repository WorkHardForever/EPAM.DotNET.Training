using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DefiningAGenericTypeDemo
{
    interface IPrintable
    {
        string Title { get; }
        string Print();
    }
}
