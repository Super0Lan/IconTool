using Prism.Commands;
using Prism.Mvvm;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace IconTool.ViewModels
{
    public class SettingViewModel : BindableBase, IDialogAware
    {
        private string _message = Guid.NewGuid().ToString();
        public string Message { get { return _message; } set { SetProperty(ref _message, value); } }

        public string Title => "设置";

        public event Action<IDialogResult> RequestClose;

        public DelegateCommand<string> CloseDialogCommand { get; private set; }

        public SettingViewModel() {
            CloseDialogCommand = new DelegateCommand<string>(OnClickOk);
            Timer timer = new Timer((stat) =>
            {
                App.UIDispatcher.Invoke(() =>
                {
                    Message = Guid.NewGuid().ToString();
                });
            });
            timer.Change(0, 1000);
            
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
