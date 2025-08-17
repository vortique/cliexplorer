using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLIExplorer
{
    public interface ICommand
    {
        protected static string CommandPrefix { get; }
        public bool Run(string path);
    }
}
