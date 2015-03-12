/* -------------------------------------------------------------------------------------------------
   Restricted - Copyright (C) Siemens AG/Siemens Medical Solutions USA, Inc., 2015. All rights reserved
   ------------------------------------------------------------------------------------------------- */
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI
{
    [Export(typeof(IComponentInterface))]
    public class ComponentInsideAssembly : IComponentInterface
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

        public MainViewModel ViewModel
        {
            get { throw new NotImplementedException(); }
        }
    }
}
