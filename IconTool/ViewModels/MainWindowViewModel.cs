using Prism.Mvvm;
using Prism.Regions;
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
        public MainWindowViewModel(IRegionManager regionManager)
        {
            _regionManager = regionManager;
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
