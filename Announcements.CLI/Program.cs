using CommandLine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Announcements.CLI
{
    class Program
    {
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
                invokedVerbOptions.Run();
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
