using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;

namespace ChatApp
{
    /// <summary>
    /// Interaction logic for TextInputControl.xaml
    /// </summary>
    public partial class TextInputControl : UserControl
    {





        public GridLength LabelWidth
        {
            get { return (GridLength)GetValue(LabelWidthProperty); }
            set { SetValue(LabelWidthProperty, value); }
        }

        // Using a DependencyProperty as the backing store for LabelWidth.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty LabelWidthProperty =
            DependencyProperty.Register("LabelWidth", typeof(GridLength), typeof(TextInputControl), new PropertyMetadata(GridLength.Auto,LabelWidthChanged));

        public TextInputControl()
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
    }
}
