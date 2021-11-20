using BlazingPostMan.Data.Models;

namespace BlazingPostMan.Services.DataManager
{
    public interface IRequestDataManager
    {
        Request GetLastRequest();
        void SaveRequest(Request request);
        void PrintPastRequests();
    }
}