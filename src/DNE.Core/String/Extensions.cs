using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace DNE.Core.String
{
    public static class Extensions
    {
        /// <summary>
        /// The method removes from the current string all leading and trailing white-space characters.
        /// Each leading and trailing trim operation stops when a non-white-space character is encountered.
        /// If value equals to String.Empty or null then method returns value as it without exception
        /// </summary>
        /// <param name="value">source string</param>
        /// <returns>string</returns>
        public static string TrimExt(this string value)
        {
            return string.IsNullOrEmpty(value) ? value : value.Trim();
        }

        /// <summary>
        /// Trim source string and replace custom symbols to custom replace symbol
        /// </summary>
        /// <param name="value">source string</param>
        /// <param name="customReplaceSymbol">custom replace string</param>
        /// <param name="customSymbols">custom symbols which be replaced</param>
        /// <returns>string</returns>
        public static string TrimAndRemove(this string value, string customReplaceSymbol, IReadOnlyList<string> customSymbols)
        {
            if (string.IsNullOrEmpty(value.TrimExt()))
            {
                return value.TrimExt();
            }

            if (customSymbols == null || !customSymbols.Any())
            {
                return value;
            }
            foreach (var item in customSymbols)
            {
                value = value.Replace(item, customReplaceSymbol);
            }

            return value;
        }
        
        /// <summary>
        /// Replace keys to value in the current string
        /// </summary>
        /// <param name="value">source string with keys</param>
        /// <param name="replaceDictionary">dictionary with key-value</param>
        /// <returns>string</returns>
        public static string Replace(this string value, Dictionary<string, string> replaceDictionary)
        {
            if (!replaceDictionary.Any())
            {
                return value;
            }
            foreach (var item in replaceDictionary)
            {
                value = value.Replace(item.Key, item.Value);
            }

            return value;
        }
        
        /// <summary>
        /// Convert string to Base64 string
        /// </summary>
        /// <param name="text">source string value</param>
        /// <param name="encoding">encoding type, if leave this param as null, the method will use System.Text.Encoding.UTF8</param>
        /// <returns>string</returns>
        public static string ToBase64(this string text, Encoding encoding = null)
        {
            if (string.IsNullOrEmpty(text))
            {
                return text;
            }
            if (encoding == null)
            {
                encoding = Encoding.UTF8;
            }

            byte[] textAsBytes = encoding.GetBytes(text);
            return Convert.ToBase64String(textAsBytes);
        }

        /// <summary>
        /// Convert base64 string to string
        /// </summary>
        /// <param name="text">source string value</param>
        /// <param name="encoding">encoding type, if leave this param as null, the method will use System.Text.Encoding.UTF8</param>
        /// <returns></returns>
        public static string FromBase64(this string text, Encoding encoding = null)
        {
            if (string.IsNullOrEmpty(text))
            {
                return text;
            }
            if (encoding == null)
            {
                encoding = Encoding.UTF8;
            }
            
            byte[] textAsBytes = Convert.FromBase64String(text);
            return encoding.GetString(textAsBytes);
        }
        
        /// <summary>
        /// Join collection of strings to one string with NewLine separator
        /// </summary>
        /// <param name="value">source collection</param>
        /// <returns>string</returns>
        public static string JoinWithNewLine(this IEnumerable<string> value)
        {
            return string.Join(Environment.NewLine, value);
        }

        /// <summary>
        /// Get only digits from string
        /// </summary>
        /// <param name="value">source string value</param>
        /// <returns>int?</returns>
        public static int? GetOnlyDigits(this string value)
        {
            if (string.IsNullOrEmpty(value.TrimExt()))
            {
                return null;
            }

            return int.Parse(new string(value.Where(Char.IsDigit).ToArray()));
        }

        /// <summary>
        /// Encode source string
        /// </summary>
        /// <param name="value">source string</param>
        /// <returns></returns>
        public static string UrlEncode(this string value)
        {
            return WebUtility.UrlEncode(value);
        }

        /// <summary>
        /// Decode source string
        /// </summary>
        /// <param name="value">source string</param>
        /// <returns></returns>
        public static string UrlDecode(this string value)
        {
            return WebUtility.UrlDecode(value);
        }
        
        /// <summary>
        /// Try to convert string to nullable int32 value
        /// </summary>
        /// <param name="value">source string</param>
        /// <returns>int?</returns>
        public static int? ToNullableInt32(this string value)
        {
            if (int.TryParse(value, out var result)) return result;
            return null;
        }
        
        /// <summary>
        /// Try to convert string to nullable int64 value
        /// </summary>
        /// <param name="value">source string</param>
        /// <returns>long?</returns>
        public static long? ToNullableInt64(this string value)
        {
            if (long.TryParse(value, out var result)) return result;
            return null;
        }
        
        /// <summary>
        /// Replace chars in source string
        /// </summary>
        /// <param name="value">source string</param>
        /// <param name="chars">chars to replace</param>
        /// <param name="replaceSymbol">replace to symbol</param>
        /// <returns>string</returns>
        public static string ReplaceChars(this string value, Char[] chars, string replaceSymbol = "")
        {
            value = value.TrimExt();
            if (string.IsNullOrEmpty(value))
            {
                return value;
            }

            //var invalidSymbols = Constants.SearchInvalidChars.ToCharArray();
            if (chars.Any(value.Contains))
            {
                foreach (var invalidSymbol in chars)
                {
                    value = value.Replace(invalidSymbol.ToString(), replaceSymbol);
                }
            }

            return value;
        }

        /// <summary>
        /// Replace chars in source string
        /// </summary>
        /// <param name="value">source string</param>
        /// <param name="chars">string of chars to replace</param>
        /// <param name="replaceSymbol">replace to symbol</param>
        /// <returns>string</returns>
        public static string ReplaceChars(this string value, string chars, string replaceSymbol = "")
        {
            return ReplaceChars(value, chars.ToCharArray(), replaceSymbol);
        }
    }
}