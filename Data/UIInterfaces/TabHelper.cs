using BlazingPostMan.Shared.Tab;

namespace BlazingPostMan.Data.UIInterfaces
{
    public static class TabHelper
    {
        public static void SetTabForTabSet(TabSet tabSet, TabChild tabChild)
        {
            tabSet.SetActiveTab(tabChild);
        }
    }
}
