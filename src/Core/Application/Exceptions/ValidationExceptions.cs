using FluentValidation.Results;
using System;
using System.Collections.Generic;

namespace Application.Exceptions
{
    public class ValidationExceptions : ApplicationException
    {
        public List<string> ValdationErrors { get; set; }

        public ValidationExceptions(ValidationResult validationResult)
        {
            ValdationErrors = new List<string>();

            foreach (var validationError in validationResult.Errors)
            {
                ValdationErrors.Add(validationError.ErrorMessage);
            }
        }
    }
}
