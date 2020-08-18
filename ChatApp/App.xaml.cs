using ChatApp.Core;
using ChatApp.IoC;
using Ninject.Infrastructure.Language;
using Cornerstone;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using ChatApp.Relational;
using ChatApp.Core.DataModels;
using System.Threading;

namespace ChatApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        //Mutex to prevent multiple instances
        private static string appGuid = "86b12dc3-3e81-4ad8-8fdb-4fe4fc14a8ff";
        private static Mutex mutex = null;

        protected override async void OnStartup(StartupEventArgs e)
        {
            bool createdNew;
            mutex = new Mutex(true, @"Global\ControlPanel", out createdNew);
            if (!createdNew)
            {
                mutex = null;
                Application.Current.Shutdown();
                return;
            }

            base.OnStartup(e);

            await ApplicationSetupAsync();

            Container.Application.GoToPage(await Container.ClientDataStore.HasCredentialsAsync() ? ApplicationPage.Chat : ApplicationPage.Login);


            Current.MainWindow = new MainWindow();
            Current.MainWindow.Show();
        }

        private async Task ApplicationSetupAsync()
        {
            new DefaultFrameworkConstruction().UseFileLogger().UseClientDataStore().Build();

            string a = Framework.Configuration.GetSection("ConnectionStrings").Value;

            Container.Setup();


            Container.Kernel.Bind<ILogFactory>().ToConstant(new BaseLogFactory(new[]
            {
                new ChatApp.Core.FileLogger("oldLog.txt"),
            }));

            Container.Kernel.Bind<ITaskManager>().ToConstant(new TaskManager());

            Container.Kernel.Bind<IFileManager>().ToConstant(new FileManager());

            Container.Kernel.Bind<IUIManager>().ToConstant(new UIManager());

            await Container.ClientDataStore.EnsureDataStoreAsync();
        }

        /// <summary>
        /// Override method to release mutex on exit
        /// </summary>
        /// <param name="e"></param>
        protected override void OnExit(ExitEventArgs e)
        {
            if (mutex != null)
                mutex.ReleaseMutex();
            base.OnExit(e);
        }
    }
}
