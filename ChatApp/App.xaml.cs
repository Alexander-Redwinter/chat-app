using ChatApp.Core;
using ChatApp.IoC;
using Ninject.Infrastructure.Language;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace ChatApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            ApplicationSetup();

            Current.MainWindow = new MainWindow();
            Current.MainWindow.Show();
        }

        private void ApplicationSetup()
        {

            Container.Setup();


            Container.Kernel.Bind<ILogFactory>().ToConstant(new BaseLogFactory(new[]
            {
                new FileLogger("log.txt"),
            }));
            
            Container.Kernel.Bind<ITaskManager>().ToConstant(new TaskManager());

            Container.Kernel.Bind<IFileManager>().ToConstant(new FileManager());

            Container.Kernel.Bind<IUIManager>().ToConstant(new UIManager());

            Container.Logger.Log("Application starting");

        }
    }
}
