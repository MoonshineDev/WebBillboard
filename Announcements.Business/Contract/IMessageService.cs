using Announcements.Business.Model;
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
    }
}
