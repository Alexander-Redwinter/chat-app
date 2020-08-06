using ChatApp.Core.DataModels;
using System.Collections.Generic;

namespace ChatApp.Core
{
    /// <summary>
    /// View model for vertical menu
    /// </summary>
    public class MenuViewModel : BaseViewModel
    {
        /// <summary>
        /// Items in the menu
        /// </summary>
        public List<MenuItemViewModel> Items{ get; set; }

    }
}
