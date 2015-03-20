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
    /// <summary>
    /// Repository which communicates with the billboard database.
    /// </summary>
    public class BaseRepository
    {
        /// <summary>
        /// Database context for the billboard database.
        /// </summary>
        private AnnouncementsDbContext _DbContext;

        #region ctor
        public BaseRepository(AnnouncementsDbContext dbContext)
        {
            _DbContext = dbContext;
        }
        #endregion

        /// <summary>
        /// Add a local entity to the database.
        /// </summary>
        /// <typeparam name="T">The type of the entity.</typeparam>
        /// <param name="entity">The entity itself.</param>
        /// <returns>The entity which was added.</returns>
        public T Add<T>(T entity) where T : BaseEntity
        {
            if (entity == null)
                throw new ArgumentNullException("Entity required.");
            return _DbContext.Set<T>().Add(entity);
        }

        /// <summary>
        /// Create a entity on the database.
        /// </summary>
        /// <typeparam name="T">The type of the entity.</typeparam>
        /// <returns>THe entity which was created.</returns>
        public T Create<T>() where T : BaseEntity
        { return _DbContext.Set<T>().Create(); }

        /// <summary>
        /// Load all entities into memory.
        /// </summary>
        /// <typeparam name="T">The type of the entity.</typeparam>
        /// <returns>A complete list of entities.</returns>
        public T[] LoadAll<T>() where T : BaseEntity
        { return _DbContext.Set<T>().ToArray(); }

        /// <summary>
        /// Load all matching entities into memory.
        /// </summary>
        /// <typeparam name="T">The type of the entity.</typeparam>
        /// <param name="predicate">Only return entities which match this predicate.</param>
        /// <returns>A complete list of matching entities.</returns>
        public IEnumerable<T> LoadWhere<T>(Expression<Func<T, bool>> predicate) where T : BaseEntity
        {
            if (predicate == null)
                throw new ArgumentNullException("Predicate required.");
            return _DbContext.Set<T>().Where(predicate).ToArray();
        }

        /// <summary>
        /// Update the entry state within Entity Framework of the given entity.
        /// </summary>
        /// <typeparam name="T">The type of the entity.</typeparam>
        /// <param name="entity">The entity which is referred to.</param>
        /// <param name="state">The new entry state of the entity.</param>
        /// <returns>The old entry state of the entity.</returns>
        public EntityState UpdateEntity<T>(T entity, EntityState state) where T : BaseEntity
        {
            if (entity == null)
                throw new ArgumentNullException("Entity required.");
            var entry = _DbContext.Entry<T>(entity);
            var oldState = entry.State;
            entry.State = state;
            return oldState;
        }

        /// <summary>
        /// Update database with the eventual changes in the local entities.
        /// </summary>
        public void SaveChanges()
        {
            try
            {
                // TODO: Track DB Changes, analyze DB errors, update ChangeEntity properties
                _DbContext.SaveChanges();
            }
            catch (Exception e)
            {
                throw;
            }
        }
    }
}
