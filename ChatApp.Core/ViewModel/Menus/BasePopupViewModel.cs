using ChatApp.Core;
using ChatApp.Core.DataModels;
using System;
using System.Windows;

namespace ChatApp.Core
{
    public class BasePopupViewModel : BaseViewModel
    {
        /// <summary>
        /// Content of this bubble
        /// </summary>
        public BaseViewModel Content { get; set; }
        /// <summary>
        /// Background color in HEX
        /// </summary>
        public String MenuBackgroundRGBHex { get; set; }
        /// <summary>
        /// Alignment of the bubble arrow
        /// </summary>
        public ElementHorizontalAlignment AnchorAlignment {get; set;}
        public BasePopupViewModel()
        {
            MenuBackgroundRGBHex = "fafafa";
            AnchorAlignment = ElementHorizontalAlignment.Left;
        }
    }
}
