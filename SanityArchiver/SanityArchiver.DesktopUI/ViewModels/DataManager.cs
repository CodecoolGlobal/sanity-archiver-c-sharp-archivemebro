using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Controls;

namespace SanityArchiver.DesktopUI.ViewModels
{
    public class DataManager

    {
        public static TreeViewItem CreateTreeItem(DirectoryInfo dir)
        {
            TreeViewItem item = new TreeViewItem()
            {
                Header = dir.Name,
                Tag = dir
            };
            AddDummyTag(item);
            return item;
        } 
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

        public static TreeViewItem CreateTreeItem(FileInfo filo)
        {
            TreeViewItem item = new TreeViewItem
            {
                Header = $"{filo.Name} {filo.CreationTime} {filo.Length / 1048576} MB",
                Tag = filo.FullName,
            };
            AddDummyTag(item);
            return item;
        }

        public static void AddDummyTag(TreeViewItem item)
        {
            item.Items.Add("Loading...");
        }
    }
}
