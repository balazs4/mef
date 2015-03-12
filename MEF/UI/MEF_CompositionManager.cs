/* -------------------------------------------------------------------------------------------------
   Restricted - Copyright (C) Siemens AG/Siemens Medical Solutions USA, Inc., 2015. All rights reserved
   ------------------------------------------------------------------------------------------------- */
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.ComponentModel.Design.Serialization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace UI
{
    public class MEF_CompositionManager
    {
        private const string FOLDERNAME = "Components";

        [ImportMany]
        public IEnumerable<IComponentInterface> ImportedComponents;

        public void ComposeParts()
        {
            var assemblyCatalog = new AggregateCatalog();
            assemblyCatalog.Catalogs.Add(new AssemblyCatalog(Assembly.GetExecutingAssembly()));
            if (Directory.Exists(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), FOLDERNAME)))
            {
                assemblyCatalog.Catalogs.Add(new DirectoryCatalog(FOLDERNAME));
            }
            var compositionContainer = new CompositionContainer(assemblyCatalog);
            try
            {
                compositionContainer.ComposeParts(this);
            }
            catch (CompositionException comEx)
            {
                Console.WriteLine(comEx.ToString());
            }
        }

        public void ComposeWithKey()
        {
            var key = Assembly.GetExecutingAssembly().GetName().GetPublicKey();
            var assemblyCatalog = new AggregateCatalog();
            assemblyCatalog.Catalogs.Add(new AssemblyCatalog(Assembly.GetExecutingAssembly()));
            var dir = new DirectoryInfo(FOLDERNAME);
            Assembly assembly;
            foreach (var file in dir.GetFiles("*.dll"))
            {
                assembly = Assembly.Load(file.Name);
                byte[] assemblykey = assembly.GetName().GetPublicKey();

                // custom compare method
                if (key.SequenceEqual(assemblykey))
                {
                    assemblyCatalog.Catalogs.Add(new AssemblyCatalog(assembly));
                }
            }
            var compositionContainer = new CompositionContainer(assemblyCatalog);

            try
            {
                compositionContainer.ComposeParts(this);
            }
            catch (CompositionException comEx)
            {
                Console.WriteLine(comEx.ToString());
            }

        }

    }
}
