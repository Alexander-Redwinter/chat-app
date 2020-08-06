using System;
using System.Windows;

namespace ChatApp
{
    /// <summary>
    /// Interaction logic for MessageBox.xaml
    /// </summary>
    public partial class MessageBox : Window
    {

        private MessageBoxWindowViewModel messageBoxViewModel;

        public MessageBoxWindowViewModel ViewModel
        {
            get => messageBoxViewModel;

            set
            {
                messageBoxViewModel = value;
                DataContext = messageBoxViewModel;
            }
        }

        public MessageBox()
        {
            InitializeComponent();

            DataContext = new MessageBoxWindowViewModel(this);


        }

        /// <summary>
        /// Refreshes window for dynamic scaling (SizeToContent="WidthAndHeight")
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_OnContentRendered(object sender, EventArgs e)
        {
            InvalidateVisual();
        }
    }
}
