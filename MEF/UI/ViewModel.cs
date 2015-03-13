using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Component.Toolkit;
using UI.Toolkit;

namespace UI
{
    public class CalculatorViewModel : ViewModelBase, INotifyService
    {
        private IWorkspaceService workspace;
        private IDispatcherService dispatcher;

        public CalculatorViewModel(IWorkspaceService workspaceService, IDispatcherService dispatcherService)
        {
            workspace = workspaceService;
            dispatcher = dispatcherService;

            Title = "MEF Calculator";

            notificationQueue = new ConcurrentQueue<Action>();
            this.Notifications = new ObservableCollection<string>();
            Notifications.CollectionChanged += (_, arg) =>
            {
                if (arg.Action == NotifyCollectionChangedAction.Remove)
                {
                    Action action;
                    if (notificationQueue.TryDequeue(out action))
                    {
                        Task.Run(action);
                    }
                }
            };

            this.Workspaces = new ObservableCollection<WorkspaceViewModel>();
        }

        public void Initialize()
        {
            this.Workspaces = new ObservableCollection<WorkspaceViewModel>(workspace.GetWorkspaces());
        }

        private string title;
        public string Title
        {
            get { return title; }
            set
            {
                title = value;
                RaisePropertyChangedEvent("Title");
            }
        }

        private ObservableCollection<WorkspaceViewModel> workspaces;
        public ObservableCollection<WorkspaceViewModel> Workspaces
        {
            get { return workspaces; }
            set
            {
                workspaces = value;
                RaisePropertyChangedEvent("Workspaces");
            }
        }

        private ObservableCollection<string> notifications;
        public ObservableCollection<string> Notifications
        {
            get { return notifications; }
            internal set
            {
                notifications = value;
                RaisePropertyChangedEvent("Notifications");
            }
        }

        private readonly ConcurrentQueue<Action> notificationQueue;

        public void Notify(string text)
        {
            if (Notifications.Count >= 3)
            {
                notificationQueue.Enqueue(() => NotificationManager(text));
                return;
            }

            NotificationManager(text);
        }

        private async void NotificationManager(string text)
        {
            try
            {
                await dispatcher.InvokeAsync(() => Notifications.Add(text));
                await Task.Delay(7000);
                await dispatcher.InvokeAsync(() => Notifications.Remove(text));
            }
            catch (Exception)
            {

            }
        }

    }
}
