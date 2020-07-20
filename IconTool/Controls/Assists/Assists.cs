using IconTool.Extensions;
using IconTool.Helper;
using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;

namespace IconTool.Controls
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

        #region 水印 PlaceHolder


        public static object GetPlaceHolder(DependencyObject obj)
        {
            return obj.GetValue(PlaceHolderProperty);
        }

        public static void SetPlaceHolder(DependencyObject obj, object value)
        {
            obj.SetValue(PlaceHolderProperty, value);
        }

        // Using a DependencyProperty as the backing store for PlaceHolder.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PlaceHolderProperty =
            DependencyProperty.RegisterAttached("PlaceHolder", typeof(object), typeof(Assists));

        #region 水印颜色
        public static Brush GetPlaceHolderBrush(DependencyObject obj)
        {
            return (Brush)obj.GetValue(PlaceHolderBrushProperty);
        }

        public static void SetPlaceHolderBrush(DependencyObject obj, Brush value)
        {
            obj.SetValue(PlaceHolderBrushProperty, value);
        }

        // Using a DependencyProperty as the backing store for PlaceHolderBrush.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PlaceHolderBrushProperty =
            DependencyProperty.RegisterAttached("PlaceHolderBrush", typeof(Brush), typeof(Assists), new PropertyMetadata(new BrushConverter().ConvertFromString("#dcdfe6")));
        #endregion

        #endregion

        #region 是否可以清空


        public static bool GetClearable(DependencyObject obj)
        {
            return (bool)obj.GetValue(ClearableProperty);
        }

        public static void SetClearable(DependencyObject obj, bool value)
        {
            obj.SetValue(ClearableProperty, value);
        }

        // Using a DependencyProperty as the backing store for Clearable.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ClearableProperty =
            DependencyProperty.RegisterAttached("Clearable", typeof(bool), typeof(Assists), new PropertyMetadata(false));


        #endregion

        #region Badge
        public static Badge GetBadge(DependencyObject obj)
        {
            return (Badge)obj.GetValue(BadgeProperty);
        }

        public static void SetBadge(DependencyObject obj, Badge value)
        {
            obj.SetValue(BadgeProperty, value);
        }

        // Using a DependencyProperty as the backing store for Badge.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty BadgeProperty =
            DependencyProperty.RegisterAttached("Badge", typeof(Badge), typeof(Assists), new PropertyMetadata(null, BadgePropertyChanged));

        private static void BadgePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is UIElement uIElement)
            {
                if (e.NewValue is Badge badge)
                {
                    var adorner = (BadgeAdorber)uIElement.GetOrAddAdorner(typeof(BadgeAdorber));
                    adorner.SetBadge(badge);
                }
            }
        }
        #endregion


    }
}
