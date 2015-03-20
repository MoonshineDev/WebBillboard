using Announcements.Business.Contract;
using Announcements.Business.Service;
using Announcements.DbModel.Context;
using StructureMap.Configuration.DSL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Announcements.CLI.IoC
{
    /// <summary>
    /// Here the interfaces are interpreted into actual implementations.
    /// </summary>
    public class IoCRegistry : Registry
    {
        #region Singletons
        private AnnouncementsDbContext _AnnouncementsDbContext;
        private AnnouncementsDbContext AnnouncementsDbContext { get {
            if (_AnnouncementsDbContext == null)
                _AnnouncementsDbContext = new AnnouncementsDbContext();
            return _AnnouncementsDbContext;
        } }
        #endregion

        #region .ctor
        public IoCRegistry()
        {
            For<IMessageService>().Use<MessageService>();
            // TODO: Fix singleton, there is a better implementation of this.
            For<DbContext>().Use<AnnouncementsDbContext>(AnnouncementsDbContext);
        }
        #endregion
    }
}