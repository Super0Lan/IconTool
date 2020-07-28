using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Text;

namespace IconTool.PrismExtensions
{
    public static class IDialogWindowExtensions
    {
        internal static IDialogAware GetDialogViewModel(this IDialogWindow dialogWindow)
        {
            return (IDialogAware)dialogWindow.DataContext;
        }
    }
}
