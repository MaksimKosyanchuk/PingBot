using System;

namespace PingBot
{
    public class Exceptions
    {
        public class ErrorArgumentsCount : Exception
        {
            public ErrorArgumentsCount() : base(Strings.Errors.ArgumentsCount) { }
        }
        public class CategoryNotFound : Exception
        {
            public CategoryNotFound() : base(Strings.Errors.CategoryNotFound) { }
        }

        public class CategoryAlreadyExists : Exception
        {
            public CategoryAlreadyExists() : base(Strings.Errors.CategoyAlreadyExists) { }
        }
    }
}
