using Microsoft.Extensions.DependencyInjection;
using MVVMUtilities.Abstractions;
using MVVMUtilities.Core;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows;

namespace MVVMUtilities.Services
{
    public class NavigationService : INavigationService, IDispatcherable
    {
        private Dictionary<Type, Window> windowsioc = new();
        private IServiceProvider serviceProvider;

        public NavigationService(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        public void ConfigureWindow<T, U>() where T : BaseViewModel where U : Window, new()
        {          
            if (!windowsioc.ContainsKey(typeof(T)))
            {
                windowsioc.Add(typeof(T), new U());
            }
        }

        private Window GetWindow<T>() where T : BaseViewModel
        {
            var window = windowsioc[typeof(T)];
            var isLoaded = window.Dispatcher.Invoke(() => window.IsLoaded);
            if (!isLoaded)
            {
                var type = windowsioc[typeof(T)].GetType();
                windowsioc[typeof(T)] = (Window)Activator.CreateInstance(type)!;
                return windowsioc[typeof(T)];
            }
            return window;
        }

        public T GetDataContext<T>() where T : BaseViewModel
        {
            var window = GetWindow<T>();
            return (T)window.DataContext;
        }

        public void Hide<T>() where T : BaseViewModel
        {
            var window = GetWindow<T>();
            window.Hide();
        }

        public void Show<T>() where T : BaseViewModel
        {
            var window = GetWindow<T>();
            window.DataContext = ActivatorUtilities.CreateInstance<T>(serviceProvider);
            window.Show();
        }

        public void Show<T>(Action<T> setter) where T : BaseViewModel
        {
            var window = GetWindow<T>();
            var vm = ActivatorUtilities.CreateInstance<T>(serviceProvider);
            setter(vm);
            window.DataContext = vm;
            window.Show();
        }

        public bool? ShowDialog<T>() where T : BaseViewModel
        {
            var window = GetWindow<T>();
            window.DataContext = ActivatorUtilities.CreateInstance<T>(serviceProvider);
            return window.ShowDialog();
        }

        public bool? ShowDialog<T>(Action<T> setter) where T : BaseViewModel
        {
            var window = GetWindow<T>();
            var vm = ActivatorUtilities.CreateInstance<T>(serviceProvider);
            setter(vm);
            window.DataContext = vm;
            return window.ShowDialog();
        }

        public void Close<T>() where T : BaseViewModel
        {
            var window = GetWindow<T>();
            window.Close();
        }

        public void ExecuteWithDispatcher<T>(Action action) where T : BaseViewModel
        {
            var window = GetWindow<T>();
            window.Dispatcher.Invoke(action);
        }
    }
}
