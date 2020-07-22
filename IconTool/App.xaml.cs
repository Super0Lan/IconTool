using IconTool.ViewModels;
using IconTool.Views;
using Prism.Ioc;
using Prism.Modularity;
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
            containerRegistry.RegisterSingleton(typeof(MainWindowViewModel));
            containerRegistry.RegisterDialog<Setting,SettingViewModel>("SettingWindow");
            containerRegistry.RegisterDialogWindow<ChildWindow>();
        }

        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
           moduleCatalog.AddModule<Views.ModuleRight.ModuleRightModule>();
        }

        protected override void OnExit(ExitEventArgs e)
        {
            Settings.Default.Save();
            base.OnExit(e);
        }
    }
}
