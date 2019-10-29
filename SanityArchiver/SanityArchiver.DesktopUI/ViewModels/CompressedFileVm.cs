using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections.ObjectModel;
using SanityArchiver.DesktopUI.ViewModels;

namespace SanityArchiver.Application.Models
{
    /// <summary>
    /// Model for containing the files to compress
    /// </summary>
    public class CompressedFileVm : ViewModelBase
    {
        private ObservableCollection<FileInfo> _filesToCompress = new ObservableCollection<FileInfo>();
        private string _compressedName;

        /// <summary>
        /// effsf
        /// </summary>
        public CompressedFileVm()
        {
            GetTheFilesToCompress();
        }

        /// <summary>
        /// Gets or sets the observableCollection of files to compress (FileInfo is the Model in this case.
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

        /// <summary>
        /// GetTheFilesToCompress
        /// </summary>
        public void GetTheFilesToCompress()
        {
            _filesToCompress.Add(new FileInfo(@"C:\Users\Áts Bálint\codecool\test_dir\archiveMeBroTestFiles\aaa.txt"));
            _filesToCompress.Add(new FileInfo(@"C:\Users\Áts Bálint\codecool\test_dir\archiveMeBroTestFiles\bbb.txt"));
            _filesToCompress.Add(new FileInfo(@"C:\Users\Áts Bálint\codecool\test_dir\archiveMeBroTestFiles\ccc.txt"));
            _filesToCompress.Add(new FileInfo(@"C:\Users\Áts Bálint\codecool\test_dir\archiveMeBroTestFiles\ddd.txt"));
            _filesToCompress.Add(new FileInfo(@"C:\Users\Áts Bálint\codecool\test_dir\archiveMeBroTestFiles\newdoc.txt"));
        }
    }
}
