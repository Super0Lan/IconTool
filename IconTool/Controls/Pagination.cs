using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace IconTool
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
    ///     <MyNamespace:Pagination/>
    ///
    /// </summary>
    public class Pagination : ContentControl
    {
        static Pagination()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(Pagination), new FrameworkPropertyMetadata(typeof(Pagination)));
        }

        #region PageSize 每页显示条目个数


        public int PageSize
        {
            get { return (int)GetValue(PageSizeProperty); }
            set { SetValue(PageSizeProperty, value); }
        }

        // Using a DependencyProperty as the backing store for PageSize.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PageSizeProperty =
            DependencyProperty.Register("PageSize", typeof(int), typeof(Pagination), new PropertyMetadata(54));


        #endregion

        #region 总条目数



        public int Total
        {
            get { return (int)GetValue(TotalProperty); }
            set { SetValue(TotalProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Total.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TotalProperty =
            DependencyProperty.Register("Total", typeof(int), typeof(Pagination), new PropertyMetadata(0));


        #endregion

        #region PageCount 总页数，Total和PageCount设置任意一个就可以达到显示页码的功能；如果要支持PageSize的修改，则必须使用Total属性


        public int PageCount
        {
            get { return (int)GetValue(PageCountProperty); }
            set { SetValue(PageCountProperty, value); }
        }

        // Using a DependencyProperty as the backing store for PageCount.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PageCountProperty =
            DependencyProperty.Register("PageCount", typeof(int), typeof(Pagination), new PropertyMetadata(0));


        #endregion

        #region PagerCount 页码按钮的熟练，当总页数超过该值时会折叠


        public int PagerCount
        {
            get { return (int)GetValue(PagerCountProperty); }
            set { SetValue(PagerCountProperty, value); }
        }

        // Using a DependencyProperty as the backing store for PagerCount.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PagerCountProperty =
            DependencyProperty.Register("PagerCount", typeof(int), typeof(Pagination), new PropertyMetadata(7));


        #endregion

        #region 每页显示个数选这起的选项设置


        public int[] PageSizes
        {
            get { return (int[])GetValue(PageSizesProperty); }
            set { SetValue(PageSizesProperty, value); }
        }

        // Using a DependencyProperty as the backing store for PageSizes.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PageSizesProperty =
            DependencyProperty.Register("PageSizes", typeof(int[]), typeof(Pagination), new PropertyMetadata(new int[] { 10, 20, 30, 40, 50, 100 }));


        #endregion

        #region 替代图标显示的上一页文字


        public string PrevText
        {
            get { return (string)GetValue(PrevTextProperty); }
            set { SetValue(PrevTextProperty, value); }
        }

        // Using a DependencyProperty as the backing store for PrevText.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PrevTextProperty =
            DependencyProperty.Register("PrevText", typeof(string), typeof(Pagination), new PropertyMetadata(default));


        #endregion

        #region 替代图标显示的下一页文字


        public string NextText
        {
            get { return (string)GetValue(NextTextProperty); }
            set { SetValue(NextTextProperty, value); }
        }

        // Using a DependencyProperty as the backing store for NextText.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty NextTextProperty =
            DependencyProperty.Register("NextText", typeof(string), typeof(Pagination), new PropertyMetadata(default));


        #endregion

        #region HideOnSinglePage 只有一页时是否隐藏


        public bool HideOnSinglePage
        {
            get { return (bool)GetValue(HideOnSinglePageProperty); }
            set { SetValue(HideOnSinglePageProperty, value); }
        }

        // Using a DependencyProperty as the backing store for HideOnSinglePage.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty HideOnSinglePageProperty =
            DependencyProperty.Register("HideOnSinglePage", typeof(bool), typeof(Pagination), new PropertyMetadata(false));


        #endregion


    }
}
