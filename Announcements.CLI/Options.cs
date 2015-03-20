using CommandLine;
using CommandLine.Text;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Announcements.CLI
{
    class Options
    {
        [VerbOption("Post", HelpText="Post an announcement on the billboard")]
        public VerbOptionPost Post { get; set; }

        [HelpOption]
        public string GetUsage()
        { return HelpText.AutoBuild(this, current => HelpText.DefaultParsingErrorsHandler(this, current)); }
    }
}
