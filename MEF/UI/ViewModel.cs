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
using Component.Toolkit;
using UI.Toolkit;

namespace UI
{
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
}
