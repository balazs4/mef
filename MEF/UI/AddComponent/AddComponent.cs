/* -------------------------------------------------------------------------------------------------
   Restricted - Copyright (C) Siemens AG/Siemens Medical Solutions USA, Inc., 2015. All rights reserved
   ------------------------------------------------------------------------------------------------- */
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace UI.AddComponent
{
    [Export(typeof(IComponentInterface))]
    public class AddComponent : IComponentInterface
    {
        public KeyValuePair<Type, Type> Provider
        {
            get { return new KeyValuePair<Type, Type>(typeof(IAddProvider), typeof(AddProvider)); }
        }

        public Uri ResourceDictionaryUri
        {
            get { return new Uri("AddComponent/AddResourceDictionary.xaml", UriKind.Relative); }
        }

        public Type Workspace
        {
            get { return typeof(AddWorkspacesViewModel); }
        }
    }
}
