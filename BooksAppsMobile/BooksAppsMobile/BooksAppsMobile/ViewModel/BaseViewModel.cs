using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace BooksAppsMobile.ViewModel
{
    /// <summary>
    /// Base ViewModel
    /// </summary>
    public class BaseViewModel : INotifyPropertyChanged
    {
        private bool isBusy = default;
        public bool IsBusy
        {
            get => isBusy;
            set => SetProperty(ref isBusy, value);
        }

        private string title = string.Empty;
        public string Title
        {
            get => title;
            set => SetProperty(ref title, value);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void SetProperty<T>(ref T storedValue, T value, Action onChanged = null, [CallerMemberName] string propName = null)
        {
            if (EqualityComparer<T>.Default.Equals(storedValue, value))
            {
                return;
            }
            storedValue = value;
            onChanged?.Invoke();
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }

    }
}
