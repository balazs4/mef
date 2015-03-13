/* -------------------------------------------------------------------------------------------------
   Restricted - Copyright (C) Siemens AG/Siemens Medical Solutions USA, Inc., 2015. All rights reserved
   ------------------------------------------------------------------------------------------------- */
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI.AddComponent
{
    [Export(typeof(IComponentInterface))]
    public class AddComponent : IComponentInterface
    {
        public IBaseProvider IProvider
        {
            get { return new AddProvider(); }
        }

        public System.Windows.ResourceDictionary Resources
        {
            get { throw new NotImplementedException(); }
        }

        public System.Windows.Controls.UserControl UserControl
        {
            get { throw new NotImplementedException(); }
        }

        public WorkspaceViewModel ViewModel
        {
            get { return new AddViewModel(IProvider as AddProvider); }
        }
    }
}
