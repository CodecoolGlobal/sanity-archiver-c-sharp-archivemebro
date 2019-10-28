using System;
using System.Windows;
using System.Text;
using System.IO;
using System.Security.Cryptography;

using SanityArchiver.DesktopUI.ViewModels;

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

        public void EncryptFile(string inputFile, string outputFile)
        {
            try
            {
                string password = @"myKey123"; // Your Key Here
                UnicodeEncoding uE = new UnicodeEncoding();
                byte[] key = uE.GetBytes(password);

                string cryptFile = outputFile;
                FileStream fsCrypt = new FileStream(cryptFile, FileMode.Create);

                RijndaelManaged rMCrypto = new RijndaelManaged();

                CryptoStream cs = new CryptoStream(
                    fsCrypt,
                    rMCrypto.CreateEncryptor(key, key),
                    CryptoStreamMode.Write);

                FileStream fsIn = new FileStream(inputFile, FileMode.Open);

                int data;
                while ((data = fsIn.ReadByte()) != -1)
                {
                    cs.WriteByte((byte)data);
                }

                fsIn.Close();
                cs.Close();
                fsCrypt.Close();
            }
            catch
            {
                MessageBox.Show("Encryption failed!", "Error");
            }
        }

        public void DecryptFile(string inputFile, string outputFile)
        {
            {
                string password = @"myKey123"; // Your Key Here

                UnicodeEncoding uE = new UnicodeEncoding();
                byte[] key = uE.GetBytes(password);

                FileStream fsCrypt = new FileStream(inputFile, FileMode.Open);

                RijndaelManaged rMCrypto = new RijndaelManaged();

                CryptoStream cs = new CryptoStream(
                    fsCrypt,
                    rMCrypto.CreateDecryptor(key, key),
                    CryptoStreamMode.Read);

                FileStream fsOut = new FileStream(outputFile, FileMode.Create);

                int data;
                while ((data = cs.ReadByte()) != -1)
                {
                    fsOut.WriteByte((byte)data);
                }

                fsOut.Close();
                cs.Close();
                fsCrypt.Close();
            }
        }

        private string CreateDateString(DateTime date)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("_").Append(date.Hour).Append(date.Minute).Append(date.Second);
            return stringBuilder.ToString();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string filePath = "C:/Users/matra/OneDrive/hello.txt";

            if (!File.Exists(filePath))
            {
                MessageBox.Show("No such file exists!");
                return;
            }

            if (Path.GetExtension(filePath) == ".txt")
            {
                EncryptFile(filePath, Path.ChangeExtension(filePath, ".enc"));
            }
            else if (Path.GetExtension(filePath) == ".enc")
            {
               DecryptFile(
               filePath,
               Path.ChangeExtension(filePath, ".txt")
               .Insert(filePath.IndexOf('.'), CreateDateString(DateTime.Now)));
            }
        }
    }
}
