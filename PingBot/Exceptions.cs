using System;

namespace PingBot
{
    public class MyExceptions
    {
        public class ErrorArgumentsCount : Exception
        {
            public ErrorArgumentsCount() : base(Strings.Errors.ArgumentsCount) { }
        }
        public class CategoryNotFound : Exception
        {
            public CategoryNotFound() : base(Strings.Errors.CategoryNotFound) { }
        }
    }
}
