using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace ChatApp
{
    /// <summary>
    /// Match width of all <see cref="TextInputControl"/> labels
    /// </summary>
    public class TextEntryWidthAttachedProperty : BaseAttachedProperty<TextEntryWidthAttachedProperty, string>
    {
        public override void OnValueChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            var panel = (sender as Panel);

            SetWidths(panel);

            RoutedEventHandler onLoaded = null;
            onLoaded += (s, ee) =>
            {
                //unhook
                panel.Loaded -= onLoaded;

                SetWidths(panel);

                foreach (var child in panel.Children)
                {
                    if (!(child is TextInputControl control))
                        continue;

                    control.Label.SizeChanged += (ss, eee) =>
                    {
                        SetWidths(panel);
                    };
                }
            };

            //hook
            panel.Loaded += onLoaded;

        }

        private void SetWidths(Panel panel)
        {
            double maxSize = 0d;

            foreach(var child in panel.Children)
            {
                if (!(child is TextInputControl control))
                    continue;

                maxSize = Math.Max(maxSize, control.Label.RenderSize.Width + control.Label.Margin.Left + control.Label.Margin.Right);

            }

            var gridLength = (GridLength)new GridLengthConverter().ConvertFromString(maxSize.ToString());


            foreach (var child in panel.Children)
            {
                if (!(child is TextInputControl control))
                    continue;

                control.LabelWidth =  gridLength;

            }
        }
    }
}
