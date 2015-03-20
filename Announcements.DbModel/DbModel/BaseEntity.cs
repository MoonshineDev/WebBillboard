using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Announcements.DbModel.DbModel
{
    /// <summary>
    /// Base class of all entities in the database.
    /// </summary>
    public abstract class BaseEntity
    {
        /// <summary>
        /// Unique identifier of the entity.
        /// </summary>
        [Key]
        public Guid Id { get; set; }

        #region ctor
        public BaseEntity()
        {
            Id = Guid.NewGuid();
        }
        #endregion
    }
}
