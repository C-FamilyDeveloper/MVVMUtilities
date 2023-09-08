
namespace MVVMUtilities.Abstractions
{
    public interface IFileDialogService<T> where T : FileAction
    {
        public string GetFileName();
    }
}
