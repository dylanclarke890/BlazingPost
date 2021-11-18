using BlazingPostMan.Data.Models;
using System.Collections.Generic;
using System.Diagnostics;

namespace BlazingPostMan.Services.DataManager
{
    public class RequestDataManager : IRequestDataManager
    {
        public RequestDataManager()
        {
            PastRequests ??= new();
        }

        private List<Request> PastRequests { get; set; }

        private Request CurrentRequest;

        public Request GetRequest()
        {
            return CurrentRequest ??= new();
        }

        public void SaveRequest(bool clearRequestAfter = false)
        {
            PastRequests.Add(CurrentRequest);
            if (clearRequestAfter)
            {
                ClearCurrentRequest();
            }
        }

        public void ClearCurrentRequest()
        {
            CurrentRequest = null;
        }

        public void PrintPastRequests()
        {
            for (int i = 0; i < PastRequests.Count; i++)
            {
                Debug.WriteLine($"Number: {i}, {PastRequests[i].Url}");
                Debug.WriteLine($"Number: {i}, {PastRequests[i].RequestType}");
            }
        }
    }
}
