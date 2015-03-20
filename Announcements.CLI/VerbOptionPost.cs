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
    /// <summary>
    /// Post verb option, lets the user to post new announcements on the billboard.
    /// </summary>
    class VerbOptionPost : VerbOptionContract
    {
        /// <summary>
        /// Message to be posted on the billboard.
        /// </summary>
        [Option('m', "Message", HelpText = "The message to post on the billboard")]
        public string Message { get; set; }

        /// <summary>
        /// Execute the verb option, ask the Business layer to post a new announcement on the billboard.
        /// </summary>
        public override void Run()
        {
            var swStream = Console.Out;
            var messageService = default(IMessageService);
            var model = default(MessageModel);
            Message = AssertString(Message, x => !string.IsNullOrWhiteSpace(x), "Type a message: ");
            PerformStep(swStream, "Resolve implementation of service.", () => {
                messageService = MyContainer.GetInstance<IMessageService>();
            });
            PerformStep(swStream, "Build and post announcement on billboard.", () => {
                model = messageService.PostAnnouncement(Message);
            });
        }
    }
}
