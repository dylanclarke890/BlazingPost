using BlazingPostMan.Data.Enums;
using BlazingPostMan.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazingPostMan.Services.DataManager
{
    public class RequestDataManager
    {
        public Dictionary<string, string> HeaderKeys { get; set; }
        public Dictionary<string, string> QueryParamKeys { get; set; }
    }
}
