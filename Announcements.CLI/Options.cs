using CommandLine;
using CommandLine.Text;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Announcements.CLI
{
    /// <summary>
    /// CLI verb options
    /// </summary>
    class Options
    {
        /// <summary>
        /// Post verb handles post of new announcements.
        /// </summary>
        [VerbOption("Post", HelpText="Post an announcement on the billboard")]
        public VerbOptionPost Post { get; set; }

        /// <summary>
        /// Constructs usage string based on verbs and options.
        /// </summary>
        /// <returns>Usage string.</returns>
        [HelpOption]
        public string GetUsage()
        { return HelpText.AutoBuild(this, current => HelpText.DefaultParsingErrorsHandler(this, current)); }
    }
}
