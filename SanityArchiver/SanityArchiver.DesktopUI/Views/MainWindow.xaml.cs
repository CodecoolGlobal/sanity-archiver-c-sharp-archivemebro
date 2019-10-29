using System;
using System.Windows;
using System.Text;
using System.IO;
using System.Security.Cryptography;

namespace SanityArchiver.DesktopUI.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MainWindow"/> class.
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            EncryptionWindow encryption = new EncryptionWindow();
            encryption.Show();
        }
    }
}
