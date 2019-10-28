using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using SanityArchiver.Application.Models;

namespace SanityArchiver.DesktopUI.Views
{
    /// <summary>
    /// Interaction logic for CompressMenu.xaml
    /// </summary>
    public partial class CompressMenu : Window
    {
        private readonly CompressedFileVm _compressedFile;

        //private CompressedFile _compressedFile = new CompressedFile();

        /// <summary>
        /// The
        /// </summary>
        public CompressMenu()
        {
            InitializeComponent();
            _compressedFile = new CompressedFileVm();
            this.DataContext = _compressedFile;
        }

        /// <summary>
        /// Gets or Sets
        /// </summary>
       /* public CompressedFile CompresssedFile
        {
            get
            {
                return _compressedFile;
            }

            set
            {
                if (_compressedFile != value)
                {
                    _compressedFile = value;
                }
            }
        }*/

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            string zipFileName = string.Format("zipfile-{0:yyyy-MM-dd_hh-mm-ss-tt}.zip", DateTime.Now);
            string dir = @"C:\Users\Áts Bálint\codecool\test_dir\archiveMeBroTestFiles";

            //_compressedFile.FilesToCompress.First().DirectoryName;

            using (MemoryStream zipMS = new MemoryStream())
            {
                using (ZipArchive zipArchive = new ZipArchive(zipMS, ZipArchiveMode.Create, true))
                {
                    foreach (FileInfo fileToZip in _compressedFile.FilesToCompress)
                    {
                        //read the file bytes
                        byte[] fileToZipBytes = System.IO.File.ReadAllBytes(fileToZip.FullName);

                        //create the entry - this is the zipped filename
                        //change slashes - now it's VALID
                        ZipArchiveEntry zipFileEntry = zipArchive.CreateEntry(fileToZip.FullName.Replace(dir, string.Empty).Replace('\\', '/'));

                        //add the file contents
                        using (Stream zipEntryStream = zipFileEntry.Open())
                        using (BinaryWriter zipFileBinary = new BinaryWriter(zipEntryStream))
                        {
                            zipFileBinary.Write(fileToZipBytes);
                        }
                    }
                }

                using (FileStream finalZipFileStream = new FileStream(dir + zipFileName, FileMode.Create))
                {
                    zipMS.Seek(0, SeekOrigin.Begin);
                    zipMS.CopyTo(finalZipFileStream);
                }
            }
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
        }
    }
}
