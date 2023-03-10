using System;

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
