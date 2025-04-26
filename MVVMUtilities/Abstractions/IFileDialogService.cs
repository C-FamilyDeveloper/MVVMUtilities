
namespace MVVMUtilities.Abstractions
{
    public interface IFileDialogService<T> where T : FileAction
    {
        string GetFileName();
    }
}
