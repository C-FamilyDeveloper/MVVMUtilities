using Microsoft.Win32;
using MVVMUtilities.Abstractions;
using MVVMUtilities.Exceptions;
using System.Linq;

namespace MVVMUtilities.Services
{
    public class OpenFileDialogService : FileDialogService, IFileDialogService<FileOpenAction>
    {
        private FileDialog fileDialog;
        public OpenFileDialogService(string filtername, string extensions) : base(filtername, extensions)
        {
            fileDialog = new OpenFileDialog
            {
                Filter = GetFilter(filtername, extensions)
            };
        }
        public override string GetFileName()
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
