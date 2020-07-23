using IconTool.Extensions;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;

namespace IconTool.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        #region 当前的页面Path
        private string _path;
        public string Path
        {
            get { return _path; }
            set
            {
                if (SetProperty(ref _path, value)) {
                    Navigate(value);
                }
            }
        }
        #endregion


        private readonly IRegionManager _regionManager;
        private readonly IDialogService _dialogService;

        public DelegateCommand ShowSettingDialog { get; private set; }

        public MainWindowViewModel(IRegionManager regionManager,IDialogService dialogService)
        {
            _regionManager = regionManager;
            _dialogService = dialogService;
            ShowSettingDialog = new DelegateCommand(OnShowSettingDialog);
        }

        private void OnShowSettingDialog()
        {
            _dialogService.Show("SettingWindow", null, (r) =>
            {

            });
        }

        private void Navigate(string path)
        {
            if (!string.IsNullOrEmpty(path))
            {
                _regionManager.RequestNavigate("ContentRegion", path);
            }
        }
    }
}
