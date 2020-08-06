using ChatApp.Core;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace ChatApp
{
    /// <summary>
    /// Base control to be used inside <see cref="MessageBox"/>
    /// </summary>
    public class BaseDialogUserControl : UserControl
    {

        public int WindowMinWidth { get; set; } = 100;
        public int WindowMinHeight { get; set; } = 100;

        public int TitleHeight { get; set; } = 40;

        public string Title { get; set; }

        public ICommand CloseCommand { get; private set; }

        private MessageBox messageBox;

        public BaseDialogUserControl()
        {
            messageBox = new MessageBox();
            messageBox.ViewModel = new MessageBoxWindowViewModel(messageBox);
            CloseCommand = new RelayCommand(() => messageBox.Close());
        }

        public Task ShowDialog<T>(T viewModel)
            where T : BaseDialogViewModel
        {
            var completion = new TaskCompletionSource<bool>();

            Task.Run(() =>
            {

                //run on UI thread
                Application.Current.Dispatcher.Invoke(() =>
                {
                    try
                    {

                        messageBox.ViewModel.WindowMinimumHeight = WindowMinHeight;
                        messageBox.ViewModel.WindowMinimumWidth = WindowMinWidth;
                        messageBox.ViewModel.Title = string.IsNullOrEmpty(viewModel.Title) ? Title : viewModel.Title;

                        messageBox.ViewModel.Content = this;

                        DataContext = viewModel;

                        messageBox.Owner = Application.Current.MainWindow;
                        messageBox.WindowStartupLocation = WindowStartupLocation.CenterOwner;

                        messageBox.ShowDialog();

                    }
                    finally
                    {
                        //to let caller know it is finished
                        completion.TrySetResult(true);
                    }

                });

            });

            return completion.Task;
        }


    }
}
