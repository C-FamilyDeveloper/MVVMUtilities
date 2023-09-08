using MVVMUtilities.Core;
using System;

namespace MVVMUtilities.Abstractions
{
    public interface INavigationService
    {
        public T GetDataContext<T>() where T : BaseViewModel;
        public void Hide<T>() where T : BaseViewModel;
        public void Show<T>() where T : BaseViewModel;
        public void Show<T>(Action<T> setter) where T : BaseViewModel;
        public bool? ShowDialog<T>() where T : BaseViewModel;
        public bool? ShowDialog<T>(Action<T> setter) where T : BaseViewModel;
        public void Close<T>() where T : BaseViewModel;
        //public void Initialize(IServiceProvider serviceProvider);
        //public void SetDataContext<T>(Action<T> setter) where T : BaseViewModel;
    }
}
