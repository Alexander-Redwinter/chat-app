using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Text;

namespace ChatApp.Core
{

    public class ChatItemListDesign : ChatListViewModel
    {

        public static ChatItemListDesign Instance => new ChatItemListDesign();

        public ChatItemListDesign()
        {

            DisplayTitle = "Cirno";
            Items = new List<ChatItemViewModel>()
            {
                new ChatItemViewModel(){Name = "Cirno", Initials = "C", Message = "9", BackgroundColorRGBHex = "3f5171",  IsSelected = true},
                new ChatItemViewModel(){Name = "Usada Pekora", Initials = "UP", Message = "ぺこ", BackgroundColorRGBHex = "3f5171", IsNewMessageAvailable = true},
                new ChatItemViewModel(){Name = "Cheems", Initials = "C", Message = "cheemsburger", BackgroundColorRGBHex = "cd5c5c"},
                new ChatItemViewModel(){Name = "Tom", Initials = "T", Message = "Ben!", BackgroundColorRGBHex = "625581"},
                new ChatItemViewModel(){Name = "Ben", Initials = "B", Message = "Tom!", BackgroundColorRGBHex = "cd5c5c"},
                new ChatItemViewModel(){Name = "Doge", Initials = "D", Message = "wow", BackgroundColorRGBHex = "b45476"}
            };
        }

    }
}
