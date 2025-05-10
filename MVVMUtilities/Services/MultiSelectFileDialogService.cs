using Microsoft.Win32;
using MVVMUtilities.Abstractions;
using MVVMUtilities.Exceptions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMUtilities.Services
{
    public class MultiSelectFileDialogService : Abstractions.DialogIOService, IMultiFileDialogService
    {
        private FileDialog fileDialog;
        public MultiSelectFileDialogService(string filtername, string extensions) : base(filtername, extensions)
        {
            fileDialog = new OpenFileDialog
            {
                Filter = GetFilter(filtername, extensions),
                Multiselect = true,
                InitialDirectory = @"C:\Users\User\Downloads"
            };
        }

        public IEnumerable<string> GetFilePaths()
        {
            var result = fileDialog.ShowDialog();
            if (!fileDialog.FileNames.Any() || result == false)
            {
                throw new FileNotChooseException();
            }
            return fileDialog.FileNames;
        }
    }
}
