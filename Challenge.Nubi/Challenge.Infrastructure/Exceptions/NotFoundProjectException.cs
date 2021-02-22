using Challenge.Infrastructure.Extensions;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;

namespace Challenge.Infrastructure.Exceptions
{
    public class NotFoundProjectException : ProjectException
    {
        public NotFoundProjectException()
        {
        }

        public NotFoundProjectException(string message)
            : base(message)
        {
        }

        public NotFoundProjectException(ModelStateDictionary modelState)
            => ValidationError = modelState.AllErrors();

        public NotFoundProjectException(string message, ModelStateDictionary modelState)
            : base(message) => ValidationError = modelState.AllErrors();

        public NotFoundProjectException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
