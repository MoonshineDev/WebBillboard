using Announcements.Business.Contract;
using Announcements.Business.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Announcements.Business.Service
{
    public class MessageService : IMessageService
    {
        public IEnumerable<MessageModel> GetAnnoucements()
        {
            var list = new List<MessageModel>();
            list.Add(new MessageModel {
                Time = DateTime.Now,
                Message = "Hello World",
            });
            return list;
        }
    }
}
