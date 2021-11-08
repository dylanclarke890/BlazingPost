using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlazingPostMan.Data.Helpers
{
    public static class UrlHelper
    {
        public static string GetUrl(string initialUrl, Dictionary<string, string> urlParams)
        {
            StringBuilder urlBuilder = new(initialUrl);
            urlParams ??= new();

            if (urlParams.Any())
            {
                urlBuilder.Append('?');
                foreach (var keyValue in urlParams)
                {
                    urlBuilder.Append($"{keyValue.Key}={keyValue.Value}&");
                }

                // Remove trailing &
                urlBuilder.Remove(urlBuilder.Length - 1, 1);
            }

            return urlBuilder.ToString();
        }
    }
}
