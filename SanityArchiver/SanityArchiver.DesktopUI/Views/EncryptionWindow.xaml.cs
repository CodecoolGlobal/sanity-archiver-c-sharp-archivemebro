using System;
using System.IO;
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

using SanityArchiver.DesktopUI.ViewModels;

namespace SanityArchiver.DesktopUI.Views
{
    /// <summary>
    /// Interaction logic for EncryptionWindow.xaml
    /// </summary>
    public partial class EncryptionWindow : Window
    {
        private readonly EncryptionViewModel _viewModel;

        public EncryptionWindow()
        {
            InitializeComponent();
            _viewModel = new EncryptionViewModel();
            DataContext = _viewModel;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string filePath = "C:/Users/matra/OneDrive/hello.enc";
            string filePath1 = "C:/Users/matra/OneDrive/hello.txt";

            _viewModel.PerformAction(filePath1);
            _viewModel.PerformAction(filePath);
        }
    }
}
