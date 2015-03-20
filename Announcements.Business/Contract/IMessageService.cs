using Announcements.Business.Model;
using Announcements.Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Announcements.Business.Contract
{
    public interface IMessageService
    {
        IEnumerable<MessageModel> GetAnnoucements();
        MessageModel PostAnnouncement(string message);
    }
}
