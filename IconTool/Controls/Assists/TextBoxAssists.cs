using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace IconTool.Controls
{
    public class TextBoxAssists
    {
        #region 文本框，点击回车提交内容。失去焦点。
        public static bool GetEnterToSubmit(DependencyObject obj)
        {
            return (bool)obj.GetValue(EnterToSubmitProperty);
        }

        public static void SetEnterToSubmit(DependencyObject obj, bool value)
        {
            obj.SetValue(EnterToSubmitProperty, value);
        }

        // Using a DependencyProperty as the backing store for EnterToSubmit.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty EnterToSubmitProperty =
            DependencyProperty.RegisterAttached("EnterToSubmit", typeof(bool), typeof(TextBoxAssists), new PropertyMetadata(false,OnEnterToSubmitPropertyChanged));

        private static void OnEnterToSubmitPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is TextBox textBox) {
                if ((bool)e.NewValue) {
                    textBox.PreviewKeyDown += TextBox_PreviewKeyDown;
                }
                else {
                    textBox.PreviewKeyDown -= TextBox_PreviewKeyDown;
                }
             
            }
        }

        private static void TextBox_PreviewKeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == System.Windows.Input.Key.Enter) {
                (sender as TextBox).MoveFocus(new System.Windows.Input.TraversalRequest(System.Windows.Input.FocusNavigationDirection.Next));
            }
        }
        #endregion




    }
}
