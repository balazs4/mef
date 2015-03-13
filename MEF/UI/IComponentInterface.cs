/* -------------------------------------------------------------------------------------------------
   Restricted - Copyright (C) Siemens AG/Siemens Medical Solutions USA, Inc., 2015. All rights reserved
   ------------------------------------------------------------------------------------------------- */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using UI.AddComponent;

namespace UI
{

    public interface IComponentInterface
    {
        KeyValuePair<Type, Type> Provider { get; }

        Type Workspace { get; }

        Uri ResourceDictionaryUri { get; }
        
    }
}
