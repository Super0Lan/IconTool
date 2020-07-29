using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace IconTool.Controls
{
    public class DialogAssists
    {


        public static bool GetAutoWireOwerWindow(DependencyObject obj)
        {
            return (bool)obj.GetValue(AutoWireOwerWindowProperty);
        }

        public static void SetAutoWireOwerWindow(DependencyObject obj, bool value)
        {
            obj.SetValue(AutoWireOwerWindowProperty, value);
        }

        // Using a DependencyProperty as the backing store for AutoWireOwerWindow.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty AutoWireOwerWindowProperty =
            DependencyProperty.RegisterAttached("AutoWireOwerWindow", typeof(bool), typeof(DialogAssists), new PropertyMetadata(false,OnAutoWireOwerWindowPropertyChanged));

        private static void OnAutoWireOwerWindowPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is Window window) {
                if ((bool)e.NewValue) {
                    window.Owner = Application.Current?.Windows.OfType<Window>().FirstOrDefault(x => x.IsActive);
                }
            }
        }
    }
}
