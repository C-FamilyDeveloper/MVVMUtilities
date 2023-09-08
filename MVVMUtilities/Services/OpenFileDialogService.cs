using Microsoft.Win32;
using MVVMUtilities.Abstractions;
using MVVMUtilities.Exceptions;
using System.Linq;

namespace MVVMUtilities.Services
{
    public class OpenFileDialogService : IFileDialogService<FileOpenAction>
    {
        private FileDialog fileDialog;
        public OpenFileDialogService(string filtername, string extensions)
        {
            if (extensions.Split(" ").Any())
            {
                extensions = string.Join(";", extensions.Split(" "));
            }
            fileDialog = new OpenFileDialog
            {
                Filter = filtername + @"|" + extensions
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
