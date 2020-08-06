using ChatApp.Core.DataModels;
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
