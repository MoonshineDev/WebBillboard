using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Announcements.DbModel.DbModel
{
    [Table("Announcement")]
    public class Announcement : ChangeEntity
    {
        [Required]
        public DateTime Time { get; set; }
        [Required]
        public string Message { get; set; }
    }
}
