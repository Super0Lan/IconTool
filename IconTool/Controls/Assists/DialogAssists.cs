using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace IconTool.Controls
{
    public class DialogAssists
    {

        #region 是否自动设置OwnerWindow


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

        #endregion

        #region WindowStyle



        public static WindowStyle GetWindowStyle(DependencyObject obj)
        {
            return (WindowStyle)obj.GetValue(WindowStyleProperty);
        }

        public static void SetWindowStyle(DependencyObject obj, WindowStyle value)
        {
            obj.SetValue(WindowStyleProperty, value);
        }

        // Using a DependencyProperty as the backing store for WindowStyle.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty WindowStyleProperty =
            DependencyProperty.RegisterAttached("WindowStyle", typeof(WindowStyle), typeof(DialogAssists), new PropertyMetadata(WindowStyle.None));


        #endregion
    }
}
