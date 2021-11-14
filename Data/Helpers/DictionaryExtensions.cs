using System.Collections.Generic;

namespace BlazingPostMan.Data.Helpers
{
    public static class DictionaryExtensions
    {
        #nullable enable
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
