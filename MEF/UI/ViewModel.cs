/* -------------------------------------------------------------------------------------------------
   Restricted - Copyright (C) Siemens AG/Siemens Medical Solutions USA, Inc., 2015. All rights reserved
   ------------------------------------------------------------------------------------------------- */
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace UI
{
   


    public class DelegateCommand : ICommand
    {
        private Action<object> action;
        private Func<object, bool> canExecute;

        public DelegateCommand(Action<object> action, Func<object, bool> canExecute)
        {
            this.action = action;
            this.canExecute = canExecute;
        }


        public bool CanExecute(object parameter)
        {
            if (canExecute == null)
                return true;

            return canExecute(parameter);
        }

        public void Execute(object parameter)
        {
            action(parameter);
        }

        event EventHandler ICommand.CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
    }

    public class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void RaisePropertyChangedEvent(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }

    public class CalculatorViewModel : ViewModelBase
    {
        private IWorkspaceService workspace;

        public CalculatorViewModel(IWorkspaceService workspaceService)
        {
            Title = "MEF Calculator";
            workspace = workspaceService;
            this.Workspaces = new ObservableCollection<WorkspaceViewModel>(workspaceService.GetWorkspaces());
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
    }


    public abstract class WorkspaceViewModel : ViewModelBase
    {
        protected WorkspaceViewModel()
        {

        }

        private int result;
        public int Result
        {
            get { return result; }
            set
            {
                result = value;
                RaisePropertyChangedEvent("Result");
            }
        }
    }

    public class AddViewModel : WorkspaceViewModel
    {
        private IAddProvider provider;

        public AddViewModel(IAddProvider service)
        {
            provider = service;
            Name = provider.ProviderTitle;

            Add = new DelegateCommand(p =>
            {
                Result = provider.Add(NumberA, NumberB);
            }, p => true);

        }

        private int numberA;
        public int NumberA
        {
            get { return numberA; }
            set
            {
                numberA = value;
                RaisePropertyChangedEvent("NumberA");
            }
        }

        private int numberB;
        public int NumberB
        {
            get { return numberB; }
            set
            {
                numberB = value;
                RaisePropertyChangedEvent("NumberB");
            }
        }

        private string name;
        public string Name
        {
            get { return name; }
            internal set
            {
                name = value;
                RaisePropertyChangedEvent("Name");
            }
        }

        public ICommand Add { get; private set; }
    }
}
