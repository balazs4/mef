/* -------------------------------------------------------------------------------------------------
   Restricted - Copyright (C) Siemens AG/Siemens Medical Solutions USA, Inc., 2015. All rights reserved
   ------------------------------------------------------------------------------------------------- */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace UI.Toolkit
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
}
