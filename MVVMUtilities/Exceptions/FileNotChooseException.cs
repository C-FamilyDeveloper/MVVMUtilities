using System;

namespace MVVMUtilities.Exceptions
{
    public class FileNotChooseException : Exception
    {
        public override string Message => "Файл не выбран";
    }
}
