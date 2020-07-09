using IconTool.ViewModels;
using IconTool.Views;
using Prism.Ioc;
using Prism.Unity;
using System.Windows;
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
        }
    }
}
