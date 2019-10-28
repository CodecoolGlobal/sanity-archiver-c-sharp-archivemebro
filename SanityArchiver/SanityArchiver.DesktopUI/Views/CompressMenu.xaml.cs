using System;
using System.Collections.Generic;
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
        private CompressedFile _compressedFile = new CompressedFile();
        public CompressMenu()
        {
            InitializeComponent();
        }
        public CompressedFile CompresssedFile
        {
            get { return _compressedFile; }

            set
            {
                if (_compressedFile != value)
                {
                    _compressedFile = value;
                }
            }
        }



        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }
    }
}
