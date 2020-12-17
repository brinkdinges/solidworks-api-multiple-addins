using System;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using AngelSix.SolidDna.SolidWorks.Integration.AddIn;
using CADBooster.Detached.Logging;

namespace CADBooster.Detached.Addin.SolidWorks
{
    /// <summary>
    /// Register as a SolidWorks addin
    /// </summary>
    [Guid("364E8FD4-D12A-4BFD-8758-BFD781465848"), ComVisible(true)]
    public class DetachedAddin : SolidAddIn
    {
        private static readonly Logger Log = Logger.GetLogger(nameof(DetachedAddin));

        private static string _addinDirectory;

        /// <summary>
        /// Specific application startup code
        /// </summary>
        public override void ApplicationStartup()
        {
            Loggers.StartLogging(new LogFilePath(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Detached-log.txt")));
        }

        /// <summary>
        /// Before connecting to SolidWorks.
        /// </summary>
        public override void PreConnectToSolidWorks()
        {
            UseDetachedAppDomain = true;
            ResolveMissingAssemblies();
        }

        /// <summary>
        /// Here you can load other plugins before the add-in is loaded
        /// </summary>
        public override void PreLoadPlugIns()
        {
        }

        /// <summary>
        /// Resolve assemblies (the dll kind) that can't be found normally.
        /// Not necessary right because because we don't run inside the SolidWorks AppDomain. 
        /// </summary>
        private void ResolveMissingAssemblies()
        {
            if (UseDetachedAppDomain) return;

            _addinDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            if (_addinDirectory == null)
                return;
            AppDomain.CurrentDomain.AssemblyResolve += ResolveMissingAssembly;
        }

        /// <summary>
        /// Called when the missing assembly event is fired.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        private static Assembly ResolveMissingAssembly(object sender, ResolveEventArgs args)
        {
            var assemblyName = new AssemblyName(args.Name);
            if (assemblyName.Name.EndsWith("resources"))
            {
                // This happens 1600 times when starting up, for each possible locale
                // Our translations work even when we return null
                return null;
            }

            var assemblyPath = Path.Combine(_addinDirectory, assemblyName.Name + ".dll");
            return File.Exists(assemblyPath) ? Assembly.LoadFrom(assemblyPath) : null;
        }
    }
}