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
    /// Contains the Main function, this is the starting point of the CLI application.
    /// </summary>
    class Program
    {
        /// <summary>
        /// The starting point of the CLI application.
        /// </summary>
        /// <param name="args">Input arguments from CLI into the application.</param>
        static void Main(string[] args)
        {
            #region Initialize variables
            var options = new Options();
            var parser = Parser.Default;
            var invokedVerb = default(string);
            var invokedVerbOptions = default(VerbOptionContract);
            #endregion
            #region Parse args
            try
            {
                if (!parser.ParseArguments(args, options, (verb, verbOptions) => {
                    invokedVerb = verb;
                    invokedVerbOptions = (VerbOptionContract)verbOptions;
                }))
                    throw new ArgumentException();
            }
            catch (Exception)
            {
                Console.Error.WriteLine(options.GetUsage());
                Environment.Exit(Parser.DefaultExitCodeFail);
            }
            #endregion
            #region Execute
            try
            {
                var sw = Stopwatch.StartNew();
                invokedVerbOptions.Run();
                Console.Out.WriteLine("{0} - {1}", sw.Elapsed, "TOTAL");
            }
            catch (Exception e)
            {
                Console.Error.WriteLine(e.Message);
                Console.Error.WriteLine(e.StackTrace);
                Environment.Exit(-1);
            }
            #endregion
        }
    }
}
