using Prism.Services.Dialogs;
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
using System.Windows.Shapes;

namespace IconTool.Views
{
    /// <summary>
    /// ChildWindow.xaml 的交互逻辑
    /// </summary>
    public partial class ChildWindow : Window,IDialogWindow
    {
        public IDialogResult Result { get; set; }

        public ChildWindow()
        {
            InitializeComponent();
        }
    }
}
