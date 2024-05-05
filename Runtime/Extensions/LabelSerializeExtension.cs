// ----------------------------------------------------------------------
// @Namespace : Izayoi.Hts.FullContextLabel.Japanese.Extensions
// @Class     : LabelSerializeExtension
// ----------------------------------------------------------------------
namespace Izayoi.Hts.FullContextLabel.Japanese.Extensions
{
    using System;

    /// <summary>
    /// Label Serialize Extension
    /// </summary>
    public static class LabelSerializeExtension
    {
        public static string ToLabelString(this bool value, bool invert = false)
        {
            if (invert)
            {
                return value ? "0" : "1";
            }

            return value ? "1" : "0";
        }

        public static string ToLabelString(this bool? value, bool invert = false)
        {
            if (value.HasValue)
            {
                return value.Value.ToLabelString();
            }

            return "xx";
        }

        public static string ToLabelString(this byte value)
        {
            return value.ToString();
        }

        public static string ToLabelString(this byte value, string format)
        {
            return value.ToString(format);
        }

        public static string ToLabelString(this byte? value, string format)
        {
            if (value.HasValue)
            {
                return value.Value.ToLabelString(format);
            }

            return "xx";
        }

        public static string ToLabelString(this sbyte value)
        {
            return value.ToString();
        }

        public static string ToLabelString(this sbyte value, string format)
        {
            return value.ToString(format);
        }

        public static string ToLabelString(this sbyte? value, string format)
        {
            if (value.HasValue)
            {
                return value.Value.ToLabelString(format);
            }

            return "xx";
        }

        public static string ToLabelString(this int value, string format)
        {
            return value.ToString(format);
        }

        public static string ToLabelString(this int? value, string format)
        {
            if (value.HasValue)
            {
                return value.Value.ToLabelString(format);
            }

            return "xx";
        }

        public static string ToLabelString(this string? value)
        {
            if (value is null)
            {
                return "xx";
            }

            if (value == string.Empty)
            {
                return "xx";
            }

            return value;
        }
    }
}
