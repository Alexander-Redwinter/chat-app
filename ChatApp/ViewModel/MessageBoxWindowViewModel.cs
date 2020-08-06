using System.Windows;
using System.Windows.Controls;

namespace ChatApp
{
    public class MessageBoxWindowViewModel : WindowViewModel
    {

        public string Title { get; set; }

        public Control Content { get; set; }
        public MessageBoxWindowViewModel(Window window) : base(window)
        {

        }
    }
}
