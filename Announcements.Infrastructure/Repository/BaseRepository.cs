using Announcements.DbModel.Context;
using Announcements.DbModel.DbModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Announcements.Infrastructure.Repository
{
    public class BaseRepository
    {
        private AnnouncementsDbContext _DbContext;

        #region ctor
        public BaseRepository(AnnouncementsDbContext dbContext)
        {
            _DbContext = dbContext;
        }
        #endregion

        public T Add<T>(T entity) where T : BaseEntity
        { return _DbContext.Set<T>().Add(entity); }

        public T Create<T>() where T : BaseEntity
        { return _DbContext.Set<T>().Create(); }

        public IEnumerable<T> LoadAll<T>() where T : BaseEntity
        { return _DbContext.Set<T>().ToArray(); }

        public IEnumerable<T> LoadWhere<T>(Expression<Func<T, bool>> predicate) where T : BaseEntity
        { return _DbContext.Set<T>().Where(predicate).ToArray(); }

        public EntityState UpdateEntity<T>(T entity, EntityState state) where T : BaseEntity
        {
            var entry = _DbContext.Entry<T>(entity);
            var oldState = entry.State;
            entry.State = state;
            return oldState;
        }

        public void SaveChanges()
        {
            // TODO: Track DB Changes, analyze DB errors, update ChangeEntity properties
            _DbContext.SaveChanges();
        }
    }
}
