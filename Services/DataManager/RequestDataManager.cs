using BlazingPostMan.Data.Models;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace BlazingPostMan.Services.DataManager
{
    public class RequestDataManager : IRequestDataManager
    {
        public RequestDataManager()
        {
            PastRequests ??= new();
        }

        private List<Request> PastRequests { get; set; }

        public Request GetLastRequest()
        {
            return PastRequests.Any() ? PastRequests.Last() : new();
        }

        public void SaveRequest(Request request)
        {
            PastRequests.Add(request.Clone());
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
