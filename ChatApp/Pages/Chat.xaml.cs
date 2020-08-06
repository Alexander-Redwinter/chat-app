using ChatApp.Core;
using System;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Animation;

namespace ChatApp
{
    public partial class Chat : BasePage<ChatMessageListViewModel>
    {
        public Chat() : base()
        {
            InitializeComponent();

        }
        public Chat(ChatMessageListViewModel viewModel) : base(viewModel)
        {
            InitializeComponent();

        }

        protected override void OnViewModelChanged()
        {
            //make sure UI exists
            if (ChatMessageList == null)
                return;

            var storyboard = new Storyboard();
            storyboard.AddFadeIn(0.5f);
            storyboard.Begin(ChatMessageList);

            MessageText.Focus();
        }

        private void MessageText_PreviewKeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            var textBox = (sender as TextBox);

            if (e.Key == Key.Enter)
            {
                if (Keyboard.Modifiers.HasFlag(ModifierKeys.Control))
                {
                    var index = textBox.CaretIndex;

                    textBox.Text = textBox.Text.Insert(index, Environment.NewLine);

                    //shift caret to the end
                    textBox.CaretIndex = index + Environment.NewLine.Length;
                }
                else
                    ViewModel.Send();

                e.Handled = true;

            }
        }
    }
}
