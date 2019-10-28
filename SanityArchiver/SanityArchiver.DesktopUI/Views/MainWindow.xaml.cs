using System;
using System.Windows;
using System.Text;
using System.IO;
using System.Security;
using System.Security.Cryptography;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;

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
            string fileName = "hello.txt";

            string encodedName = "hellno.enc";
            string directory = "C:/Users/matra/OneDrive/";

            EncryptFile(directory + fileName, directory + encodedName);
            DecryptFile(
                directory + encodedName,
                directory + SplitFileNameToNameAndExtension(fileName)[0] + CreateDateString(DateTime.Now) + SplitFileNameToNameAndExtension(fileName)[1]);
        }

        private void EncryptFile(string inputFile, string outputFile)
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

        private void DecryptFile(string inputFile, string outputFile)
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
            stringBuilder.Append(date.Hour).Append(date.Minute).Append(date.Second);
            return stringBuilder.ToString();
        }

        private string[] SplitFileNameToNameAndExtension(string fileName)
        {
            int number = 0;

            for (int i = 0; i < fileName.Length; i++)
            {
                if (fileName[i] == '.')
                {
                    number = i;
                }
            }

            string[] fileNameParts = { fileName.Substring(0, number), fileName.Substring(number) };

            return fileNameParts;
        }
    }
}
