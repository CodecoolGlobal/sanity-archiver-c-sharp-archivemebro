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

        /// <summary>
        /// Initializes a new instance of the <see cref="CompressMenu"/> class.
        /// The View of the CompressMenu.xaml.cs
        /// </summary>
        public CompressMenu()
        {
            InitializeComponent();
            _compressedFile = new CompressedFileVm();
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            string zipFileName = CompressedFileName.Text;
            _compressedFile.CompressedName = zipFileName;
            string dir = DirToCompress.Text;
            _compressedFile.Compress(dir, zipFileName);
            Close();
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
