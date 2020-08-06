using ChatApp.Core.DataModels;

namespace ChatApp.Core
{
    /// <summary>
    /// View model for vertical menu item
    /// </summary>
    public class MenuItemViewModel : BaseViewModel
    {
        public string Text { get; set; }
        public MenuItemType Type { get; set; }
        public IconType IconType { get; set; }

    }
}
