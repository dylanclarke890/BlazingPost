using System.Collections.Generic;

namespace BlazingPostMan.Data.Helpers
{
    public static class DictionaryExtensions
    {
        #nullable enable
        /// <returns><c>False</c> if the key is null or adding failed, otherwise <c>True</c>.</returns>
        public static bool TryRemove(this Dictionary<string, string> keyValuePairs, string? key)
        {
            if (!string.IsNullOrEmpty(key))
            {
                return keyValuePairs.Remove(key);
            }

            return false;
        }
    }
}
