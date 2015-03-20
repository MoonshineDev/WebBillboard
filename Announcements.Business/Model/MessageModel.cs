using Announcements.DbModel.DbModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Announcements.Business.Model
{
    public class MessageModel
    {
        public MessageModel()
        { }

        public MessageModel(Announcement dbModel)
        {
            Time = dbModel.Time;
            Message = dbModel.Message;
        }

        public DateTime Time { get; set; }
        public string Message { get; set; }
    }
}
