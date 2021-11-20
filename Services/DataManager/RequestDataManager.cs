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
            UndoneRequests ??= new();
        }

        private List<Request> PastRequests { get; set; }
        private List<Request> UndoneRequests { get; set; }

        public Request GetLastRequest()
        {
            return PastRequests.Any() ? PastRequests.Last() : new();
        }

        public void SaveRequest(Request request)
        {
            PastRequests.Add(request.Clone());
            UndoneRequests = new();
        }

        public Request Undo()
        {
            var removedRequest = PastRequests.Last();

            UndoneRequests.Add(removedRequest);
            PastRequests.Remove(removedRequest);

            return GetLastRequest();
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
