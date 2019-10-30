using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SanityArchiver.DesktopUI.ViewModels
{
    /// <summary>
    /// Provides structural information of the directory passed to it.
    /// </summary>
    public class ExplorerService
    {
        /// <summary>
        /// Gets children of directory, files.
        /// </summary>
        /// <param name="directory">the directory to take item-names from</param>
        /// <returns>either filenames and paths or null</returns>
        public static IList<FileInfo> GetChildFiles(string directory)
        {
            try
            {
                return (from item in Directory.GetFiles(directory)
                       select new FileInfo(item)).ToList();
            }
            catch (FileNotFoundException)
            {
            }

            return new List<FileInfo>();
        }

        /// <summary>
        /// Gets children of directory, other directories.
        /// </summary>
        /// <param name="directory">the directory to retreive items from</param>
        /// <returns>a list of directories or null</returns>
        public static IList<DirectoryInfo> GetChildDirectories(string directory)
        {
            try
            {
                return (from item in Directory.GetDirectories(directory)
                        select new DirectoryInfo(item)).ToList();
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(ex);
            }

            return new List<DirectoryInfo>();
        }

        /// <summary>
        /// Gets drives, or root directories.
        /// </summary>
        /// <returns>a list of root directories</returns>
        public static IList<DriveInfo> GetRootDirectories()
        {
            return (from drive in DriveInfo.GetDrives() select drive).ToList();
        }
    }
}
