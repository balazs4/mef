using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.Practices.Unity;
using UI.AddComponent;

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
            container.RegisterType<IWorkspaceService, WorkspaceService>(new InjectionMember[] { new InjectionConstructor(container, compManager.ImportedComponents) });
            
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
        private IEnumerable<IComponentInterface> componentInterfaces;

        public WorkspaceService(IUnityContainer container, IEnumerable<IComponentInterface> components_in)
        {
            this.container = container;
            this.componentInterfaces = components_in;
        }

        public IEnumerable<WorkspaceViewModel> GetWorkspaces()
        {
            List<WorkspaceViewModel> aWorkspaceList= new List<WorkspaceViewModel>();
            foreach (var component in componentInterfaces)
            {
                aWorkspaceList.Add(container.Resolve(component.ViewModel.GetType()) as WorkspaceViewModel);
            }
            return aWorkspaceList.ToArray(); //TODO: Resolve all extension....
        }
    }

}
