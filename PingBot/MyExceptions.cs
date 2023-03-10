using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PingBot
{
    public class MyExceptions
    {
        public class ErrorArgumentsCount : Exception
        {
            public ErrorArgumentsCount() : base(MyStrings.Errors.ArgumentsCount) { }
        }
        public class CattegoryNotFound : Exception
        {
            public CattegoryNotFound() : base(MyStrings.Errors.CattegoryNotFound) { }
        }
    }
}
