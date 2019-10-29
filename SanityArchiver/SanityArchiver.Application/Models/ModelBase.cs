using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SanityArchiver.Application.Models
{

    /// <summary>
    /// BaseModel for ViewModels.
    /// </summary>
    public abstract class ModelBase : INotifyPropertyChanged
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ModelBase"/> class.
        /// </summary>
        public ModelBase(string item)
        {
        }

        /// <inheritdoc/>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Gets or sets name of Directory.
        /// </summary>
        private string _name;

        public string Name
        {
            get
            {
                return _name;
            }

            set
            {
                _name = value;
                OnPropertyChanged("Name");
            }
        }
        private string _path;

        /// <summary>
        /// Gets or sets path of directory.
        /// </summary>
        public string Path
        {
            get
            {
                return _path;
            }

            set
            {
                _path = value;
                OnPropertyChanged("Path");
            }
        }

        private string _root;

        /// <summary>
        /// Gets or sets root directory it belongs to.
        /// </summary>
        public string Root
        {
            get
            {
                return _root;
            }

            set
            {
                _root = value;
                OnPropertyChanged("Root");
            }
        }

        private string _size;

        /// <summary>
        /// Gets or sets Size.
        /// </summary>
        public string Size
        {
            get
            {
                return _size;
            }

            set
            {
                _size = value;
                OnPropertyChanged("Size");
            }
        }

        private string _ext;

        /// <summary>
        /// Gets or sets Ext.
        /// </summary>
        public string Extension
        {
            get
            {
                return _ext;
            }

            set
            {
                _ext = value;
                OnPropertyChanged("Extension");
            }
        }

        private ItemType _type;

        /// <summary>
        /// Gets or Sets direrctory type.
        /// </summary>
        public ItemType Type
        {
            get
            {
                return _type;
            }

            set
            {
                _type = value;
                OnPropertyChanged("Type");
            }
        }

        /// <summary>
        /// Triggers on Property Change.
        /// </summary>
        /// <param name="propertyName">The name of property changed.</param>
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
