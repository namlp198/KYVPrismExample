using Prism.Unity;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Prism.Modularity;
using KYV.EA.Input;
using KYV.EA.Output1;
using KYV.EA.Output2;

namespace KYV.EASampleApp
{
    internal class Bootstrapper : UnityBootstrapper
    {
        protected override DependencyObject CreateShell()
        {
            return this.Container.Resolve<Shell>();
        }

        protected override void InitializeShell()
        {
            ((Window)this.Shell).Show();
        }

        protected override void ConfigureModuleCatalog()
        {
            base.ConfigureModuleCatalog();
            var c = (ModuleCatalog)this.ModuleCatalog;
            c.AddModule(typeof(InputModule));
            c.AddModule(typeof(Output1Module));
            c.AddModule(typeof(Output2Module));
        }
    }
}