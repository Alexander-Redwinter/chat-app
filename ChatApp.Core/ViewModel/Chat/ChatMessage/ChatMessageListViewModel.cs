using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ChatApp.Core
{
    public class ChatMessageListViewModel : BaseViewModel
    {
        protected string lastSearchText;
        protected string searchText;
        protected bool searchIsOpen;
        protected ObservableCollection<ChatMessageListItemViewModel> items;
        public ObservableCollection<ChatMessageListItemViewModel> Items
        {
            get => items;
            set
            {
                if (items == value)
                    return;
                items = value;
                FilteredItems = new ObservableCollection<ChatMessageListItemViewModel>(items);
            }
        }
        public ObservableCollection<ChatMessageListItemViewModel> FilteredItems { get; set; }
        public string DisplayTitle { get; set; }
        public string SearchText
        {
            get => searchText;
            set
            {
                if (searchText == value)
                    return;
                searchText = value;
                if (string.IsNullOrEmpty(SearchText))
                    Search();
            }
        }
        public bool SearchIsOpen
        {
            get => searchIsOpen;
            set
            {
                if (searchIsOpen == value)
                    return;

                searchIsOpen = value;

                if (!SearchIsOpen)
                    SearchText = string.Empty;
            }
        }

        public ICommand SearchCommand { get; set; }
        public ICommand OpenSearchCommand { get; set; }
        public ICommand CloseSearchCommand { get; set; }
        public ICommand ClearSearchCommand { get; set; }
        public ICommand AttachmentButtonCommand { get; set; }
        public ICommand HidePopupCommand { get; set; }
        public ICommand SendCommand { get; set; }

        public string PendingMessageText { get; set; }
        public bool AttachmentMenuVisible { get; set; } = false;
        public bool AnyPopupVisible => AttachmentMenuVisible;


        public AttachmentMenuViewModel AttachmentMenu { get; set; }
        public ChatMessageListViewModel()
        {
            AttachmentButtonCommand = new RelayCommand(AttachmentButton);
            HidePopupCommand = new RelayCommand(HidePopups);
            SendCommand = new RelayCommand(Send);
            SearchCommand = new RelayCommand(Search);
            OpenSearchCommand = new RelayCommand(OpenSearch);
            CloseSearchCommand = new RelayCommand(CloseSearch);
            ClearSearchCommand = new RelayCommand(ClearSearch);

            AttachmentMenu = new AttachmentMenuViewModel();
        }

        private void Search()
        {
            if ((string.IsNullOrEmpty(lastSearchText) && string.IsNullOrEmpty(SearchText)) ||
                string.Equals(lastSearchText, SearchText))
                return;

            if (string.IsNullOrEmpty(SearchText) || Items == null || Items.Count <= 0)
            {
                FilteredItems = new ObservableCollection<ChatMessageListItemViewModel>(Items);
                lastSearchText = SearchText;
                return;
            }

            //TODO more efficient search
            FilteredItems = new ObservableCollection<ChatMessageListItemViewModel>(Items.Where(i => i.Message.ToLower().Contains(SearchText)));

            lastSearchText = SearchText;

        }

        private void ClearSearch()
        {
            if (!string.IsNullOrEmpty(SearchText))
                SearchText = string.Empty;
            else
                SearchIsOpen = false;
        }

        private void CloseSearch() => SearchIsOpen = false;

        private void OpenSearch() => SearchIsOpen = true;


        private void AttachmentButton() => AttachmentMenuVisible ^= true;

        private void HidePopups() => AttachmentMenuVisible = false;

        public async void Send()
        {
            if (string.IsNullOrEmpty(PendingMessageText))
                return;

            if (Items == null)
                Items = new ObservableCollection<ChatMessageListItemViewModel>();
            if (FilteredItems == null)
                FilteredItems = new ObservableCollection<ChatMessageListItemViewModel>();

            //TODO actual text sending
            var message = new ChatMessageListItemViewModel()
            {
                Initials = "AR",
                Message = PendingMessageText,
                MessageSentTime = DateTime.Now,
                IsSentByUser = true,
                SenderName = "Alexander Redwinter",
                NewItem = true
            };

            //Proper places for these
            //TODO add disable send button while text is in flight
            try
            {
                await Container.ClientService.Connect();

                Container.ClientService.Send(PendingMessageText);

            }
            catch(Exception ex)
            {
                await Container.UI.ShowMessage(new MessageBoxViewModel() { Message = ex.Message});
            }

            FilteredItems.Add(message);

            PendingMessageText = string.Empty;

        }

    }
}
