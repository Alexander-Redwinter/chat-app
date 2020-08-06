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
                new ChatItemViewModel(){Name = "Cirno", Initials = "C", Message = "ok let's chill", BackgroundColorRGBHex = "3f5171",  IsSelected = true},
                new ChatItemViewModel(){Name = "Yoda", Initials = "Y", Message = "maximum pain i must endure", BackgroundColorRGBHex = "625581", IsNewMessageAvailable = true},
                new ChatItemViewModel(){Name = "Usada Pekora", Initials = "UP", Message = "ぺこ", BackgroundColorRGBHex = "3f5171", IsNewMessageAvailable = true},
                new ChatItemViewModel(){Name = "Akai Haato", Initials = "AH", Message = "feet", BackgroundColorRGBHex = "b45476", IsNewMessageAvailable = true},
                new ChatItemViewModel(){Name = "Kizuna Ai", Initials = "KA", Message = "hai domo", BackgroundColorRGBHex = "8d5484"},
                new ChatItemViewModel(){Name = "Suika Ibuki", Initials = "SI", Message = "sake plz", BackgroundColorRGBHex = "b45476"},
                new ChatItemViewModel(){Name = "Cheems", Initials = "C", Message = "cheemsburger", BackgroundColorRGBHex = "cd5c5c"},
                new ChatItemViewModel(){Name = "Tom", Initials = "T", Message = "Ben!", BackgroundColorRGBHex = "625581"},
                new ChatItemViewModel(){Name = "Ben", Initials = "B", Message = "Tom!", BackgroundColorRGBHex = "cd5c5c"},
                new ChatItemViewModel(){Name = "博霊 霊夢", Initials = "博霊", Message = "お賽銭",IsNewMessageAvailable = true, BackgroundColorRGBHex = "625581"},
                new ChatItemViewModel(){Name = "Doge", Initials = "D", Message = "wow", BackgroundColorRGBHex = "b45476"},
                new ChatItemViewModel(){Name = "Doomguy", Initials = "D", Message = "Where Isabelle", BackgroundColorRGBHex = "3f5171"}
            };
        }

    }
}
