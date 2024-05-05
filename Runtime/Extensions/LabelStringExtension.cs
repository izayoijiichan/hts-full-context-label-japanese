// ----------------------------------------------------------------------
// @Namespace : Izayoi.Hts.FullContextLabel.Japanese.Extensions
// @Class     : LabelStringExtension
// ----------------------------------------------------------------------
namespace Izayoi.Hts.FullContextLabel.Japanese.Extensions
{
    /// <summary>
    /// Label String Extension
    /// </summary>
    public static class LabelStringExtension
    {
        public static string? StringOrDefault(this string value)
        {
            return value == "xx" ? default : value;
        }

        /// <summary>
        /// 指定した文字列を byte 型に変換します。
        /// </summary>
        /// <param name="value"></param>
        /// <returns>指定した文字列を byte 型に変換した値を返します。</returns>
        /// <exception cref="LabelParseException">value が数値 (byte) でなかった場合に発生します。</exception>

        public static byte ParseByte(this string value)
        {
            if (byte.TryParse(value, out var result))
            {
                return result;
            }

            throw new LabelParseException(LabelParseErrorType.ParseIntError, $"Error parsing '{value}' to byte.");
        }

        /// <summary>
        /// 指定した文字列を sbyte 型に変換します。
        /// </summary>
        /// <param name="value"></param>
        /// <returns>指定した文字列を sbyte 型に変換した値を返します。</returns>
        /// <exception cref="LabelParseException">value が数値 (sbyte) でなかった場合に発生します。</exception>
        public static sbyte ParseSbyte(this string value)
        {
            if (sbyte.TryParse(value, out var result))
            {
                return result;
            }

            throw new LabelParseException(LabelParseErrorType.ParseIntError, $"Error parsing '{value}' to sbyte.");
        }

        /// <summary>
        /// 指定した文字列を byte 型に変換します。
        /// </summary>
        /// <param name="value"></param>
        /// <returns>
        /// 指定した文字列を byte 型に変換した値を返します。
        /// 指定した文字列が "xx" だった場合には null を返します。
        /// </returns>
        /// <exception cref="LabelParseException">value が数値 (byte) または "xx" でなかった場合に発生します。</exception>
        public static byte ParseByteOrDefault(this string value)
        {
            if (value == "xx")
            {
                return default;
            }

            return value.ParseByte();
        }

        /// <summary>
        /// 指定した文字列を sbyte 型に変換します。
        /// </summary>
        /// <param name="value"></param>
        /// <returns>
        /// 指定した文字列を sbyte 型に変換した値を返します。
        /// 指定した文字列が "xx" だった場合には null を返します。
        /// </returns>
        /// <exception cref="LabelParseException">value が数値 (sbyte) または "xx" でなかった場合に発生します。</exception>
        public static sbyte ParseSbyteOrDefault(this string value)
        {
            if (value == "xx")
            {
                return default;
            }

            return value.ParseSbyte();
        }

        /// <summary>
        /// 指定した文字列をbool型に変換します。
        /// </summary>
        /// <param name="value"></param>
        /// <param name="inverted"></param>
        /// <returns></returns>
        /// <exception cref="LabelParseException">value が "0", "1", "xx" 以外だった場合に発生します。</exception>
        public static bool? ParseBoolOrDefault(this string value, bool inverted = false)
        {
            switch (value)
            {
                case "0":
                    return inverted ? true : false;
                case "1":
                    return inverted ? false : true;
                case "xx":
                    return default;
                default:
                    throw new LabelParseException(LabelParseErrorType.ParseBoolError, $"Error parsing '{value}' to bool.");
            }
        }

        /// <summary>
        /// 指定した文字列が "xx" であることを主張します。
        /// </summary>
        /// <param name="value"></param>
        /// <exception cref="LabelParseException">value が "xx" 以外だった場合に発生します。</exception>
        public static void AssertXX(this string value)
        {
            if (value == "xx")
            {
                return;
            }

            throw new LabelParseException(LabelParseErrorType.NotUndefined, $"Value must be 'xx'. '{value}'");
        }
    }
}
