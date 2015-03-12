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

namespace UI
{
    public interface IComponentInterface
    {
        IBaseProvider IProvider { get; }
        ResourceDictionary Resources { get; }
        UserControl UserControl { get; }

    }
}
