using System;
using System.Collections.Generic;
using FluentValidation.Results;

namespace ApplicationC.Exceptions
{
    public class ValidationException : Exception
    {
        public ValidationException() : base("Han ocurrido uno o mása errores de validación.")
        {
            Errors = new List<string>();
        }
        public List<string> Errors { get; }
        public ValidationException(IEnumerable<ValidationFailure> failures)
            : this()
        {
            foreach (var failure in failures)
            {
                Errors.Add(failure.ErrorMessage);
            }
        }

        public ValidationException(List<string> errors): base("Han ocurrido uno o más errores de validación")
        {
            Errors = errors;
        }
        
    }
}
