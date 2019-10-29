using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SanityArchiver.Application.Models
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
        public static IList<Fil> GetChildFiles(string directory)
        {
            try
            {
                return (from item in Directory.GetFiles(directory)
                       select new Fil(item)).ToList();
            }
            catch (FileNotFoundException)
            {
            }

            return new List<Fil>();
        }

        /// <summary>
        /// Gets children of directory, other directories.
        /// </summary>
        /// <param name="directory">the directory to retreive items from</param>
        /// <returns>a list of directories or null</returns>
        public static IList<Dir> GetChildDirectories(string directory)
        {
            try
            {
                return (from item in Directory.GetDirectories(directory)
                        select new Dir(item)).ToList();
            }
            catch (DirectoryNotFoundException)
            {
            }

            return new List<Dir>();
        }

        /// <summary>
        /// Gets drives, or root directories.
        /// </summary>
        /// <returns>a list of root directories</returns>
        public static IList<Dri> GetRootDirectories()
        {
            return (from drive in DriveInfo.GetDrives() select new Dri(drive)).ToList();
        }
    }
}
