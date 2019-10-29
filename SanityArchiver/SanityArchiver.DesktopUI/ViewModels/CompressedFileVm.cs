using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections.ObjectModel;
using System.IO.Compression;
using SanityArchiver.DesktopUI.ViewModels;

namespace SanityArchiver.Application.Models
{
    /// <summary>
    /// ViewModel for the Compress feature
    /// </summary>
    public class CompressedFileVm : ViewModelBase
    {
        private ObservableCollection<FileInfo> _filesToCompress = new ObservableCollection<FileInfo>();
        private string _compressedName;

        /// <summary>
        /// Initializes a new instance of the <see cref="CompressedFileVm"/> class.
        /// </summary>
        public CompressedFileVm()
        {
            CollectTheFilesToCompress();
        }

        /// <summary>
        /// Gets or sets the observableCollection of files to compress (FileInfo is the Model in this case.)
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
        /// Gets or sets the name of the compressed archive.
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
        /// Compresses the selected files into the dir with zipFileName
        /// </summary>
        /// <param name="dir"> The directory to make the archive</param>
        /// <param name="zipFileName"> Name of the archive</param>
        public void Compress(string dir, string zipFileName)
        {
            using (MemoryStream zipMS = new MemoryStream())
            {
                using (ZipArchive zipArchive = new ZipArchive(zipMS, ZipArchiveMode.Create, true))
                {
                    foreach (FileInfo fileToZip in FilesToCompress)
                    {
                        // read the file bytes
                        byte[] fileToZipBytes = System.IO.File.ReadAllBytes(fileToZip.FullName);

                        // create the entry - this is the zipped filename
                        // hange slashes - now it's VALID
                        ZipArchiveEntry zipFileEntry = zipArchive.CreateEntry(fileToZip.Name);

                        // add the file contents
                        using (Stream zipEntryStream = zipFileEntry.Open())
                        using (BinaryWriter zipFileBinary = new BinaryWriter(zipEntryStream))
                        {
                            zipFileBinary.Write(fileToZipBytes);
                        }
                    }
                }

                using (FileStream finalZipFileStream = new FileStream(dir + "\\" + zipFileName + ".zip", FileMode.Create))
                {
                    zipMS.Seek(0, SeekOrigin.Begin);
                    zipMS.CopyTo(finalZipFileStream);
                }
            }
        }

        /// <summary>
        /// fills the list _filesToCompress with files.
        /// </summary>
        public void CollectTheFilesToCompress()
        {
            _filesToCompress.Add(new FileInfo(@"C:\Users\Áts Bálint\codecool\test_dir\archiveMeBroTestFiles\aaa.txt"));
            _filesToCompress.Add(new FileInfo(@"C:\Users\Áts Bálint\codecool\test_dir\archiveMeBroTestFiles\bbb.txt"));
            _filesToCompress.Add(new FileInfo(@"C:\Users\Áts Bálint\codecool\test_dir\archiveMeBroTestFiles\ccc.txt"));
            _filesToCompress.Add(new FileInfo(@"C:\Users\Áts Bálint\codecool\test_dir\archiveMeBroTestFiles\ddd.txt"));
            _filesToCompress.Add(new FileInfo(@"C:\Users\Áts Bálint\codecool\test_dir\archiveMeBroTestFiles\newdoc.txt"));
        }
    }
}
