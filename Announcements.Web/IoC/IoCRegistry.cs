using Announcements.Business.Contract;
using Announcements.Business.Service;
using StructureMap.Configuration.DSL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Announcements.Web.IoC
{
    public class IoCRegistry : Registry
    {
        #region .ctor
        public IoCRegistry()
        {
            For<IMessageService>().Use<MessageService>();
        }
        #endregion
    }
}