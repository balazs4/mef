using System;
using System.Collections.Generic;
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

            var container = new UnityContainer();
            container.RegisterType<IAddProvider, AddProvider>();


            this.MainWindow.DataContext = container.Resolve<CalculatorViewModel>();

            this.MainWindow.Show();
        }
    }
}
