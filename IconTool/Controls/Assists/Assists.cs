using IconTool.Extensions;
using System.Windows;

namespace IconTool
{
    public class Assists
    {
        #region 控件IsEnable 属性,用于重写IsEnable样式
        public static bool GetIsEnable(DependencyObject obj)
        {
            return (bool)obj.GetValue(IsEnableProperty);
        }

        public static void SetIsEnable(DependencyObject obj, bool value)
        {
            obj.SetValue(IsEnableProperty, value);
        }

        // Using a DependencyProperty as the backing store for IsEnable.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IsEnableProperty =
            DependencyProperty.RegisterAttached("IsEnable", typeof(bool), typeof(Assists), new PropertyMetadata(true, IsEnablePropertyChanged));

        private static void IsEnablePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is UIElement uIElement)
            {
                var adorner = (UnableAdorner)uIElement.GetOrAddAdorner(typeof(UnableAdorner));
                adorner.SetEnable((bool)e.NewValue);
            }
        }
        #endregion

        #region 表示矩形的角的半径。
        public static CornerRadius GetCornerRadius(DependencyObject obj)
        {
            return (CornerRadius)obj.GetValue(CornerRadiusProperty);
        }

        public static void SetCornerRadius(DependencyObject obj, CornerRadius value)
        {
            obj.SetValue(CornerRadiusProperty, value);
        }

        // Using a DependencyProperty as the backing store for CornerRadius.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CornerRadiusProperty =
            DependencyProperty.RegisterAttached("CornerRadius", typeof(CornerRadius), typeof(Assists), new PropertyMetadata(new CornerRadius(0)));
        #endregion

        #region 是否Loading
        public static bool GetLoading(DependencyObject obj)
        {
            return (bool)obj.GetValue(LoadingProperty);
        }

        public static void SetLoading(DependencyObject obj, bool value)
        {
            obj.SetValue(LoadingProperty, value);
        }

        // Using a DependencyProperty as the backing store for Loading.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty LoadingProperty =
            DependencyProperty.RegisterAttached("Loading", typeof(bool), typeof(Assists), new PropertyMetadata(false, LoadingPropertyChanged));

        private static void LoadingPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is UIElement uIElement)
            {
                var adorner = (LoadingAdorner)uIElement.GetOrAddAdorner(typeof(LoadingAdorner));
                adorner.SetLoading((bool)e.NewValue);
            }
        }
        #endregion
    }
}
