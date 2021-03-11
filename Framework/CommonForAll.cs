using System;
using System.Collections.Generic;
using System.Text;

namespace Framework
{
    public class CommonForAll
    {
        [ThreadStatic]
        public static Wait Wait;

        public static void Init()
        {
            Wait = new Wait();
        }
    }
}
