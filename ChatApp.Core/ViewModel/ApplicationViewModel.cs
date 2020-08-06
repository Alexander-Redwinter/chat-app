using ChatApp.Core.DataModels;
using System;

namespace ChatApp.Core
{
    public class ApplicationViewModel : BaseViewModel
    {

        public ApplicationPage CurrentPage { get; private set; } = ApplicationPage.Login;

        public BaseViewModel CurrentPageViewModel { get; set; }

        public bool IsSideMenuExpanded { get; set; } = false;
        public bool IsSettingsMenuExpanded { get; set; } = false;

        public bool IsGifHidden { get; set; } = true;

        internal void GoToPage(ApplicationPage page, BaseViewModel viewModel = null)
        {

            IsSettingsMenuExpanded = false;

            CurrentPageViewModel = viewModel;


            CurrentPage = page;

            OnPropertyChanged(nameof(CurrentPage));

            IsSideMenuExpanded = page == ApplicationPage.Chat;

        }
    }
}
