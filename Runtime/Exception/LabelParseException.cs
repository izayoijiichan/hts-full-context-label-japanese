// ----------------------------------------------------------------------
// @Namespace : Izayoi.Hts.FullContextLabel.Japanese
// @Class     : LabelParseException
// ----------------------------------------------------------------------
namespace Izayoi.Hts.FullContextLabel.Japanese
{
    using System;

    /// <summary>
    /// Label Parse Exception
    /// </summary>
    public class LabelParseException : Exception
    {
        #region Fields

        /// <summary></summary>
        private readonly LabelParseErrorType parseErrorType;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the LabelParseException class with a specified error message.
        /// </summary>
        /// <param name="message"></param>
        public LabelParseException(string message) : base(message)
        {
            parseErrorType = LabelParseErrorType.SymbolNotFound;
        }

        /// <summary>
        /// Initializes a new instance of the LabelParseException class with a specified error message
        /// and a reference to the inner exception that is the cause of this exception.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        /// <param name="innerException">
        /// The exception that is the cause of the current exception, or a null reference
        /// (Nothing in Visual Basic) if no inner exception is specified.
        /// </param>
        public LabelParseException(string message, Exception innerException) : base(message, innerException)
        {
            parseErrorType = LabelParseErrorType.None;
        }

        /// <summary>
        /// Initializes a new instance of the LabelParseException class with a specified error type.
        /// </summary>
        /// <param name="errorType"></param>
        public LabelParseException(LabelParseErrorType errorType) : base("")
        {
            parseErrorType = errorType;
        }

        /// <summary>
        /// Initializes a new instance of the LabelParseException class with a specified error type
        /// and a reference to the inner exception that is the cause of this exception.
        /// </summary>
        /// <param name="errorType"></param>
        /// <param name="innerException"></param>
        public LabelParseException(LabelParseErrorType errorType, Exception innerException) : base("", innerException)
        {
            parseErrorType = errorType;
        }

        /// <summary>
        /// Initializes a new instance of the LabelParseException class with a specified error type
        /// and a specified error message.
        /// </summary>
        /// <param name="errorType"></param>
        /// <param name="message"></param>
        public LabelParseException(LabelParseErrorType errorType, string message) : base(message)
        {
            parseErrorType = errorType;
        }

        /// <summary>
        /// Initializes a new instance of the LabelParseException class with a specified error type, a specified error message
        /// and a reference to the inner exception that is the cause of this exception.
        /// </summary>
        /// <param name="errorType"></param>
        /// <param name="message"></param>
        /// <param name="innerException"></param>
        public LabelParseException(LabelParseErrorType errorType, string message, Exception innerException) : base(message, innerException)
        {
            parseErrorType = errorType;
        }

        #endregion

        #region Properties

        /// <summary></summary>
        public LabelParseErrorType ParseErrorType => parseErrorType;

        /// <summary>
        /// Gets a message that describes the current exception.
        /// </summary>
        public new string Message => $"{nameof(ParseErrorType)}: {parseErrorType} {base.Message}";

        #endregion
    }
}
