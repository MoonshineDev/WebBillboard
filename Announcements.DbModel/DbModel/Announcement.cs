using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Announcements.DbModel.DbModel
{
    /// <summary>
    /// Entity of announcement messages on the billboard.
    /// </summary>
    [Table("Announcement")]
    public class Announcement : ChangeEntity
    {
        /// <summary>
        /// Time at which the announcement was posted on the billboard.
        /// </summary>
        [Required]
        public DateTime Time { get; set; }

        /// <summary>
        /// Content of the announcement message.
        /// </summary>
        [Required]
        public string Message { get; set; }
    }
}
