using Microsoft.Win32;
using MVVMUtilities.Abstractions;
using MVVMUtilities.Exceptions;
using System.Linq;

namespace MVVMUtilities.Services
{
    public class OpenFileDialogService : DialogIOService, IFileDialogService<FileOpenAction>
    {
        private FileDialog fileDialog;
        public OpenFileDialogService(string filtername, string extensions) : base(filtername, extensions)
        {
            fileDialog = new OpenFileDialog
            {
                Filter = GetFilter(filtername, extensions)
            };
        }

        public string GetFileName()
        {
            fileDialog.ShowDialog();
            if (string.IsNullOrWhiteSpace(fileDialog.FileName))
            {
                throw new FileNotChooseException();
            }
            return fileDialog.FileName;
        }
    }
}
