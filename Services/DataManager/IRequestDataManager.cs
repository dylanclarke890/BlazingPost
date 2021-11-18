using BlazingPostMan.Data.Models;

namespace BlazingPostMan.Services.DataManager
{
    public interface IRequestDataManager
    {
        Request GetRequest();
        void SaveRequest(bool clearRequestAfter = false);
        void PrintPastRequests();
    }
}