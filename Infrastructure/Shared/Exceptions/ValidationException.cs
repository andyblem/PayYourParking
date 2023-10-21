using Shared.Wrappers;
using FluentValidation.Results;

namespace Shared.Exceptions
{
    public class ValidationException : Exception
    {
        public List<Error> Errors { get; }


        public ValidationException()
            : base("One or more validation failures have occurred.")
        {
            Errors = new List<Error>();
        }


        public ValidationException(IEnumerable<ValidationFailure> failures)
            : this()
        {
            // group errors by property name
            var groupedErrors = failures
                .GroupBy(f => f.PropertyName)
                .Select(gr => new Error
                {
                    PropertyName = gr.Key,
                    ErrorMessages = gr.Select(gr => gr.ErrorMessage)
                        .ToList()
                })
                .ToList();

            // set errors
            Errors = groupedErrors;
        }

    }
}
