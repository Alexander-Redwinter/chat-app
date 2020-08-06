using System;
using System.Collections.Generic;
using System.Text;

namespace ChatApp.Core
{
    public class ChatListViewModel : BaseViewModel
    {
        public string DisplayTitle { get; set; }
        public List<ChatItemViewModel> Items { get; set; }
    }
}
