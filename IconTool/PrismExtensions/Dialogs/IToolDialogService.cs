﻿using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Text;

namespace IconTool.PrismExtensions
{
    public interface IToolDialogService: IDialogService
    {
        /// <summary>
        /// Shows a non-modal dialog.
        /// </summary>
        /// <param name="name">The name of the dialog to show.</param>
        /// <param name="parameters">The parameters to pass to the dialog.</param>
        /// <param name="callback">The action to perform when the dialog is closed.</param>
        /// <param name="windowName">The name of the hosting window registered with the IContainerRegistry.</param>
        void Show(string name, IDialogParameters parameters, Action<IDialogResult> callback, string windowName);



        void Show(string name, IDialogParameters parameters, Action<IDialogResult> callback, string windowName,string unique);

        /// <summary>
        /// Shows a modal dialog.
        /// </summary>
        /// <param name="name">The name of the dialog to show.</param>
        /// <param name="parameters">The parameters to pass to the dialog.</param>
        /// <param name="callback">The action to perform when the dialog is closed.</param>
        /// <param name="windowName">The name of the hosting window registered with the IContainerRegistry.</param>
        void ShowDialog(string name, IDialogParameters parameters, Action<IDialogResult> callback, string windowName);
    }
}
