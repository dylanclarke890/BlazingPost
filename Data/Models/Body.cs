using BlazingPostMan.Data.Enums;
using Microsoft.AspNetCore.Components.Forms;
using System.Collections.Generic;

namespace BlazingPostMan.Data.Models
{
    public class Body
    {
        public BodyType BodyType { get; set; }

        public string StringContent { get; set; }

        public List<IBrowserFile> FileContent { get; set; }
    }
}
