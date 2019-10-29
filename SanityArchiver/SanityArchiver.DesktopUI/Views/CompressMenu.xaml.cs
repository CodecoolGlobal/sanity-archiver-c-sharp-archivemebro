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

         //   this.DataContext = _compressedFile;
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            string zipFileName = CompressedFileName.Text;
            _compressedFile.CompressedName = zipFileName;
            string dir = @"C:\Users\Áts Bálint\codecool\test_dir\archiveMeBroTestFiles";
            MessageBox.Show(zipFileName);

            #region first version code

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
                        ZipArchiveEntry zipFileEntry = zipArchive.CreateEntry(fileToZip.Name);

                        //ZipArchiveEntry zipFileEntry = zipArchive.CreateEntry(fileToZip.FullName.Replace(dir, string.Empty).Replace('\\', '/'));

                        //add the file contents
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
            #endregion

            #region second version code

            /*
            ///Dictionary<string, string> filesToZip = new Dictionary<string, string>();
            using (var memoryStream = new MemoryStream())
            {
                foreach (var item in _compressedFile.FilesToCompress)
                {
                    using (var archive = new ZipArchive(memoryStream, ZipArchiveMode.Create, true))
                    {
                        var file = archive.CreateEntry(item.Name);
                        using (var entryStream = file.Open())
                        using (var streamWriter = new StreamWriter(entryStream))
                        {
                            streamWriter.Write(item);
                        }
                    }
                }

                using (var fileStream = new FileStream(dir, FileMode.Create))
                {
                    memoryStream.Seek(0, SeekOrigin.Begin);
                    memoryStream.CopyTo(fileStream);
                }
            }*/
            #endregion
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Cancel clicked");
        }
    }
}
