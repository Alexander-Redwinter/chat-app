using System.Windows;
using System.Windows.Controls;

namespace ChatApp
{
    public class HasTextProperty : BaseAttachedProperty<HasTextProperty, bool>
    {
        public static void SetValue(DependencyObject sender)
        {
            HasTextProperty.SetValue(sender, ((PasswordBox)sender).SecurePassword.Length > 0);
        }

    }

    public class MonitorPasswordProperty : BaseAttachedProperty<MonitorPasswordProperty, bool>
    {
        public override void OnValueChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            PasswordBox passwordBox = sender as PasswordBox;

            if (passwordBox == null)
                return;

            passwordBox.PasswordChanged -= PasswordBox_PasswordChanged;

            if ((bool)e.NewValue)
            {
                HasTextProperty.SetValue(passwordBox);
                passwordBox.PasswordChanged += PasswordBox_PasswordChanged;
            }

        }

        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {

            HasTextProperty.SetValue((PasswordBox) sender);

        }
    }

}
