using MVVMUtilities.Abstractions;
using MVVMUtilities.Enums;
using System.Windows;

namespace MVVMUtilities.Services
{
    public class DialogService : IDialogService
    {
        public void ShowErrorMessage(string message, string caption)
        {
            MessageBox.Show(message, caption, MessageBoxButton.OK, MessageBoxImage.Error);
        }

        public void ShowMessage(string message)
        {
            MessageBox.Show(message);
        }

        public DialogResponce ShowQuestionMessage(string message, string caption)
        {
            var answer = MessageBox.Show(message, caption, MessageBoxButton.YesNo, MessageBoxImage.Question);
            return (answer == MessageBoxResult.Yes) ? DialogResponce.Yes : DialogResponce.No;
        }

        public void ShowWarningMessage(string message, string caption)
        {
            MessageBox.Show(message, caption, MessageBoxButton.OK, MessageBoxImage.Hand);
        }
    }
}
