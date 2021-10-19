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
        
        
    }
}