using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMUtilities.Abstractions
{
    public abstract class FileDialogService
    {
        protected string filtername;
        protected string extensions;
        protected FileDialogService(string filtername, string extensions)
        {
            this.filtername = filtername;
            this.extensions = extensions;
        }
        protected string GetFilter(string filtername, string extensions)
        {
            if (extensions.Split(" ").Any())
            {
                extensions = string.Join(";", extensions.Split(" "));
            }
            return filtername + @"|" + extensions;
        }
        public abstract string GetFileName();
    }
}
