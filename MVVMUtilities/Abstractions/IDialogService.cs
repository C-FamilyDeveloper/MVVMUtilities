using MVVMUtilities.Enums;

namespace MVVMUtilities.Abstractions
{
    public interface IDialogService
    {
        void ShowMessage(string message);
        void ShowErrorMessage(string message, string caption);
        void ShowWarningMessage(string message, string caption);
        DialogResponce ShowQuestionMessage(string message, string caption);
    }
}
