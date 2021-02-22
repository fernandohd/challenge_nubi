using Challenge.Infrastructure.Extensions;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;

namespace Challenge.Infrastructure.Exceptions
{
    public class ForbiddenProjectException : ProjectException
    {
        public ForbiddenProjectException()
        {
        }

        public ForbiddenProjectException(string message)
            : base(message)
        {
        }

        public ForbiddenProjectException(ModelStateDictionary modelState)
            => ValidationError = modelState.AllErrors();

        public ForbiddenProjectException(string message, ModelStateDictionary modelState)
            : base(message) => ValidationError = modelState.AllErrors();

        public ForbiddenProjectException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
