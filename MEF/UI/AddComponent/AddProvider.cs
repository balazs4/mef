﻿/* -------------------------------------------------------------------------------------------------
   Restricted - Copyright (C) Siemens AG/Siemens Medical Solutions USA, Inc., 2015. All rights reserved
   ------------------------------------------------------------------------------------------------- */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI.AddComponent
{
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

        public Type TypeOfIProvider { get { return typeof(IAddProvider); } }
        public Type TypeOfProvider { get { return this.GetType(); } }
    }
}