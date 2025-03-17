using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMUtilities.Abstractions
{
    public interface IMultiFileDialogService
    {
        IEnumerable<string> GetFilePaths();
    }
}
