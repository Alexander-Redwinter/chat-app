using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace ChatApp
{
    public abstract class BaseAttachedProperty<Parent, Property>
        where Parent : new()
    {
        public static Parent Instance { get; private set; } = new Parent();

        public event Action<DependencyObject,DependencyPropertyChangedEventArgs> ValueChanged = (sender, e) => { };

        public event Action<DependencyObject, object> ValueUpdated = (sender, value) => { };


        //attached property for this class
        public static readonly DependencyProperty ValueProperty = DependencyProperty
        .RegisterAttached("Value",
            typeof(Property), 
            typeof(BaseAttachedProperty<Parent, Property>), 
            new UIPropertyMetadata(default(Property),new PropertyChangedCallback(OnValuePropertyChanged),new CoerceValueCallback(OnValuePropertyUpdated)));

        private static object OnValuePropertyUpdated(DependencyObject d, object value)
        {
            (Instance as BaseAttachedProperty<Parent, Property>)?.OnValueUpdated(d, value);

            (Instance as BaseAttachedProperty<Parent, Property>)?.ValueUpdated(d, value);

            return value;
        }

        //callback event when ValueProperry is changed
        //d is UI element that had it's property changed
        private static void OnValuePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e) 
        {
            (Instance as BaseAttachedProperty<Parent, Property>)?.OnValueChanged(d, e);

            (Instance as BaseAttachedProperty<Parent, Property>)?.ValueChanged(d, e);

        }

        public static void SetValue(DependencyObject d, Property value) => d.SetValue(ValueProperty, value);

        public static Property GetValue(DependencyObject d) => (Property) d.GetValue(ValueProperty);

        public virtual void OnValueChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e) { }

        public virtual void OnValueUpdated(DependencyObject sender, object value) { }


    }
}
