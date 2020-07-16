using IconTool.Helper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;

namespace IconTool.Controls
{
    public class IconAssists
    {
        #region 图标类型


        public static EnumIcon GetIcon(DependencyObject obj)
        {
            return (EnumIcon)obj.GetValue(IconProperty);
        }

        public static void SetIcon(DependencyObject obj, EnumIcon value)
        {
            obj.SetValue(IconProperty, value);
        }

        // Using a DependencyProperty as the backing store for Icon.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IconProperty =
            DependencyProperty.RegisterAttached("Icon", typeof(EnumIcon), typeof(IconAssists), new PropertyMetadata(EnumIcon.Default, IconPropertyChanged));

        private static void IconPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is Path path)
            {
                if (Enum.TryParse(e.NewValue.ToString(), out EnumIcon icon))
                {
                    var source = Geometry.Parse(IconDataFactory.IconDic[icon]);
                    path.Data = source;
                }
            }
        }


        #endregion

        #region 宽，默认16
        public static double GetWidth(DependencyObject obj)
        {
            return (double)obj.GetValue(WidthProperty);
        }

        public static void SetWidth(DependencyObject obj, double value)
        {
            obj.SetValue(WidthProperty, value);
        }

        // Using a DependencyProperty as the backing store for Width.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty WidthProperty =
            DependencyProperty.RegisterAttached("Width", typeof(double), typeof(IconAssists), new PropertyMetadata(16.0));
        #endregion

        #region 高，默认16


        public static double GetHeight(DependencyObject obj)
        {
            return (double)obj.GetValue(HeightProperty);
        }

        public static void SetHeight(DependencyObject obj, double value)
        {
            obj.SetValue(HeightProperty, value);
        }

        // Using a DependencyProperty as the backing store for Height.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty HeightProperty =
            DependencyProperty.RegisterAttached("Height", typeof(double), typeof(IconAssists), new PropertyMetadata(16.0));


        #endregion

        #region 图标Stork
        public static Brush GetStroke(DependencyObject obj)
        {
            return (Brush)obj.GetValue(StrokeProperty);
        }

        public static void SetStroke(DependencyObject obj, Brush value)
        {
            obj.SetValue(StrokeProperty, value);
        }

        // Using a DependencyProperty as the backing store for Stroke.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty StrokeProperty =
            DependencyProperty.RegisterAttached("Stroke", typeof(Brush), typeof(IconAssists));
        #endregion

        #region 图标填充色


        public static Brush GetFill(DependencyObject obj)
        {
            return (Brush)obj.GetValue(FillProperty);
        }

        public static void SetFill(DependencyObject obj, Brush value)
        {
            obj.SetValue(FillProperty, value);
        }

        // Using a DependencyProperty as the backing store for Fill.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty FillProperty =
            DependencyProperty.RegisterAttached("Fill", typeof(Brush), typeof(IconAssists), new PropertyMetadata(Brushes.Black));


        #endregion

        #region 图标位置 目前只支持水平
        public static HorizontalAlignment GetPosition(DependencyObject obj)
        {
            return (HorizontalAlignment)obj.GetValue(PositionProperty);
        }

        public static void SetPosition(DependencyObject obj, HorizontalAlignment value)
        {
            obj.SetValue(PositionProperty, value);
        }

        // Using a DependencyProperty as the backing store for Position.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PositionProperty =
            DependencyProperty.RegisterAttached("Position", typeof(HorizontalAlignment), typeof(IconAssists), new PropertyMetadata(HorizontalAlignment.Left));
        #endregion




    }
}
