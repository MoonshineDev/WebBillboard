using Announcements.DbModel.DbModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Announcements.DbModel.Context
{
    public class AnnouncementsDbContext : DbContext
    {
        public virtual DbSet<Announcement> Announcements { get; set; }

        public AnnouncementsDbContext()
            : base("name=AnnouncementsDb")
        {
        }
    }
}
