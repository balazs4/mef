﻿using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UI.Toolkit;

namespace Component.Toolkit
{
    public abstract class WorkspaceViewModel : ViewModelBase
    {
        protected WorkspaceViewModel()
        {

        }

        private int result;
        public int Result
        {
            get { return result; }
            set
            {
                result = value;
                RaisePropertyChangedEvent("Result");
            }
        }
    }
}
