using Announcements.DbModel.DbModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Announcements.Business.Model
{
    /// <summary>
    /// Data container for announcement message on the billboard.
    /// </summary>
    public class MessageModel
    {
        #region ctor
        public MessageModel()
        { }

        public MessageModel(Announcement dbModel)
        {
            Time = dbModel.Time;
            Message = dbModel.Message;
        }
        #endregion

        /// <summary>
        /// Time at which the announcement is posted on the billboard.
        /// </summary>
        public DateTime Time { get; set; }

        /// <summary>
        /// Content of the announcement message.
        /// </summary>
        public string Message { get; set; }
    }
}
