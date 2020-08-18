using ChatApp.Core.DataModels;
using Cornerstone;
using Ninject;
using System;

namespace ChatApp.Core
{
    //IoC container
    public class Container
    {

        public static IKernel Kernel { get; private set; } = new StandardKernel();

        public static IUIManager UI => Container.Get<IUIManager>();

        public static SettingsViewModel Settings => Container.Get<SettingsViewModel>();

        public static ApplicationViewModel Application => Container.Get<ApplicationViewModel>();

        public static ILogFactory Logger => Container.Get<ILogFactory>();

        public static IFileManager File => Container.Get<IFileManager>();

        public static ITaskManager Task => Container.Get<ITaskManager>();

        public static IClientDataStore ClientDataStore => Framework.Service<IClientDataStore>();

        public static void Setup()
        {
            BindViewModels();
        }

        private static void BindViewModels()
        {
            Kernel.Bind<ApplicationViewModel>().ToConstant(new ApplicationViewModel());
            Kernel.Bind<SettingsViewModel> ().ToConstant(new SettingsViewModel());

        }

        public static T Get<T>()
        {
            return Kernel.Get<T>();
        }
    }
}
