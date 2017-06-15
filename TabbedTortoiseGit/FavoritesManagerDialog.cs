using Common;
using Microsoft.WindowsAPICodePack.Dialogs;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TabbedTortoiseGit.Properties;

namespace TabbedTortoiseGit
{
    partial class FavoritesManagerDialog : Form
    {
        public static bool ShowFavoritesManager()
        {
            FavoritesManagerDialog dialog = new FavoritesManagerDialog( Settings.Default.FavoriteRepos );
            if( dialog.ShowDialog() == DialogResult.OK )
            {
                Settings.Default.FavoriteRepos = dialog.Favorites;
                return true;
            }
            else
            {
                return false;
            }
        }

        public TreeNode<FavoriteRepo> Favorites
        {
            get
            {
                return _root;
            }
        }

        private readonly CommonOpenFileDialog _folderDialog = new CommonOpenFileDialog()
        {
            IsFolderPicker = true
        };

        private TreeNode<FavoriteRepo> _root;

        private TreeNode<FavoriteRepo> _selectedFavoriteItem;

        private FavoritesManagerDialog( TreeNode<FavoriteRepo> favorites )
        {
            InitializeComponent();

            FavoritesTree.AfterSelect += FavoritesTree_AfterSelect;
            FavoritesTree.MouseUp += FavoritesTree_MouseUp;

            FavoritesList.MouseUp += FavoritesList_MouseUp;

            FavoritesContextMenu.Opening += FavoritesContextMenu_Opening;

            AddFavoritesFolderMenuItem.Click += AddFavoritesFolderMenuItem_Click;
            RemoveFavoritesFolderMenuItem.Click += RemoveFavoritesFolderMenuItem_Click;

            AddFavoriteMenuItem.Click += AddFavoriteMenuItem_Click;
            RemoveFavoriteMenuItem.Click += RemoveFavoriteMenuItem_Click;

            _root = favorites;
            UpdateFavoritesTree( _root );
        }

        private void FavoritesTree_AfterSelect( object sender, TreeViewEventArgs e )
        {
            TreeNode<FavoriteRepo> node = (TreeNode<FavoriteRepo>)e.Node.Tag;
            UpdateFavoritesList( node );
        }

        private void FavoritesTree_MouseUp( object sender, MouseEventArgs e )
        {
            if( e.Button == MouseButtons.Right )
            {
                TreeNode node = FavoritesTree.GetNodeAt( e.Location );
                FavoritesTree.SelectedNode = node;
                _selectedFavoriteItem = (TreeNode<FavoriteRepo>)node?.Tag ?? _root;
                if( _selectedFavoriteItem != null )
                {
                    FavoritesContextMenu.Show( FavoritesTree, e.Location );
                }
            }
        }

        private void FavoritesList_MouseUp( object sender, MouseEventArgs e )
        {
            if( e.Button == MouseButtons.Right )
            {
                ListViewItem item = FavoritesList.GetItemAt( e.X, e.Y );
                _selectedFavoriteItem = (TreeNode<FavoriteRepo>)( item?.Tag ?? FavoritesTree.SelectedNode?.Tag );
                if( _selectedFavoriteItem != null )
                {
                    FavoritesContextMenu.Show( FavoritesList, e.Location );
                }
            }
        }

        private void FavoritesContextMenu_Opening( object sender, CancelEventArgs e )
        {
            if( _selectedFavoriteItem == null )
            {
                AddFavoritesFolderMenuItem.Visible = false;
                RemoveFavoritesFolderMenuItem.Visible = false;
                AddFavoriteMenuItem.Visible = false;
                RemoveFavoriteMenuItem.Visible = false;
            }
            else
            {
                AddFavoritesFolderMenuItem.Visible = true;
                RemoveFavoritesFolderMenuItem.Visible = _selectedFavoriteItem.Value.IsFavoriteFolder && _selectedFavoriteItem != _root;
                AddFavoriteMenuItem.Visible = true;
                RemoveFavoriteMenuItem.Visible = !_selectedFavoriteItem.Value.IsFavoriteFolder;
            }
        }

        private void AddFavoritesFolderMenuItem_Click( object sender, EventArgs e )
        {
            String folderName = InputDialog.ShowInput( "Favorite Folder Name", "", "" );
            if( folderName != null )
            {
                TreeNode<FavoriteRepo> newNode = new TreeNode<FavoriteRepo>( new FavoriteRepo( folderName, "", false, true ) );
                if( _selectedFavoriteItem.Value.IsFavoriteFolder )
                {
                    _selectedFavoriteItem.Add( newNode );
                }
                else
                {
                    _selectedFavoriteItem.Parent.Children.Insert( _selectedFavoriteItem.Index, newNode );
                }
                UpdateFavoritesTree( newNode );
            }
        }

        private void RemoveFavoritesFolderMenuItem_Click( object sender, EventArgs e )
        {
            TreeNode<FavoriteRepo> parent = _selectedFavoriteItem.Parent;
            parent.Remove( _selectedFavoriteItem );
            UpdateFavoritesTree( parent );
        }

        private void AddFavoriteMenuItem_Click( object sender, EventArgs e )
        {
            if( _folderDialog.ShowDialog() != CommonFileDialogResult.Ok )
            {
                return;
            }

            String repo = _folderDialog.FileName;

            if( !Git.IsRepo( repo ) )
            {
                MessageBox.Show( "Directory is not a Git repo." );
                return;
            }

            String favoriteName = InputDialog.ShowInput( "Favorite Name", "Name for \"{0}\"".XFormat( repo ), "" );
            if( favoriteName == null )
            {
                return;
            }

            bool isDirectory = Directory.Exists( repo );

            TreeNode<FavoriteRepo> newNode = new TreeNode<FavoriteRepo>( new FavoriteRepo( favoriteName, repo, isDirectory, false ) );
            if( _selectedFavoriteItem.Value.IsFavoriteFolder )
            {
                _selectedFavoriteItem.Add( newNode );
                UpdateFavoritesList( _selectedFavoriteItem );
            }
            else
            {
                _selectedFavoriteItem.Parent.Children.Insert( _selectedFavoriteItem.Index, newNode );
                UpdateFavoritesList( _selectedFavoriteItem.Parent );
            }
        }

        private void RemoveFavoriteMenuItem_Click( object sender, EventArgs e )
        {
            TreeNode<FavoriteRepo> parent = _selectedFavoriteItem.Parent;
            parent.Remove( _selectedFavoriteItem );
            UpdateFavoritesList( parent );
        }

        private void UpdateFavoritesTree( TreeNode<FavoriteRepo> selectNode )
        {
            FavoritesTree.SuspendLayout();

            FavoritesTree.Nodes.Clear();

            Add( FavoritesTree.Nodes, _root );

            FavoritesTree.ExpandAll();

            FavoritesTree.ResumeLayout();

            SelectFavorite( selectNode );
            FavoritesTree.Focus();
        }

        private void SelectFavorite( TreeNode<FavoriteRepo> selectNode )
        {
            if( selectNode.Value.IsFavoriteFolder )
            {
                FavoritesTree.SelectedNode = FindNodeByNode( selectNode );
            }
            else
            {
                FavoritesTree.SelectedNode = FindNodeByNode( selectNode.Parent );
            }
        }

        private TreeNode FindNodeByNode( TreeNode<FavoriteRepo> findNode )
        {
            return FindNodeByNode( findNode, FavoritesTree.Nodes );
        }

        private TreeNode FindNodeByNode( TreeNode<FavoriteRepo> findNode, TreeNodeCollection nodes )
        {
            foreach( TreeNode node in nodes )
            {
                if( node.Tag == findNode )
                {
                    return node;
                }
                else
                {
                    TreeNode foundNode = FindNodeByNode( findNode, node.Nodes );
                    if( foundNode != null )
                    {
                        return foundNode;
                    }
                }
            }
            return null;
        }

        private void UpdateFavoritesList( TreeNode<FavoriteRepo> node )
        {
            FavoritesList.SuspendLayout();

            FavoritesList.Items.Clear();

            if( node != null )
            {
                foreach( TreeNode<FavoriteRepo> child in node.Children )
                {
                    ListViewItem item = FavoritesList.Items.Add( child.Value.Name );
                    item.Tag = child;
                    if( child.Value.IsFavoriteFolder )
                    {
                        item.ImageKey = "FolderFolder";
                    }
                    else if( child.Value.IsDirectory )
                    {
                        item.ImageKey = "Folder";
                    }
                    else
                    {
                        item.ImageKey = "File";
                    }
                }
            }

            FavoritesList.ResumeLayout();
        }

        private void Add( TreeNodeCollection parentNodes, TreeNode<FavoriteRepo> node )
        {
            if( node.Value.IsFavoriteFolder )
            {
                TreeNode t = parentNodes.Add( node.Value.Name );
                t.ImageKey = t.SelectedImageKey = "FolderFolder";
                t.Tag = node;

                foreach( TreeNode<FavoriteRepo> child in node.Children )
                {
                    Add( t.Nodes, child );
                }
            }
        }
    }
}
