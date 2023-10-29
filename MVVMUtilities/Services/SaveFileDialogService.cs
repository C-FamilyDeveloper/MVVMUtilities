using Microsoft.Win32;
using MVVMUtilities.Abstractions;
using MVVMUtilities.Core;
using MVVMUtilities.Exceptions;
using System.Linq;

namespace MVVMUtilities.Services
{
    public class SaveFileDialogService : FileDialogService, IFileDialogService<FileSaveAction>
    {
        public SaveFileDialogService(string filtername, string extensions) : base(filtername, extensions)
        {

        }
        public override string GetFileName()
        {
            FileDialog fileDialog = new SaveFileDialog
            {
                Filter = GetFilter(filtername, extensions)
            };
            fileDialog.ShowDialog();
            if (string.IsNullOrWhiteSpace(fileDialog.FileName))
            {
                throw new FileNotChooseException();
            }
            return fileDialog.FileName;
        }
    }
    
}
