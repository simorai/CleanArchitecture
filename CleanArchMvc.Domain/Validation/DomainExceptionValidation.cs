namespace CleanArchMvc.Domain.Validation
{
    /// <summary>
    /// Represents domain-specific validation exceptions.
    /// </summary>
    public class DomainExceptionValidation : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DomainExceptionValidation"/> class with a specified error message.
        /// </summary>
        /// <param name="error">The error message that explains the reason for the exception.</param>
        public DomainExceptionValidation(string error) : base(error)
        {
        }

        /// <summary>
        /// Throws a <see cref="DomainExceptionValidation"/> if the specified condition is true.
        /// </summary>
        /// <param name="hasError">A boolean value indicating whether the error condition is met.</param>
        /// <param name="error">The error message to include in the exception.</param>
        public static void When(bool hasError, string error)
        {
            if (hasError)
            {
                throw new DomainExceptionValidation(error);
            }
        }
    }
}
