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

            container.RegisterType<IWorkspaceService, WorkspaceService>();
            this.MainWindow.DataContext = container.Resolve<CalculatorViewModel>();

            this.MainWindow.Show();
        }
    }



    public interface IWorkspaceService
    {
        IEnumerable<WorkspaceViewModel> GetWorkspaces();
    }

    public class WorkspaceService : IWorkspaceService
    {
        private readonly IUnityContainer container;

        public WorkspaceService(IUnityContainer container)
        {
            this.container = container;
        }

        public IEnumerable<WorkspaceViewModel> GetWorkspaces()
        {
            return new WorkspaceViewModel[] { container.Resolve<AddViewModel>() }; //TODO: Resolve all extension....
        }
    }

}
