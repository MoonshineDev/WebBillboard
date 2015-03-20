using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Announcements.Web.Models
{
    /// <summary>
    /// View model of an announcement message on the billboard.
    /// </summary>
    public class MessageViewModel
    {
        /// <summary>
        /// Time at which the announcement message on the billboard.
        /// </summary>
        public DateTime Time { get; set; }

        /// <summary>
        /// Content of the announcement message on the billboard.
        /// </summary>
        public string Message { get; set; }
    }
}