using FluentValidation.Results;
using Microsoft.Office.Interop.Excel;

namespace Todo.Application.Common.Exceptions
{
    public class ValidationException : Exception
    {
        public ValidationException()
            :base("One or more validation failure have occured")
        { }

        public ValidationException(IEnumerable<ValidationFailure> failures)
            : this()
        {
            Errors = failures
                .GroupBy(e => e.PropertyName, e => e.ErrorMessage)
                .ToDictionary(failureGroup => failureGroup.Key, failureGroup => failureGroup.ToArray());
        }

        public ValidationException(string message) : base(message) { }

        public ValidationException(string message, Exception innerException) : base(message, innerException) { }
        
        public IDictionary<string, string[]> Errors { get; set; }
    }
}
