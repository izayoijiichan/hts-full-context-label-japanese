// ----------------------------------------------------------------------
// @Namespace : Izayoi.Hts.FullContextLabel.Japanese
// @Enum      : LabelParseErrorType
// ----------------------------------------------------------------------
namespace Izayoi.Hts.FullContextLabel.Japanese
{
    /// <summary>
    /// Label parse Error Type
    /// </summary>
    public enum LabelParseErrorType
    {
        /// <summary></summary>
        None,
        /// <summary>The required symbol was not found.</summary>
        SymbolNotFound,
        /// <summary>The position was supposed to be integer, but failed to parse it as integer.</summary>
        ParseIntError,
        /// <summary>The position was supposed to be boolean (0 or 1), but failed to parse it as boolean.</summary>
        ParseBoolError,
        /// <summary>The position must always be undefined.</summary>
        NotUndefined,
    }
}
