/* -------------------------------------------------------------------------------------------------
   Restricted - Copyright (C) Siemens AG/Siemens Medical Solutions USA, Inc., 2015. All rights reserved
   ------------------------------------------------------------------------------------------------- */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.Composition;
using System.Windows.Input;
using Component.Toolkit;
using UI.Toolkit;

namespace Add
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
            get { return new Uri("pack://application:,,,/Add;component/ResourceDictionary.xaml", UriKind.Absolute); }
        }

        public Type Workspace
        {
            get { return typeof(AddWorkspacesViewModel); }
        }
    }

    public interface IAddProvider : IBaseProvider
    {
        int Add(int a, int b);
    }

    public class AddProvider : IAddProvider
    {
        public int Add(int a, int b)
        {
            return a + b;
        }

        public string ProviderTitle { get { return "Add"; } }
    }

    public class AddWorkspacesViewModel : WorkspaceViewModel
    {
        private IAddProvider provider;

        public AddWorkspacesViewModel(IAddProvider service)
        {
            provider = service;
            Name = provider.ProviderTitle;

            Add = new DelegateCommand(p =>
            {
                Result = provider.Add(NumberA, NumberB);
            }, p => true);

        }

        private int numberA;
        public int NumberA
        {
            get { return numberA; }
            set
            {
                numberA = value;
                RaisePropertyChangedEvent("NumberA");
            }
        }

        private int numberB;
        public int NumberB
        {
            get { return numberB; }
            set
            {
                numberB = value;
                RaisePropertyChangedEvent("NumberB");
            }
        }

        private string name;
        public string Name
        {
            get { return name; }
            internal set
            {
                name = value;
                RaisePropertyChangedEvent("Name");
            }
        }

        public ICommand Add { get; private set; }
    }
}
