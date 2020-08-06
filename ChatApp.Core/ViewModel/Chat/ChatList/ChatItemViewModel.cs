using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;

namespace ChatApp.Core
{
    public class ChatItemViewModel : BaseViewModel
    {
        public ICommand OpenMessageCommand { get; set; }

        public string Name { get; set; }
        public string Message { get; set; }
        public string Initials { get; set; }
        public bool IsNewMessageAvailable { get; set; }
        public bool IsSelected { get; set; }
        public string BackgroundColorRGBHex { get; set; }

        public ChatItemViewModel()
        {
            OpenMessageCommand = new RelayCommand(OpenMessage);
        }

        private void OpenMessage()
        {
            Container.Application.GoToPage(DataModels.ApplicationPage.Chat, new ChatMessageListViewModel()
            {

                DisplayTitle = "Peko",

                Items = new ObservableCollection<ChatMessageListItemViewModel>
                {
                    new ChatMessageListItemViewModel
                    {
                        Message = "hi",
                        Initials = Initials,
                        MessageSentTime = DateTime.Now,
                        MessageReadTime = DateTime.Now,
                        SenderName = "Cirno",
                        IsSentByUser = true
                    },
                    new ChatMessageListItemViewModel
                    {
                        Message = "hi",
                        ImageAttachment = new ChatMessageListItemImageAttachmentViewModel
                        {
                            ThumbnailUrl = "http://"
                        },
                        Initials = Initials,
                        MessageSentTime = DateTime.Now,
                        MessageReadTime = DateTime.Now,
                        SenderName = "Cirno",
                        IsSentByUser = true
                    },
                    new ChatMessageListItemViewModel
                    {
                        Message = Message,
                        Initials = Initials,
                        MessageSentTime = DateTime.Now,
                        MessageReadTime = DateTime.Now,
                        SenderName = "Redwinter",
                        IsSentByUser = false
                    }
                }
            });
        }
    }
}
