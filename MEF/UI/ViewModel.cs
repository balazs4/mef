/* -------------------------------------------------------------------------------------------------
   Restricted - Copyright (C) Siemens AG/Siemens Medical Solutions USA, Inc., 2015. All rights reserved
   ------------------------------------------------------------------------------------------------- */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace UI
{
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

    public abstract class MainViewModel : ViewModelBase
    {
        protected MainViewModel()
        {
            
        }

        private int result;
        public int Result
        {
            get { return result; }
            internal set
            {
                result = value;
                RaisePropertyChangedEvent("Result");
            }
        }
    }

    public class AddMainViewModel : MainViewModel
    {
        private IAddProvider provider;

        public AddMainViewModel(IAddProvider service)
        {
            provider = service;
        }
    }
}
