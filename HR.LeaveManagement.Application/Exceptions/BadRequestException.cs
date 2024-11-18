using System.ComponentModel.DataAnnotations;

namespace HR.LeaveManagement.Application.Exceptions
{
    public class BadRequestException : Exception
    {
        public BadRequestException(string message) : base(message) { }

        //public BadRequestException(string message, ValidationResult validationResult) : base(message)
        //{
        //    ValidationErrors = new();
        //    foreach(var error in validationResult.Errors)
        //    {
        //        ValidationErrors.Add(error.ErrorMessage);
        //    }
        //}
        public BadRequestException(string message, ValidationResult validationResult) : base(message)
        {
            ValidationErrors = new();

            // Loop through each validation error and add its message to the list
            foreach (var error in validationResult.ErrorMessage)
            {
                ValidationErrors.Add(error.ToString());
            }
        }

        public List<string> ValidationErrors { get; set; }

    }
}
