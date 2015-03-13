/* -------------------------------------------------------------------------------------------------
   Restricted - Copyright (C) Siemens AG/Siemens Medical Solutions USA, Inc., 2015. All rights reserved
   ------------------------------------------------------------------------------------------------- */
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

}
