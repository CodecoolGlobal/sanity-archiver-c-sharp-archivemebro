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
            _compressedFile.Compress(dir, zipFileName);
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Cancel clicked");
        }
    }
}
