using MVVMUtilities.Abstractions;
using System.Threading;

namespace MVVMUtilities.Services
{
    public class CheckInstanceService : ICheckInstanceService
    {
        private Mutex syncObject;
        private const string syncObjectName = "{E73F-AE0D-480E-9FCA-4BE9-B8CD-VB98}";
        public bool IsOneApplicationInstance()
        {
            syncObject = new(true, syncObjectName, out bool createdNew);
            return createdNew;
        }
    }
}
