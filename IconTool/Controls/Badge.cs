using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace IconTool.Controls
{
    /// <summary>
    /// 按照步骤 1a 或 1b 操作，然后执行步骤 2 以在 XAML 文件中使用此自定义控件。
    ///
    /// 步骤 1a) 在当前项目中存在的 XAML 文件中使用该自定义控件。
    /// 将此 XmlNamespace 特性添加到要使用该特性的标记文件的根
    /// 元素中:
    ///
    ///     xmlns:MyNamespace="clr-namespace:IconTool.Controls"
    ///
    ///
    /// 步骤 1b) 在其他项目中存在的 XAML 文件中使用该自定义控件。
    /// 将此 XmlNamespace 特性添加到要使用该特性的标记文件的根
    /// 元素中:
    ///
    ///     xmlns:MyNamespace="clr-namespace:IconTool.Controls;assembly=IconTool.Controls"
    ///
    /// 您还需要添加一个从 XAML 文件所在的项目到此项目的项目引用，
    /// 并重新生成以避免编译错误:
    ///
    ///     在解决方案资源管理器中右击目标项目，然后依次单击
    ///     “添加引用”->“项目”->[浏览查找并选择此项目]
    ///
    ///
    /// 步骤 2)
    /// 继续操作并在 XAML 文件中使用控件。
    ///
    ///     <MyNamespace:Badge/>
    ///
    /// </summary>
    [TemplatePart(Name = "PART_TEXTBLOCK",Type = typeof(TextBlock))]
    public class Badge : Control
    {

        private const string TextBlockTemplateName = "PART_TEXTBLOCK";

        static Badge()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(Badge), new FrameworkPropertyMetadata(typeof(Badge)));
        }

        /// <summary>
        /// 是否是小圆点
        /// </summary>
        public bool IsDot
        {
            get { return (bool)GetValue(IsDotProperty); }
            set { SetValue(IsDotProperty, value); }
        }

        // Using a DependencyProperty as the backing store for IsDot.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IsDotProperty =
            DependencyProperty.Register("IsDot", typeof(bool), typeof(Badge), new PropertyMetadata(false));



        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Text.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TextProperty =
            DependencyProperty.Register("Text", typeof(string), typeof(Badge), new PropertyMetadata(null));
        public void ChangeSize(Size arrangeBounds) {
            if (_textControl != null)
            {
                Arrange(new Rect(-_textControl.ActualWidth / 2, -_textControl.ActualHeight / 2, arrangeBounds.Width + _textControl.ActualWidth, arrangeBounds.Height + _textControl.ActualHeight));
            }
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            _textControl = GetTemplateChild(TextBlockTemplateName) as TextBlock;
        }

        public TextBlock _textControl;
    }
}
