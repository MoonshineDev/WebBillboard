using Announcements.CLI.IoC;
using Announcements.Infrastructure.Repository;
using CommandLine;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Announcements.CLI
{
    /// <summary>
    /// Base class for all verb options.
    /// </summary>
    abstract class VerbOptionContract
    {
        /// <summary>
        /// Stopwatch and other verbose information will be shown if enabled.
        /// </summary>
        [Option('v', "Verbose", DefaultValue=false, HelpText="By enabling this option the application will be more verbose.")]
        public bool Verbose { get; set; }

        /// <summary>
        /// Call this method to execute the verb option.
        /// </summary>
        public abstract void Run();

        /// <summary>
        /// Validate str and ask user for new input.
        /// </summary>
        /// <param name="str">Input string to be validated.</param>
        /// <param name="predicate">Validation method, returns true if input is satisfactory.</param>
        /// <param name="message">Message to show the user upon input request.</param>
        /// <returns>Accepted input string.</returns>
        public string AssertString(string str, Func<string, bool> predicate, string message)
        {
            if (predicate(str))
                return str;
            Console.Write(message);
            str = Console.ReadLine();
            if (!predicate(str))
                throw new ArgumentException();
            return str;
        }

        /// <summary>
        /// Shows timer and stepname if application is verbose.
        /// </summary>
        /// <param name="swStream">Stream that should print stopwatch information.</param>
        /// <param name="name">Name of step.</param>
        /// <param name="action">Action of step.</param>
        protected void PerformStep(TextWriter swStream, string name, Action action)
        {
            if (Verbose)
            {
                var sw = Stopwatch.StartNew();
                swStream.Write("{0}..", name);
                try
                {
                    action();
                    swStream.WriteLine("\r{0} - {1} [OK]", sw.Elapsed, name);
                }
                catch (Exception)
                {
                    swStream.WriteLine("\r{0} - {1} [FAIL]", sw.Elapsed, name);
                    throw;
                }
                finally
                {
                    swStream.Flush();
                }
            }
            else
                action();
        }
    }
}
