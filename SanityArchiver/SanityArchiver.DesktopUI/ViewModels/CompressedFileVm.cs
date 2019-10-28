using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections.ObjectModel;

namespace SanityArchiver.Application.Models
{
    /// <summary>
    /// Model for containing the files to compress
    /// </summary>
    public class CompressedFileVm
    {
        private ObservableCollection<FileInfo> _filesToCompress = new ObservableCollection<FileInfo>();
        private string _compressedName;

        /// <summary>
        /// Gets or sets the observableCollection of files to compress
        /// </summary>
        public ObservableCollection<FileInfo> FilesToCompress
        {
            get
            {
                return _filesToCompress;
            }

            set
            {
                if (_filesToCompress != value)
                {
                    _filesToCompress = value;
                }
            }
        }

        /// <summary>
        /// Gets or sets
        /// </summary>
        public string CompressedName
        {
            get
            {
                return _compressedName;
            }

            set
            {
                if (_compressedName != value)
                {
                    _compressedName = value;
                }
            }
        }
    }
}
