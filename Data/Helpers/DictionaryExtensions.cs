using System.Collections.Generic;

namespace BlazingPostMan.Data.Helpers
{
    public static class DictionaryExtensions
    {
        public static bool TryRemove(this Dictionary<string, string> keyValuePairs, string value)
        {
            if (!string.IsNullOrEmpty(value))
            {
                return keyValuePairs.Remove(value);
            }

            return false;
        }
    }
}
