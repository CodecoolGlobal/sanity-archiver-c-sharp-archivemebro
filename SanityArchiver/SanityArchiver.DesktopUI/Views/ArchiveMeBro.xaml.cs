using System.Windows;
using SanityArchiver.DesktopUI.ViewModels;
using System.Windows.Controls;
using System.IO;
using System.Collections.Generic;

namespace SanityArchiver.DesktopUI.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class ArchiveMeBro : Window
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ArchiveMeBro"/> class.
        /// </summary>
        public ArchiveMeBro()
        {
            InitializeComponent();
            InitRoots();
        }

        private void InitRoots()
        {
            foreach(var drive in ExplorerService.GetRootDirectories())

            {
                DirectoryMap.Items.Add(DataManager.CreateTreeItem(drive));
            }
        }

        private void ItemSelectedHandler(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
        }

        private void ItemDoubleClickedHandler(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
        }

        private void ItemCollapseHandler(object sender, RoutedEventArgs e)
        {
            TreeViewItem item = e.Source as TreeViewItem;
            item.IsExpanded = false;
            item.Items.Clear();
            DataManager.AddDummyTag(item);
        }

        private void ItemExpandedHandler(object sender, RoutedEventArgs e)
        {
            TreeViewItem item = e.Source as TreeViewItem;
            item.IsExpanded = true;
            string targetDir = ((DirectoryInfo)item.Tag).FullName;
            if(item.Items.Count == 1 && item.Items[0] is string)

            {
                item.Items.Clear();

                IList<DirectoryInfo> subDirs = null;
                IList<FileInfo> files = null;
                if (item.Tag is DriveInfo)
                {
                    subDirs = ExplorerService.GetChildDirectories(targetDir);
                }
                if (item.Tag is DirectoryInfo)
                {

                    subDirs = ExplorerService.GetChildDirectories(targetDir);
                    files = ExplorerService.GetChildFiles(targetDir);
                }

                try
                {
                    foreach(DirectoryInfo sub in subDirs)
                    {
                        item.Items.Add(DataManager.CreateTreeItem(sub));
                    }

                    if (files != null)
                    {
                        foreach (FileInfo file in files)
                        {
                            item.Items.Add(DataManager.CreateTreeItem(file));
                        }
                    }
                }
                catch (DirectoryNotFoundException)
                {
                }
            }
        }


    }
}
