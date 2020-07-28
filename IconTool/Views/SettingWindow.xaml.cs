using IconTool.PrismExtensions;
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
    /// SettingWindow.xaml 的交互逻辑
    /// </summary>
    public partial class SettingWindow : Window, IDialogWindow,ISingleWindow
    {
        public SettingWindow()
        {
            InitializeComponent();
        }

        public IDialogResult Result { get; set; }

        public string UniqueValue { get; set; }
    }
}
