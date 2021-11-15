namespace BlazingPostMan.Services.StrBuilder
{
    public interface IStringBuilderService
    {
        void Add(string value, bool asLine = false);
        string Get();
    }
}