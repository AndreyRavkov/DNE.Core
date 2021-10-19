using System;
using System.Collections.Generic;
using System.Linq;
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
        /// <param name="value"></param>
        /// <returns>string</returns>
        public static string TrimExt(this string value)
        {
            return string.IsNullOrEmpty(value) ? value : value.Trim();
        }

        /// <summary>
        /// Replace keys to value in the current string
        /// </summary>
        /// <param name="value">original string with keys</param>
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
        /// <param name="text">string value</param>
        /// <param name="encoding">encoding type, if leave this param as null, the method will use System.Text.Encoding.UTF8</param>
        /// <returns>string</returns>
        public static string ToBase64(this string text, Encoding encoding = null)
        {
            if (string.IsNullOrEmpty(text))
            {
                return text;
            }
            encoding ??= Encoding.UTF8;

            byte[] textAsBytes = encoding.GetBytes(text);
            return Convert.ToBase64String(textAsBytes);
        }

        /// <summary>
        /// Convert base64 string
        /// </summary>
        /// <param name="text">string value</param>
        /// <param name="encoding">encoding type, if leave this param as null, the method will use System.Text.Encoding.UTF8</param>
        /// <returns></returns>
        public static string FromBase64(this string text, Encoding encoding = null)
        {
            if (string.IsNullOrEmpty(text))
            {
                return text;
            }
            encoding ??= Encoding.UTF8;
            byte[] textAsBytes = Convert.FromBase64String(text);
            return encoding.GetString(textAsBytes);
        }
        
        
        
    }
}