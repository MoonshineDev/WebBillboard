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
    public class IoCRegistry : Registry
    {
        private AnnouncementsDbContext _AnnouncementsDbContext;
        private AnnouncementsDbContext AnnouncementsDbContext { get {
            if (_AnnouncementsDbContext == null)
                _AnnouncementsDbContext = new AnnouncementsDbContext();
            return _AnnouncementsDbContext;
        } }

        #region .ctor
        public IoCRegistry()
        {
            For<IMessageService>().Use<MessageService>();
            For<DbContext>().Use<AnnouncementsDbContext>(AnnouncementsDbContext);
        }
        #endregion
    }
}