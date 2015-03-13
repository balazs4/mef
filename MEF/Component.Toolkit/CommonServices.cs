using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Component.Toolkit
{
    public interface IWorkspaceService
    {
        IEnumerable<WorkspaceViewModel> GetWorkspaces();
    }

    public interface INotifyService
    {
        void Notify(string text);
    }

    public interface IDispatcherService
    {
        void Invoke(Action action);

        Task InvokeAsync(Action action);
    }
}
