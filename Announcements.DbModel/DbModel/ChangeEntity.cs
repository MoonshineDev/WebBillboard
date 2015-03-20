using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Announcements.DbModel.DbModel
{
    public class ChangeEntity : BaseEntity
    {
        [Required, MaxLength(40)]
        public string CreatedBy { get; set; }
        [Required]
        public DateTime CreatedOn { get; set; }
        [Required, MaxLength(40)]
        public string ChangedBy { get; set; }
        [Required]
        public DateTime ChangedOn { get; set; }
    }
}
