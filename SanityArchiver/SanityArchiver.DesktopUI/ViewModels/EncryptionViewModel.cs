using System;
using System.Windows;
using System.Text;
using System.IO;
using System.Security.Cryptography;

namespace SanityArchiver.DesktopUI.ViewModels
{
    /// <summary>
    /// Encryption viewmodel.
    /// </summary>
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
                UnicodeEncoding unicodeEncoding = new UnicodeEncoding();
                byte[] key = unicodeEncoding.GetBytes(password);

                string cryptFile = outputFile;
                FileStream fileStreamCrypt = new FileStream(cryptFile, FileMode.Create);

                RijndaelManaged rinjdaelCrypt = new RijndaelManaged();

                CryptoStream cs = new CryptoStream(
                    fileStreamCrypt,
                    rinjdaelCrypt.CreateEncryptor(key, key),
                    CryptoStreamMode.Write);

                FileStream fileStreamInp = new FileStream(inputFile, FileMode.Open);

                int data;
                while ((data = fileStreamInp.ReadByte()) != -1)
                {
                    cs.WriteByte((byte)data);
                }

                fileStreamInp.Close();
                cs.Close();
                fileStreamCrypt.Close();
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

                UnicodeEncoding unicodeEncoding = new UnicodeEncoding();
                byte[] key = unicodeEncoding.GetBytes(password);

                FileStream fileStreamInp = new FileStream(inputFile, FileMode.Open);

                RijndaelManaged rinjdaelCrypt = new RijndaelManaged();

                CryptoStream cs = new CryptoStream(
                    fileStreamInp,
                    rinjdaelCrypt.CreateDecryptor(key, key),
                    CryptoStreamMode.Read);

                FileStream fileStreamOut = new FileStream(outputFile, FileMode.Create);

                int data;
                while ((data = cs.ReadByte()) != -1)
                {
                    fileStreamOut.WriteByte((byte)data);
                }

                fileStreamOut.Close();
                cs.Close();
                fileStreamInp.Close();
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