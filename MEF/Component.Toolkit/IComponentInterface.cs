using System;
using System.Collections.Generic;

namespace Component.Toolkit
{
    public interface IComponentInterface
    {
        KeyValuePair<Type, Type> Provider { get; }

        Type Workspace { get; }

        Uri ResourceDictionaryUri { get; }

    }

    // TODO: Move to Provider Assembly
    public interface IBaseProvider
    {
        string ProviderTitle { get; }
    }

}