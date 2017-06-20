using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Prism.Modularity;
using Prism.Unity;
using Meetings;
using Participants;

namespace Shell
{
    public class BootStrapper : UnityBootstrapper
    {
        protected override DependencyObject CreateShell()
        {
            return Container.TryResolve<ShellView>();
        }

        protected override void InitializeShell()
        {
            base.InitializeShell();
            App.Current.MainWindow = (Window)Shell;
            App.Current.MainWindow.Show();
        }

        protected override void ConfigureModuleCatalog()
        {
            base.ConfigureModuleCatalog();
            RegisterModule(typeof(ParticipantsModule));
        }

        private void RegisterModule(Type moduleType)
        {
            ModuleCatalog.AddModule(new ModuleInfo() { ModuleName = moduleType.Name, ModuleType = moduleType.AssemblyQualifiedName });
        }
    }
}
