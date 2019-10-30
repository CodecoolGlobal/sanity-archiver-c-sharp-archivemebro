using System;
using System.Windows;
using System.Text;
using System.IO;
using System.Security.Cryptography;

namespace SanityArchiver.DesktopUI.ViewModels
{
    public class EncryptionViewModel
    {
        /// <summary>
        /// Performs action based on extension of file
        /// </summary>
        /// <param name="filePath">filePath</param>
        public void PerformAction(string filePath)
        {
            if (File.Exists(filePath))
            {
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
            else
            {
                MessageBox.Show("File doesn't exist!");
            }
        }

        /// <summary>
        /// Encrypts the inputFile into the outputFile
        /// </summary>
        /// <param name="inputFile">inputFile</param>
        /// <param name="outputFile">outputFile</param>
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

        /// <summary>
        /// Decrypts the inputFile into the outputFile
        /// </summary>
        /// <param name="inputFile">inputFile</param>
        /// <param name="outputFile">outputFile</param>
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

        /// <summary>
        /// Creates a string consisting of the hour, minute and second of the date
        /// </summary>
        /// <param name="date">date</param>
        private string CreateDateString(DateTime date)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("_").Append(date.Hour).Append(date.Minute).Append(date.Second);
            return stringBuilder.ToString();
        }
    }
}
