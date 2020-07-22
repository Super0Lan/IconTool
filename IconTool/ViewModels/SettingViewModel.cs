using Prism.Commands;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Text;

namespace IconTool.ViewModels
{
    public class SettingViewModel : IDialogAware
    {
        public string Title => "设置";

        public event Action<IDialogResult> RequestClose;

        public DelegateCommand<string> CloseDialogCommand { get; private set; }

        public SettingViewModel() {
            CloseDialogCommand = new DelegateCommand<string>(OnClickOk);
            
        }

        private void OnClickOk(string obj)
        {
            RequestClose?.Invoke(new DialogResult(ButtonResult.OK));
        }

        public bool CanCloseDialog()
        {
            return true;
        }

        public void OnDialogClosed()
        {
           
        }



        public void OnDialogOpened(IDialogParameters parameters)
        {
            
        }
    }
}
