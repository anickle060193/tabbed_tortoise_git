#nullable enable

using Common;
using log4net;
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
        private static readonly ILog LOG = LogManager.GetLogger( typeof( FavoritesManagerDialog ) );

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

        private readonly FavoritesDragDropHelper _favoritesDragDropHelper;

        private TreeNode<FavoriteRepo> _root;
        private TreeNode<FavoriteRepo>? _selectedFavoriteItem;

        private FavoritesManagerDialog( TreeNode<FavoriteRepo> favorites )
        {
            InitializeComponent();

            this.Icon = Resources.TortoiseIcon;

            FavoritesTree.MouseUp += FavoritesTree_MouseUp;

            FavoritesContextMenu.Opening += FavoritesContextMenu_Opening;

            CreateFavoritesFolderMenuItem.Click += CreateFavoritesFolderMenuItem_Click;

            AddFavoriteFileMenuItem.Click += AddFavoriteFileMenuItem_Click;
            AddFavoriteFolderMenuItem.Click += AddFavoriteFolderMenuItem_Click;

            EditFavoriteItemMenuItem.Click += EditFavoriteItemMenuItem_Click;

            RemoveFavoriteItemMenuItem.Click += RemoveFavoriteItemMenuItem_Click;

            FindFavoriteFileDialog.FileOk += FindFavoriteFileDialog_FileOk;

            _favoritesDragDropHelper = new FavoritesDragDropHelper( this );
            _favoritesDragDropHelper.AddControl( FavoritesTree );

            _root = favorites;
            UpdateFavoritesTree( _root );
        }

        private void FavoritesTree_MouseUp( object sender, MouseEventArgs e )
        {
            if( e.Button == MouseButtons.Right )
            {
                TreeNode node = FavoritesTree.GetNodeAt( e.Location );
                FavoritesTree.SelectedNode = node;
                _selectedFavoriteItem = node?.Tag as TreeNode<FavoriteRepo> ?? _root;
                if( _selectedFavoriteItem != null )
                {
                    FavoritesContextMenu.Show( FavoritesTree, e.Location );
                }
            }
        }

        private void FavoritesContextMenu_Opening( object sender, CancelEventArgs e )
        {
            if( _selectedFavoriteItem == null )
            {
                throw new InvalidOperationException( "No selected favorite item." );
            }

            if( _selectedFavoriteItem == _root )
            {
                EditFavoriteItemMenuItem.Enabled = false;
                RemoveFavoriteItemMenuItem.Enabled = false;
            }
            else
            {
                EditFavoriteItemMenuItem.Enabled = true;
                RemoveFavoriteItemMenuItem.Enabled = true;
            }

            if( _selectedFavoriteItem.Value.IsFavoriteFolder )
            {
                CreateFavoritesFolderMenuItem.Text = "Add Folder";

                AddFavoriteFileMenuItem.Text = "Add Favorite File";
                AddFavoriteFolderMenuItem.Text = "Add Favorite Folder";
            }
            else
            {
                CreateFavoritesFolderMenuItem.Text = "Insert Folder";

                AddFavoriteFileMenuItem.Text = "Insert Favorite File";
                AddFavoriteFolderMenuItem.Text = "Insert Favorite Folder";
            }
        }

        private void CreateFavoritesFolderMenuItem_Click( object sender, EventArgs e )
        {
            if( _selectedFavoriteItem == null )
            {
                throw new InvalidOperationException( "No selected favorite item." );
            }

            FavoriteCreatorDialog dialog = new FavoriteCreatorDialog( true );
            if( dialog.ShowDialog() == DialogResult.OK )
            {
                TreeNode<FavoriteRepo> newNode = new TreeNode<FavoriteRepo>( dialog.ToFavoriteRepo() );
                if( _selectedFavoriteItem.Value.IsFavoriteFolder )
                {
                    _selectedFavoriteItem.Add( newNode );
                }
                else
                {
                    _selectedFavoriteItem.Parent!.Children.Insert( _selectedFavoriteItem.Index, newNode );
                }
                UpdateFavoritesTree( newNode );
            }
        }

        private void AddFavoriteFileMenuItem_Click( object sender, EventArgs e )
        {
            if( FindFavoriteFileDialog.ShowDialog() == DialogResult.OK )
            {
                if( Git.IsInRepo( FindFavoriteFileDialog.FileName ) )
                {
                    AddFavoriteItem( FindFavoriteFileDialog.FileName );
                }
            }
        }

        private void FindFavoriteFileDialog_FileOk( object sender, CancelEventArgs e )
        {
            if( !Git.IsInRepo( FindFavoriteFileDialog.FileName  ))
            {
                MessageBox.Show( "File is not in a Git repo.", "Not a Git Repo", MessageBoxButtons.OK, MessageBoxIcon.Error );
                e.Cancel = true;
            }
        }

        private void AddFavoriteFolderMenuItem_Click( object sender, EventArgs e )
        {
            String? repo = null;
            while( repo == null )
            {
                if( _folderDialog.ShowDialog() != CommonFileDialogResult.Ok )
                {
                    return;
                }

                if( !Git.IsInRepo( _folderDialog.FileName ) )
                {
                    MessageBox.Show( "Directory is not a Git repo.", "Invalid Directory", MessageBoxButtons.OK );
                }
                else
                {
                    repo = _folderDialog.FileName;
                }
            }

            AddFavoriteItem( repo );
        }

        private void EditFavoriteItemMenuItem_Click( object sender, EventArgs e )
        {
            if( _selectedFavoriteItem == null )
            {
                throw new InvalidOperationException( "No selected favorite item." );
            }

            FavoriteRepo f = _selectedFavoriteItem.Value;

            FavoriteCreatorDialog dialog = FavoriteCreatorDialog.FromFavoriteRepo( f );
            if( dialog.ShowDialog() == DialogResult.OK )
            {
                TreeNode<FavoriteRepo> newNode = new TreeNode<FavoriteRepo>( dialog.ToFavoriteRepo() );

                while( _selectedFavoriteItem.Children.Count > 0 )
                {
                    TreeNode<FavoriteRepo> child = _selectedFavoriteItem.Children[ 0 ];
                    child.Parent!.Remove( child );
                    newNode.Add( child );
                }

                _selectedFavoriteItem.Parent!.Children[ _selectedFavoriteItem.Index ] = newNode;

                UpdateFavoritesTree( newNode );
            }
        }

        private void RemoveFavoriteItemMenuItem_Click( object sender, EventArgs e )
        {
            if( _selectedFavoriteItem == null )
            {
                throw new InvalidOperationException( "No selected favorite item." );
            }

            TreeNode<FavoriteRepo> parent = _selectedFavoriteItem.Parent!;
            parent.Remove( _selectedFavoriteItem );

            UpdateFavoritesTree( parent );
        }

        private void UpdateFavoritesTree( TreeNode<FavoriteRepo> selectNode )
        {
            FavoritesTree.SuspendLayout();

            FavoritesTree.Nodes.Clear();
            FavoritesTreeImageList.Images.Clear();

            AddToTreeView( FavoritesTree.Nodes, _root );

            FavoritesTree.ExpandAll();

            FavoritesTree.ResumeLayout();

            FavoritesTree.SelectedNode = FindNodeByNode( selectNode );
        }

        private void UpdateInsertionMark( TreeNode<FavoriteRepo> favorite, bool before )
        {
            if( favorite != null )
            {
                TreeNode? node = this.FindNodeByNode( favorite );
                if( node != null )
                {
                    if( before )
                    {
                        Native.PostMessage( FavoritesTree.Handle, 0x111A, (IntPtr)0, node.Handle );
                        return;
                    }
                    else
                    {
                        Native.PostMessage( FavoritesTree.Handle, 0x111A, (IntPtr)1, node.Handle );
                        return;
                    }
                }
            }
            ClearInsertionMark();
        }

        private void ClearInsertionMark()
        {
            Native.PostMessage( FavoritesTree.Handle, 0x111A, (IntPtr)0, IntPtr.Zero );
        }

        private TreeNode? FindNodeByNode( TreeNode<FavoriteRepo> findNode )
        {
            return FindNodeByNode( findNode, FavoritesTree.Nodes );
        }

        private TreeNode? FindNodeByNode( TreeNode<FavoriteRepo> findNode, TreeNodeCollection nodes )
        {
            foreach( TreeNode node in nodes )
            {
                if( node.Tag == findNode )
                {
                    return node;
                }
                else
                {
                    TreeNode? foundNode = FindNodeByNode( findNode, node.Nodes );
                    if( foundNode != null )
                    {
                        return foundNode;
                    }
                }
            }
            return null;
        }

        private void AddToTreeView( TreeNodeCollection parentNodes, TreeNode<FavoriteRepo> node )
        {
            TreeNode t = parentNodes.Add( node.Value.Name );
            t.Tag = node;

            Color favoriteColor = node.Value.Color;
            String imageKey;
            Bitmap icon;

            if( node.Value.IsFavoriteFolder )
            {
                imageKey = "FolderFolder";
                icon = Resources.FolderFolder;
            }
            else if( node.Value.IsDirectory )
            {
                imageKey = "Folder";
                icon = Resources.Folder;
            }
            else
            {
                imageKey = "File";
                icon = Resources.File;
            }

            imageKey = favoriteColor.ToString() + imageKey;
            if( !FavoritesTreeImageList.Images.ContainsKey( imageKey ) )
            {
                FavoritesTreeImageList.Images.Add( imageKey, Util.ColorBitmap( icon, favoriteColor ) );
            }
            t.ImageKey = t.SelectedImageKey = imageKey;

            if( node.Value.IsFavoriteFolder )
            {
                foreach( TreeNode<FavoriteRepo> child in node.Children )
                {
                    AddToTreeView( t.Nodes, child );
                }
            }
        }

        private void AddFavoriteItem( String path )
        {
            if( _selectedFavoriteItem == null )
            {
                throw new InvalidOperationException( "No selected favorite item." );
            }

            FavoriteCreatorDialog dialog = new FavoriteCreatorDialog( false )
            {
                FavoriteRepo = path
            };
            if( dialog.ShowDialog() == DialogResult.OK )
            {
                TreeNode<FavoriteRepo> newNode = new TreeNode<FavoriteRepo>( dialog.ToFavoriteRepo() );
                if( _selectedFavoriteItem.Value.IsFavoriteFolder )
                {
                    _selectedFavoriteItem.Add( newNode );
                }
                else
                {
                    _selectedFavoriteItem.Parent!.Children.Insert( _selectedFavoriteItem.Index, newNode );
                }

                UpdateFavoritesTree( newNode );
            }
        }

        class FavoritesDraggingItem
        {
            public TreeNode<FavoriteRepo> Favorite { get; private set; }
            public bool Before { get; private set; }

            public FavoritesDraggingItem( TreeNode<FavoriteRepo> favorite, bool before )
            {
                Favorite = favorite;
                Before = before;
            }
        }

        class FavoritesDragDropHelper : DragDropHelper<TreeView, FavoritesDraggingItem>
        {
            private readonly FavoritesManagerDialog _owner;

            public FavoritesDragDropHelper( FavoritesManagerDialog owner )
            {
                _owner = owner;

                MoveOnDragDrop = true;
            }

            protected override bool AllowDrag( TreeView parent, FavoritesDraggingItem item, int index )
            {
                return item.Favorite != _owner._root;
            }

            private bool IsBefore( Rectangle bounds, Point p )
            {
                if( p.Y < bounds.Top + bounds.Height / 2 )
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

            protected override bool GetItemFromPoint( TreeView parent, Point p, out FavoritesDraggingItem? item, out int itemIndex )
            {
                TreeNode? treeNode = parent.GetNodeAt( p );

                if( treeNode == null )
                {
                    item = null;
                    itemIndex = -1;
                    return false;
                }
                else
                {
                    TreeNode<FavoriteRepo> favorite = (TreeNode<FavoriteRepo>)treeNode.Tag;
                    item = new FavoritesDraggingItem( favorite, IsBefore( treeNode.Bounds, p ) );
                    itemIndex = favorite.NestedIndex;
                    return true;
                }
            }

            protected override bool ItemsEqual( TreeView parent1, FavoritesDraggingItem item1, int itemIndex1, TreeView parent2, FavoritesDraggingItem item2, int itemIndex2 )
            {
                return item1.Favorite == item2.Favorite;
            }

            protected override void OnDragEnd( DragEndEventArgs<TreeView, FavoritesDraggingItem> e )
            {
                base.OnDragEnd( e );

                _owner.ClearInsertionMark();
            }

            protected override bool AllowDrop( TreeView dragParent, FavoritesDraggingItem dragItem, int dragItemIndex, TreeView pointedParent, FavoritesDraggingItem pointedItem, int pointedItemIndex )
            {
                TreeNode<FavoriteRepo> dragFavorite = dragItem.Favorite;
                TreeNode<FavoriteRepo> pointedFavorite = pointedItem.Favorite;

                bool allowDrop;

                if( pointedFavorite == _owner._root )
                {
                    allowDrop = false;
                }
                else if( pointedFavorite == dragFavorite
                      || dragFavorite.NestedContains( pointedFavorite ) )
                {
                    allowDrop = false;
                }
                else if( pointedItem.Before
                      && pointedFavorite.Previous == dragFavorite )
                {
                    allowDrop = false;
                }
                else if( !pointedItem.Before
                      && pointedFavorite.Next == dragFavorite )
                {
                    allowDrop = false;
                }
                else
                {
                    allowDrop = true;
                }

                if( allowDrop )
                {
                    _owner.UpdateInsertionMark( pointedFavorite, pointedItem.Before );
                }
                else
                {
                    _owner.ClearInsertionMark();
                }

                return allowDrop;
            }

            protected override void MoveItem( TreeView dragParent, FavoritesDraggingItem dragItem, int dragItemIndex, TreeView pointedParent, FavoritesDraggingItem pointedItem, int pointedItemIndex )
            {
                TreeNode<FavoriteRepo> dragFavorite = dragItem.Favorite;
                TreeNode<FavoriteRepo> pointedFavorite = pointedItem.Favorite;

                if( pointedItem.Before )
                {
                    dragFavorite.Parent!.Remove( dragFavorite );
                    pointedFavorite.Parent!.Children.Insert( pointedFavorite.Index, dragFavorite );
                }
                else
                {
                    dragFavorite.Parent!.Remove( dragFavorite );
                    pointedFavorite.Parent!.Children.Insert( pointedFavorite.Index + 1, dragFavorite );
                }

                _owner.UpdateFavoritesTree( dragFavorite );
            }
        }
    }
}
