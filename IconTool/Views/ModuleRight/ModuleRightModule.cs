using Prism.Ioc;
using Prism.Modularity;
using System;
using System.Collections.Generic;
using System.Text;

namespace IconTool.Views.ModuleRight
{
    public class ModuleRightModule : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {
            
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<IconContent>();
        }
    }
}
