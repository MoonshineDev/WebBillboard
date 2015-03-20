using Announcements.DbModel.DbModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Announcements.DbModel.Context
{
    /// <summary>
    /// Code first database context of the billboard.
    /// </summary>
    public class AnnouncementsDbContext : DbContext
    {
        public virtual DbSet<Announcement> Announcements { get; set; }

        #region ctor
        public AnnouncementsDbContext()
            : base("name=AnnouncementsDb")
        {
        }
        #endregion
    }
}
