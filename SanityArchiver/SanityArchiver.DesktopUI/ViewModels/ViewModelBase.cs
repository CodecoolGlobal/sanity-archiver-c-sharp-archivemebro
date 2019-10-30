using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace SanityArchiver.DesktopUI.ViewModels
{
    /// <summary>
    /// Inherit viewmodel classes from here.
    /// </summary>
    public abstract class ViewModelBase : INotifyPropertyChanged
    {
        /// <summary>
        /// PropertyChanged
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// PropertyChanged
        /// </summary>
        /// <param name="propertyName">fdgafgsdfg</param>
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        /// <summary>
        /// Sets property
        /// </summary>
        /// <param name="storage">ddfgsdfg</param>
        /// <param name="value">fgsfgsdfg</param>
        /// <returns> if value is changed, returns true</returns>
        /// <param name="propertyName">fdgafgsdfg</param>
        protected virtual bool SetProperty<T>(ref T storage, T value, [CallerMemberName] string propertyName = "")
        {
            if (EqualityComparer<T>.Default.Equals(storage, value))
                return false;
            storage = value;
            this.OnPropertyChanged(propertyName);
            return true;
        }
    }
}
