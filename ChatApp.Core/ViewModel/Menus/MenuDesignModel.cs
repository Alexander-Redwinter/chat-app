using ChatApp.Core.DataModels;
using System.Collections.Generic;

namespace ChatApp.Core
{
    /// <summary>
    /// Design time data for <see cref="MenuViewModel"/>
    /// </summary>
    public class MenuDesignModel : MenuViewModel
    {
        /// <summary>
        /// Singleton instance of the design model
        /// </summary>
        public static MenuDesignModel Instance => new MenuDesignModel();
        public MenuDesignModel()
        {
            Items = new List<MenuItemViewModel>(new[]
            {
                new MenuItemViewModel { Type = MenuItemType.Header, Text = "Design Header"},
                new MenuItemViewModel { Text = "File Item", IconType = IconType.File},
                new MenuItemViewModel { Text = "Pictures Item", IconType = IconType.Picture}
            });

        }
    }
}
