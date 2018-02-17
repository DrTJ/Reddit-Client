using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace RedditClient.ViewModels
{
    public class ObservableModel : INotifyPropertyChanged
    {
        #region events

        /// <summary>
        /// Occurs every time a bindeable property changes.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #region Methods

        protected virtual void OnPropertyChange([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected bool SetProperty<T>(ref T property, T value, [CallerMemberName] string propertyName = null)
        {
            if (object.Equals(property, value))
            {
                return false;
            }

            property = value;
            OnPropertyChange(propertyName);

            return true;
        }

        #endregion
    }
}
