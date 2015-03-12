﻿/* -------------------------------------------------------------------------------------------------
   Restricted - Copyright (C) Siemens AG/Siemens Medical Solutions USA, Inc., 2015. All rights reserved
   ------------------------------------------------------------------------------------------------- */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace UI
{
    public interface IBaseProvider
    {
        int DoWork();
    }


    public interface IAddProvider
    {
        int Add(int a, int b);
    }


    public class AddProvider : IAddProvider
    {
        public int Add(int a, int b)
        {
            return a + b;
        }
    }

}