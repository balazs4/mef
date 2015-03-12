using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

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

            var viewmodel = new AddMainViewModel(new AddProvider()); //Todo: Unity....
            this.MainWindow.DataContext = viewmodel;

            this.MainWindow.Show();
        }
    }
}
