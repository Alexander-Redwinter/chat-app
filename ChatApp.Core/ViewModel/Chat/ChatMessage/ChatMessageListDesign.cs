using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http.Headers;
using System.Text;

namespace ChatApp.Core
{

    public class ChatMessageListDesign : ChatMessageListViewModel
    {

        public static ChatMessageListDesign Instance => new ChatMessageListDesign();

        public ChatMessageListDesign()
        {
            Items = new ObservableCollection<ChatMessageListItemViewModel>()
            {
                new ChatMessageListItemViewModel(){ SenderName = "Cirno",
                    Message="you here? i wanna ask a very important and hard question ?????????????????",
                    Initials = "C",
                    ProfileColorRGBHex = "3f5171",
                    MessageReadTime = DateTimeOffset.UtcNow,
                    MessageSentTime = DateTimeOffset.UtcNow,
                    IsSentByUser=false},


                new ChatMessageListItemViewModel(){ SenderName = "Alexander Redwinter",
                    Message="Yeah what's up fire away ask your question i am just making this message long",
                    Initials = "AR",
                    ProfileColorRGBHex = "cd5c5c",
                    MessageReadTime = DateTimeOffset.UtcNow,
                    MessageSentTime = DateTimeOffset.UtcNow,
                    IsSentByUser=true},

                new ChatMessageListItemViewModel(){ SenderName = "Cirno",
                    Message="3 + 3 + 3 = 9?????",
                    Initials = "C",
                    ProfileColorRGBHex = "3f5171",
                    MessageReadTime = DateTimeOffset.UtcNow,
                    MessageSentTime = DateTimeOffset.UtcNow,
                    IsSentByUser=false},

                new ChatMessageListItemViewModel(){ SenderName = "Alexander Redwinter",
                    Message="Yup",
                    Initials = "AR",
                    ProfileColorRGBHex = "cd5c5c",
                    MessageReadTime = DateTimeOffset.UtcNow,
                    MessageSentTime = DateTimeOffset.UtcNow,
                    IsSentByUser=true},

                new ChatMessageListItemViewModel(){ SenderName = "Alexander Redwinter",
                    Message="Wanna chill",
                    Initials = "AR",
                    ProfileColorRGBHex = "cd5c5c",
                    MessageReadTime = DateTimeOffset.UtcNow,
                    MessageSentTime = DateTimeOffset.UtcNow,
                    IsSentByUser=true},

                new ChatMessageListItemViewModel(){ SenderName = "Cirno",
                    Message="ok let's chill",
                    Initials = "C",
                    ProfileColorRGBHex = "3f5171",
                    MessageReadTime = DateTimeOffset.UtcNow,
                    MessageSentTime = DateTimeOffset.UtcNow,
                    IsSentByUser=false},

            };
        }

    }
}
