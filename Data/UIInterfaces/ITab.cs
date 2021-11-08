using Microsoft.AspNetCore.Components;

namespace BlazingPostMan.Data.UIInterfaces
{
    public interface ITab
    {
        public RenderFragment ChildContent { get; }
    }
}
