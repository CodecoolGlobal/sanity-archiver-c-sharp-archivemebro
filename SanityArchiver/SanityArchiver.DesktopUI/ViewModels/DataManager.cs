using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace SanityArchiver.DesktopUI.ViewModels
{
    /// <summary>
    /// Manages Data.
    /// </summary>
    public class DataManager
    {
        /// <summary>
        /// Selected files from the directory-map.
        /// </summary>
        private static List<FileInfo> _selectedFiles = new List<FileInfo>();

        /// <summary>
        /// Creates a tree item for directoryinfo.
        /// </summary>
        /// <param name="dir">directory</param>
        /// <returns>a treeitem</returns>
        public static TreeViewItem CreateTreeItem(DirectoryInfo dir)
        {
            TreeViewItem item = new TreeViewItem()
            {
                Header = dir.Name,
                Tag = dir,
            };
            AddDummyTag(item);
            return item;
        }

        /// <summary>
        /// Gets selected file list.
        /// </summary>
        /// <returns>selected files list</returns>
        public static List<FileInfo> GetSelectedFiles()
        {
            return _selectedFiles;
        }

        /// <summary>
        /// Adds a specific fileinfo to the selected list.
        /// </summary>
        /// <param name="inf">Fileinfo of a file</param>
        public static void AddSelectedFile(FileInfo inf)
        {
            if (FileInSelected(inf))
            {
                ExceptionHandler.HandleException(new FileLoadException());
            }
            else
            {
                _selectedFiles.Add(inf);
            }
        }

        /// <summary>
        /// Clears the list of selected files.
        /// </summary>
        public static void ClearSelectedsList()
        {
            _selectedFiles.Clear();
        }

        /// <summary>
        /// Removes a specific file already selected.
        /// </summary>
        /// <param name="filo">Fileinfo of file</param>
        public static void RemoveSpecificSelected(FileInfo filo)
        {
            List<int> indices = new List<int>();
            foreach (var item in _selectedFiles)
            {
                if (item.FullName.Equals(filo.FullName))
                {
                    indices.Add(_selectedFiles.IndexOf(item));
                }
            }

            foreach (var index in indices)
            {
                _selectedFiles.RemoveAt(index);
            }
        }

        /// <summary>
        /// Creates a tree item for driveinfo.
        /// </summary>
        /// <param name="drive">drive</param>
        /// <returns>a treeitem</returns>
        public static TreeViewItem CreateTreeItem(DriveInfo drive)
        {
            TreeViewItem item = new TreeViewItem()
            {
                Header = drive.Name,
                Tag = drive,
            };
            AddDummyTag(item);
            return item;
        }

        /// <summary>
        /// Creates a tree item for fileinfo.
        /// </summary>
        /// <param name="filo">file</param>
        /// <returns>a treeitem</returns>
        public static TreeViewItem CreateTreeItem(FileInfo filo)
        {
            TreeViewItem item = new TreeViewItem
            {
                Name = "FileSource",
                Header = $"{filo.Name} {filo.CreationTime} {filo.Length / 1048576} MB",
                Tag = filo.FullName,
            };
            return item;
        }

        /// <summary>
        /// Adds a filler tag.
        /// </summary>
        /// <param name="item">dummyTag</param>
        public static void AddDummyTag(TreeViewItem item)
        {
            item.Items.Add("Loading...");
        }

        /// <summary>
        /// Checks if fileinfo is already included in files list.
        /// </summary>
        /// <param name="inf">fileinfo</param>
        /// <returns>true or false</returns>
        internal static bool FileInSelected(FileInfo inf)
        {
            foreach (var item in _selectedFiles)
            {
                if (item.FullName.Equals(inf.FullName))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
