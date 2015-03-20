using StructureMap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Announcements.Web.IoC
{
    public class MyContainer
    {
        private static MyContainer _Instance;
        public static MyContainer Instance { get {
            if (_Instance == null)
                _Instance = new MyContainer();
            return _Instance;
        } }

        public IContainer _Container { get; private set; }

        #region .ctor
        public MyContainer()
        {
            _Container = new Container(config => {
                config.AddRegistry(new IoCRegistry());
            });
        }
        #endregion

        public static T GetInstance<T>()
        {
            return Instance._Container.GetInstance<T>();
        }
    }
}