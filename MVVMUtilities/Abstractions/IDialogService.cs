using MVVMUtilities.Enums;

namespace MVVMUtilities.Abstractions
{
    public interface IDialogService
    {
        public void ShowMessage(string message);
        public void ShowErrorMessage(string message, string caption);
        public void ShowWarningMessage(string message, string caption);
        public DialogResponce ShowQuestionMessage(string message, string caption);
    }
}
