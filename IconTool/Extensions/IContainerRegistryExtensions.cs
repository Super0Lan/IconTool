using Prism.Ioc;
using System;
using System.Collections.Generic;
using System.Text;

namespace IconTool.Extensions
{
    public static class IContainerRegistryExtensions
    {
        /// <summary>
        /// Registers an object that implements IDialogWindow to be used to host all dialogs in the IDialogService.
        /// </summary>
        /// <typeparam name="TWindow">The Type of the Window class that will be used to host dialogs in the IDialogService</typeparam>
        /// <param name="containerRegistry"></param>
        public static void RegisterDialogWindow<TWindow>(this IContainerRegistry containerRegistry,string name) where TWindow : Prism.Services.Dialogs.IDialogWindow
        {
            containerRegistry.Register(typeof(Prism.Services.Dialogs.IDialogWindow), typeof(TWindow),name);
        }
    }
}
