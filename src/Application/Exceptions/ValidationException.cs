using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Exceptions
{
    public class ValidationException : Exception
    {
        public IEnumerable<ValidationFailure> Errors { get; }

        public ValidationException(IEnumerable<ValidationFailure> errors)
            : base("One or more validation failures have occurred.")
        {
            Errors = errors;
        }
    }
}
