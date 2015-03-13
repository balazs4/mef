
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Component.Toolkit;
using UI.Toolkit;

namespace Sub
{
    [Export(typeof(IComponentInterface))]
    public class SubComponent : IComponentInterface
    {
        public KeyValuePair<Type, Type> Provider
        {
            get { return new KeyValuePair<Type, Type>(typeof(ISubProvider), typeof(SubProvider)); }
        }

        public Uri ResourceDictionaryUri
        {
            get { return new Uri("pack://application:,,,/Sub;component/ResourceDictionary.xaml", UriKind.Absolute); }
        }

        public Type Workspace
        {
            get { return typeof(SubWorkspaceViewModel); }
        }
    }

    public interface ISubProvider : IBaseProvider
    {
        int Sub(int a, int b);
    }

    public class SubProvider : ISubProvider
    {
        public int Sub(int a, int b)
        {
            return a - b;
        }

        public string ProviderTitle
        {
            get { return "Sub"; }
        }
    }

    public class SubWorkspaceViewModel : WorkspaceViewModel
    {
        private ISubProvider provider;
        private INotifyService notify;

        public SubWorkspaceViewModel(ISubProvider service, INotifyService notifyService)
        {
            provider = service;
            notify = notifyService;

            Name = provider.ProviderTitle;

            Sub = new DelegateCommand(p =>
                                      {
                                          var result = provider.Sub(NumberA, NumberB);
                                          notify.Notify("Result: " + result);
                                          Result = result;
                                      }, p => true);

            notify.Notify("Init Sub component...");
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

        public ICommand Sub { get; private set; }
    }
}