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
    public class MessageService : IMessageService
    {
        private BaseRepository _BaseRepository;

        public MessageService(BaseRepository baseRepository)
        {
            _BaseRepository = baseRepository;
        }

        public IEnumerable<MessageModel> GetAnnoucements()
        {
            return _BaseRepository
                .LoadAll<Announcement>()
                .OrderBy(x => x.Time)
                .Select(x => new MessageModel(x))
                .ToArray();
        }

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
