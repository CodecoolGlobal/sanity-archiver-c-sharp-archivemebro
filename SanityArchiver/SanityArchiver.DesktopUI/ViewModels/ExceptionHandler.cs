using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SanityArchiver.DesktopUI.ViewModels
{
    /// <summary>
    /// Handles exceptions.
    /// </summary>
    public static class ExceptionHandler
    {
        /// <summary>
        /// Handles exceptions.
        /// </summary>
        /// <param name="e">Exception of any type. Please add more if more handling needed.</param>
        public static void HandleException(Exception e)
        {
            string warningText = string.Empty;
            MessageBoxButton errorButton = MessageBoxButton.OK;
            MessageBoxImage errorImage = MessageBoxImage.Asterisk;

            if (e is UnauthorizedAccessException)
            {
                warningText = "You do not have permission to view the elements of this folder. Please don't.";
                errorImage = MessageBoxImage.Information;
            }
            else if (e is DirectoryNotFoundException)
            {
                warningText = "The directory or its elements could not be found. We have no idea where they are.";
                errorButton = MessageBoxButton.OKCancel;
                errorImage = MessageBoxImage.Warning;
            }
            else
            {
                warningText = "An unknown error occurred. Please cry loudly.";
                errorButton = MessageBoxButton.YesNo;
                errorImage = MessageBoxImage.Exclamation;
            }

            MessageBox.Show(warningText, "Generic Error Message", errorButton, errorImage);
        }
    }
}
