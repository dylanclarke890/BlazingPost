using System.Text;

namespace BlazingPostMan.Services.StrBuilder
{
    public class StringBuilderService : IStringBuilderService
    {
        private readonly StringBuilder _stringBuilder;

        public StringBuilderService()
        {
            _stringBuilder = new();
        }

        public void Add(string value, bool asLine = true)
        {
            if (string.IsNullOrEmpty(value))
            {
                return;
            }

            if (asLine)
            {
                _stringBuilder.AppendLine(value);
            }
            else
            {
                _stringBuilder.Append(value);
            }
        }

        public string Get()
        {
            return _stringBuilder.ToString();
        }
    }
}
