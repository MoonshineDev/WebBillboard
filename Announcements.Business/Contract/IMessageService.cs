using Announcements.Business.Model;
using Announcements.Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Announcements.Business.Contract
{
    /// <summary>
    /// Interface for MessageService, handles announcement messages on the billboard.
    /// </summary>
    public interface IMessageService
    {
        /// <summary>
        /// Get list of all announcement messages on the billboard.
        /// </summary>
        /// <returns>List of messages ordered by time posted.</returns>
        IEnumerable<MessageModel> GetAnnoucements();

        /// <summary>
        /// Post a new announcement message on the billboard.
        /// </summary>
        /// <param name="message">The content of the announcement message.</param>
        /// <returns>The announcement as posted on the billboard.</returns>
        MessageModel PostAnnouncement(string message);
    }
}
