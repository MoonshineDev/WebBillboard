using Announcements.Business.Contract;
using Announcements.Business.Model;
using Announcements.CLI.IoC;
using Announcements.Infrastructure.Repository;
using CommandLine;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Announcements.CLI
{
    class VerbOptionPost : VerbOptionContract
    {
        [Option('m', "Message", HelpText = "The message to post on the billboard")]
        public string Message { get; set; }

        public override void Run()
        {
            Message = AssertString(Message, x => !string.IsNullOrWhiteSpace(x), "Type a message:");
            var messageService = MyContainer.GetInstance<IMessageService>();
            var model = messageService.PostAnnouncement(Message);
        }
    }
}
