using MVVMUtilities.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MVVMUtilities.Abstractions
{
    public interface IDispatcherable
    {
        void ExecuteWithDispatcher<T> (Action action) where T : BaseViewModel;
    }
}
