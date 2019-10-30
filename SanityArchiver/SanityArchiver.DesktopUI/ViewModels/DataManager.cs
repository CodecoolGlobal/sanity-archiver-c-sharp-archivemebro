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
    }
}
