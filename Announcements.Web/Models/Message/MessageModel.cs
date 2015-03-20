using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Announcements.Web.Models
{
    public class MessageModel
    {
        public DateTime Time { get; set; }
        public string Message { get; set; }
    }
}