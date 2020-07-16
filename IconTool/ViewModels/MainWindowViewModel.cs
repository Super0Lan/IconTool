using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;

namespace IconTool.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        private readonly IRegionManager _regionManager;
        public MainWindowViewModel(IRegionManager regionManager) {
            _regionManager = regionManager;
        }
    }
}
