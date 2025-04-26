using MVVMUtilities.Core;
using System;

namespace MVVMUtilities.Abstractions
{
    public interface INavigationService : IDispatcherable
    {
        T GetDataContext<T>() where T : BaseViewModel;
        void Hide<T>() where T : BaseViewModel;
        void Show<T>() where T : BaseViewModel;
        void Show<T>(Action<T> setter) where T : BaseViewModel;
        bool? ShowDialog<T>() where T : BaseViewModel;
        bool? ShowDialog<T>(Action<T> setter) where T : BaseViewModel;
        void Close<T>() where T : BaseViewModel;
    }
}
