using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Announcements.DbModel.DbModel
{
    /// <summary>
    /// Base class of all entities which logs history of the entity.
    /// </summary>
    public abstract class ChangeEntity : BaseEntity
    {
        /// <summary>
        /// The user that created this entity.
        /// </summary>
        [Required, MaxLength(40)]
        public string CreatedBy { get; set; }

        /// <summary>
        /// The date at which this entity was created.
        /// </summary>
        [Required]
        public DateTime CreatedOn { get; set; }

        /// <summary>
        /// The user that changed this entity.
        /// </summary>
        [Required, MaxLength(40)]
        public string ChangedBy { get; set; }

        /// <summary>
        /// The date at which this entity was changed.
        /// </summary>
        [Required]
        public DateTime ChangedOn { get; set; }
    }
}
