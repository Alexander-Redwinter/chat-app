using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatApp.Core
{
    public class AttachmentMenuViewModel : BasePopupViewModel
    {
        public AttachmentMenuViewModel()
        {
            Content = new MenuViewModel
            {
                Items = new List<MenuItemViewModel>(
                new []
                {
                    new MenuItemViewModel { Type = MenuItemType.Header, Text = "Attach a file"},
                    new MenuItemViewModel { Text = "Search on Computer", IconType = IconType.File},
                    new MenuItemViewModel { Text = "From Pictures", IconType = IconType.Picture}
                })
            };
        }
    }
}
