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
    // Würde sowas mit dem MEF machbar?? Es wäre super...
    // Das wäre dann unser Component manifest...
    public interface IComponentInterface<TProviderInterface, TProviderClass, TWorkspace>
        where TProviderInterface : IBaseProvider
        where TProviderClass : TProviderInterface
        where TWorkspace : WorkspaceViewModel
    {
        KeyValuePair<TProviderInterface, TProviderClass> Provider { get; }

        TWorkspace Workspace { get; }
    }


    public interface IComponentInterface
    {
        KeyValuePair<Type, Type> Provider { get; }

        Type Workspace { get; }

        ResourceDictionary Resources { get; }

        UserControl UserControl { get; }
        
    }
}
