using StructureMap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Announcements.Web.IoC
{
    /// <summary>
    /// Dependency Injection, configuration of structuremap container.
    /// </summary>
    public class MyContainer
    {
        #region singleton
        private static MyContainer _Instance;
        public static MyContainer Instance { get {
            if (_Instance == null)
                _Instance = new MyContainer();
            return _Instance;
        } }
        #endregion

        public IContainer _Container { get; private set; }

        #region .ctor
        public MyContainer()
        {
            // Configure the container, assemblies it should scan, interfaces, dependencies etc.
            _Container = new Container(config => {
                config.AddRegistry(new IoCRegistry());
            });
        }
        #endregion

        /// <summary>
        /// Get the implementation of a specified inferface. Alternatively build a instance based on dependencies.
        /// </summary>
        /// <typeparam name="T">Type of the requested implementation.</typeparam>
        /// <returns>An implementation of T.</returns>
        public static T GetInstance<T>()
        { return Instance._Container.GetInstance<T>(); }
    }
}