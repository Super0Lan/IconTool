using IconTool.Extensions;
using IconTool.PrismExtensions;
using IconTool.Services.Interfaces;
using IconTool.ViewModels;
using IconTool.Views;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Services.Dialogs;
using Prism.Unity;
using System.Windows;
using System.Windows.Navigation;
using System.Windows.Threading;

namespace IconTool
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : PrismApplication
    {
        public static Dispatcher UIDispatcher { get; private set; }

        protected override void OnStartup(StartupEventArgs e)
        {
            UIDispatcher = Current.Dispatcher;
            base.OnStartup(e);
        }

        protected override Window CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }
        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.Register<IToolDialogService,ToolDialogService>();
            containerRegistry.Register<IToolServices, Services.Resolves.ToolServices>();
            containerRegistry.Register<ISetting, Services.Resolves.Setting>();
            containerRegistry.RegisterSingleton(typeof(MainWindowViewModel));
            containerRegistry.RegisterDialog<Setting,SettingViewModel>("Setting");
            containerRegistry.RegisterDialogWindow<ChildWindow>();
            containerRegistry.RegisterDialogWindow<SettingWindow>("SettingWindow");
        }

        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
           moduleCatalog.AddModule<Views.ModuleRight.ModuleRightModule>();
           moduleCatalog.AddModule<Views.ModuleSetting.ModuleSettingModule>();
        }

        protected override void OnExit(ExitEventArgs e)
        {
            Settings.Default.Save();
            base.OnExit(e);
        }
    }
}
