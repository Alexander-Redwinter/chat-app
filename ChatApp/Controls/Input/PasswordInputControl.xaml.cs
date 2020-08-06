using ChatApp.Core;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;

namespace ChatApp
{
    /// <summary>
    /// Interaction logic for PasswordInputControl.xaml
    /// </summary>
    public partial class PasswordInputControl : UserControl
    {

        public GridLength LabelWidth
        {
            get { return (GridLength)GetValue(LabelWidthProperty); }
            set { SetValue(LabelWidthProperty, value); }
        }

        // Using a DependencyProperty as the backing store for LabelWidth.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty LabelWidthProperty =
            DependencyProperty.Register("LabelWidth", typeof(GridLength), typeof(PasswordInputControl), new PropertyMetadata(GridLength.Auto,LabelWidthChanged));

        public PasswordInputControl()
        {
            InitializeComponent();
        }

        private static void LabelWidthChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            try
            {

                (d as TextInputControl).LabelColumnDefinition.Width = (GridLength)e.NewValue;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                Debugger.Break();
                (d as TextInputControl).LabelColumnDefinition.Width = GridLength.Auto;
            }
        }


        private void CurrentPassword_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (DataContext is PasswordEntryViewModel viewModel)
                viewModel.OriginalPassword = CurrentPassword.SecurePassword;
        }

        private void NewPassword_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (DataContext is PasswordEntryViewModel viewModel)
                viewModel.EditedPassword = NewPassword.SecurePassword;
        }

        private void ConfirmPassword_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (DataContext is PasswordEntryViewModel viewModel)
                viewModel.ConfirmPassword = ConfirmPassword.SecurePassword;
        }
    }
}
