using System;

namespace PingBot
{
    public class MyExceptions
    {
        public class ErrorArgumentsCount : Exception
        {
            public ErrorArgumentsCount() : base(MyStrings.Errors.ArgumentsCount) { }
        }
        public class CategoryNotFound : Exception
        {
            public CategoryNotFound() : base(MyStrings.Errors.CategoryNotFound) { }
        }
    }
}
