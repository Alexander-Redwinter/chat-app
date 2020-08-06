using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace ChatApp
{
    public class PanelChildMarginAttachedProperty : BaseAttachedProperty<PanelChildMarginAttachedProperty, string>
    {
        public override void OnValueChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            var panel = (sender as Panel);

            panel.Loaded += (s, ee) =>
            {
                foreach(FrameworkElement child in panel.Children)
                    (child as FrameworkElement).Margin = (Thickness) new ThicknessConverter().ConvertFrom(e.NewValue as String); 
            };
        }

    }
}
