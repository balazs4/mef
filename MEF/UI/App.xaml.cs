using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.Practices.Unity;

namespace UI
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            this.MainWindow = new MainWindow();
            var compManager = new MEF_CompositionManager();
            compManager.ComposeParts();
            var container = new UnityContainer();
            foreach (var component in compManager.ImportedComponents)
            {
                container.RegisterType(component.IProvider.TypeOfIProvider, component.IProvider.TypeOfProvider);
            }
            

            this.MainWindow.DataContext = container.Resolve<AddViewModel>();

            this.MainWindow.Show();
        }
    }
}
