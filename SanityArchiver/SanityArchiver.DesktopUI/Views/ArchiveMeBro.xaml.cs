using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using SanityArchiver.DesktopUI.ViewModels;

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
            foreach (var drive in ExplorerService.GetRootDirectories())
            {
                DirectoryMap.Items.Add(DataManager.CreateTreeItem(drive));
            }
        }

        private void ItemCollapseHandler(object sender, RoutedEventArgs e)
        {
            TreeViewItem item = e.Source as TreeViewItem;
            item.IsExpanded = false;
            item.Items.Clear();
            DataManager.AddDummyTag(item);
            item.IsExpanded = false;
        }

        private void ItemExpandedHandler(object sender, RoutedEventArgs e)
        {
            TreeViewItem item = e.Source as TreeViewItem;
            string targetDir = string.Empty;
            if (item.Items.Count == 1 && item.Items[0] is string)
            {
                item.Items.Clear();

                IList<DirectoryInfo> subDirs = null;
                IList<FileInfo> files = null;
                if (item.Tag is DriveInfo)
                {
                    targetDir = ((DriveInfo)item.Tag).Name;
                    subDirs = ExplorerService.GetChildDirectories(targetDir);
                }

                if (item.Tag is DirectoryInfo)
                {
                    targetDir = targetDir = ((DirectoryInfo)item.Tag).FullName;
                    subDirs = ExplorerService.GetChildDirectories(targetDir);
                    files = ExplorerService.GetChildFiles(targetDir);
                }

                try
                {
                    foreach (DirectoryInfo sub in subDirs)
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
                catch (Exception ex)
                {
                    ExceptionHandler.HandleException(ex);
                }

                item.IsExpanded = true;
            }
        }

        private void Archive_Click(object sender, RoutedEventArgs e)
        {
            new CompressMenu().ShowDialog();
        }

        private void EncryptDecrypt_Click(object sender, RoutedEventArgs e)
        {
            var encryptor = new EncryptionViewModel();
            encryptor.PerformAction();
        }

        private void ItemSelected(object sender, RoutedEventArgs e)
        {
            TreeViewItem treeItem = e.Source as TreeViewItem;
            if (treeItem.Name.Equals("FileSource"))
            {
                FileInfo item = new FileInfo(treeItem.Tag.ToString());
                if (DataManager.FileInSelected(item))
                {
                    ExceptionHandler.HandleException(new FileLoadException());
                }
                else
                {
                    DataManager.AddSelectedFile(item);
                    SelectedItemsList.Items.Add(item);
                }
            }
        }

        private void ClearAll_Click(object sender, RoutedEventArgs e)
        {
            SelectedItemsList.Items.Clear();
            DataManager.ClearSelectedsList();
        }

        private void RemoveSelected_Click(object sender, RoutedEventArgs e)
        {
            var selected = SelectedItemsList.SelectedItem.ToString().Replace(@"\\", @"\");
            FileInfo item = new FileInfo(selected);
            SelectedItemsList.Items.Remove(SelectedItemsList.SelectedItem);
            DataManager.RemoveSpecificSelected(item);
        }
    }
}
