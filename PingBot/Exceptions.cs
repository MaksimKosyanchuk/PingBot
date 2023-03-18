using System;

namespace PingBot
{
    public class Exceptions
    {
        public class ErrorArgumentsCount : Exception
        {
            public ErrorArgumentsCount(long ChatId) : base(Strings.Errors.ArgumentsCount) => Logger.Logger.Log(Strings.Errors.ArgumentsCount, ChatId);
        }
        public class CategoryNotFound : Exception
        {
            public CategoryNotFound(long ChatId) : base(Strings.Errors.CategoryNotFound) => Logger.Logger.Log(Strings.Errors.CategoryNotFound, ChatId);
        }

        public class CategoryAlreadyExists : Exception
        {
            public CategoryAlreadyExists(long ChatId) : base(Strings.Errors.CategoyAlreadyExists) => Logger.Logger.Log(Strings.Errors.CategoyAlreadyExists, ChatId);
        }
    }
}
