using Announcements.CLI.IoC;
using Announcements.Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Announcements.CLI
{
    abstract class VerbOptionContract
    {
        public abstract void Run();

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
    }
}
