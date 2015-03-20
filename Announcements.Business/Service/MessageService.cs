using Announcements.Business.Contract;
using Announcements.Business.Model;
using Announcements.DbModel.DbModel;
using Announcements.Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Announcements.Business.Service
{
    /// <summary>
    /// Implementation of Message Service, handles announcement messages on the billboard.
    /// </summary>
    public class MessageService : IMessageService
    {
        /// <summary>
        /// Connection to the database.
        /// </summary>
        private BaseRepository _BaseRepository;

        #region ctor
        public MessageService(BaseRepository baseRepository)
        {
            _BaseRepository = baseRepository;
        }
        #endregion

        /// <summary>
        /// Get list of all announcement messages on the billboard.
        /// </summary>
        /// <returns>List of messages ordered by time posted.</returns>
        public IEnumerable<MessageModel> GetAnnoucements()
        {
            return _BaseRepository
                .LoadAll<Announcement>()
                .OrderBy(x => x.Time)
                .Select(x => new MessageModel(x))
                .ToArray();
        }

        /// <summary>
        /// Post a new announcement message on the billboard.
        /// </summary>
        /// <param name="message">The content of the announcement message.</param>
        /// <returns>The announcement as posted on the billboard.</returns>
        public MessageModel PostAnnouncement(string message)
        {
            if (string.IsNullOrWhiteSpace(message))
                throw new ArgumentException("Message required");
            var user = "System";
            var time = DateTime.Now;
            var dbModel = _BaseRepository.Create<Announcement>();
            dbModel.Time = time;
            dbModel.Message = message;
            dbModel.CreatedBy = user;
            dbModel.CreatedOn = time;
            dbModel.ChangedBy = user;
            dbModel.ChangedOn = time;
            _BaseRepository.UpdateEntity(dbModel, EntityState.Added);
            _BaseRepository.SaveChanges();
            return new MessageModel(dbModel);
        }
    }
}
