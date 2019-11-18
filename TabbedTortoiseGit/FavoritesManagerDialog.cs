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
        private static readonly ILog LOG = LogManager.GetLogger( nameof( FavoritesManagerDialog ) );

        public static bool ShowFavoritesManager()
        {
            using FavoritesManagerDialog dialog = new FavoritesManagerDialog( Settings.Default.FavoriteRepos );
            if( dialog.ShowDialog() == DialogResult.OK )
            {
                Settings.Default.FavoriteRepos = dialog.Favorites;
                Settings.Default.Save();
                return true;
            }
            else
            {
                return false;
            }
        }

        public FavoriteFolder Favorites { get; }

        private Favorite? _selectedFavoriteItem;
        private readonly FavoritesDragDropHelper _favoritesDragDropHelper;

        private FavoritesManagerDialog( FavoriteFolder favorites )
        {
            InitializeComponent();

            this.Icon = Resources.TortoiseIcon;

            FavoritesTree.MouseUp += FavoritesTree_MouseUp;

            FavoritesContextMenu.Opening += FavoritesContextMenu_Opening;

            AddFavoritesFolderMenuItem.Click += AddFavoritesFolderMenuItem_Click;
            AddRepoMenuItem.Click += AddRepoMenuItem_Click;
            AddReposDirectoryMenuItem.Click += AddReposDirectoryMenuItem_Click;

            EditFavoriteMenuItem.Click += EditFavoriteMenuItem_Click;
            RemoveFavoriteMenuItem.Click += RemoveFavoriteMenuItem_Click;

            _favoritesDragDropHelper = new FavoritesDragDropHelper( this );
            _favoritesDragDropHelper.AddControl( FavoritesTree );

            Favorites = favorites;
            UpdateFavoritesTree( Favorites );
        }

        private void FavoritesTree_MouseUp( object sender, MouseEventArgs e )
        {
            if( e.Button == MouseButtons.Right )
            {
                TreeNode node = FavoritesTree.GetNodeAt( e.Location );
                FavoritesTree.SelectedNode = node;
                _selectedFavoriteItem = node?.Tag as Favorite ?? Favorites;
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
                LOG.Error( $"{nameof( FavoritesContextMenu_Opening )} - Selected favorite is null" );
                return;
            }

            if( _selectedFavoriteItem == Favorites )
            {
                EditFavoriteMenuItem.Enabled = false;
                RemoveFavoriteMenuItem.Enabled = false;
            }
            else
            {
                EditFavoriteMenuItem.Enabled = true;
                RemoveFavoriteMenuItem.Enabled = true;
            }

            if( _selectedFavoriteItem is FavoriteFolder )
            {
                AddFavoritesFolderMenuItem.Text = "Add Favorites Folder";

                AddRepoMenuItem.Text = "Add Repo";
                AddReposDirectoryMenuItem.Text = "Add Repos Folder";
            }
            else
            {
                AddFavoritesFolderMenuItem.Text = "Insert Favorites Folder";

                AddRepoMenuItem.Text = "Insert Repo";
                AddReposDirectoryMenuItem.Text = "Insert Repos Folder";
            }
        }

        private void AddFavorite( Favorite newFavorite )
        {
            if( _selectedFavoriteItem == null )
            {
                LOG.Error( $"{nameof( AddFavorite )} - Selected favorite is null" );
                return;
            }

            if( _selectedFavoriteItem is FavoriteFolder ff )
            {
                ff.Children.Add( newFavorite );

                UpdateFavoritesTree( newFavorite );
            }
            else
            {
                if( !Favorites.InsertBefore( _selectedFavoriteItem, newFavorite ) )
                {
                    LOG.Error( $"{nameof( AddFavoritesFolderMenuItem_Click )} - Failed to insert new favorite: {_selectedFavoriteItem} - {newFavorite}" );
                    return;
                }

                UpdateFavoritesTree( newFavorite );
            }
        }

        private void AddFavoritesFolderMenuItem_Click( object sender, EventArgs e )
        {
            using FavoriteFolderCreatorDialog dialog = new FavoriteFolderCreatorDialog();
            if( dialog.ShowDialog() == DialogResult.OK )
            {
                AddFavorite( dialog.ToFavoriteFolder() );
            }
        }

        private void AddRepoMenuItem_Click( object sender, EventArgs e )
        {
            using FavoriteRepoCreatorDialog dialog = new FavoriteRepoCreatorDialog();
            if( dialog.ShowDialog() == DialogResult.OK )
            {
                AddFavorite( dialog.ToFavoriteRepo() );
            }
        }

        private void AddReposDirectoryMenuItem_Click( object sender, EventArgs e )
        {
            using FavoriteReposDirectoryCreatorDialog dialog = new FavoriteReposDirectoryCreatorDialog();
            if( dialog.ShowDialog() == DialogResult.OK )
            {
                AddFavorite( dialog.ToFavoriteReposDirectory() );
            }
        }

        private void EditFavoriteMenuItem_Click( object sender, EventArgs e )
        {
            if( _selectedFavoriteItem == null )
            {
                LOG.Error( $"{nameof( EditFavoriteMenuItem_Click )} - Selected favorite is null" );
                return;
            }

            Favorite? newFavorite = null;
            if( _selectedFavoriteItem is FavoriteFolder folder )
            {
                using FavoriteFolderCreatorDialog dialog = FavoriteFolderCreatorDialog.FromFavoriteFolder( folder );
                if( dialog.ShowDialog() == DialogResult.OK )
                {
                    newFavorite = dialog.ToFavoriteFolder();
                }
            }
            else if( _selectedFavoriteItem is FavoriteRepo repo )
            {
                using FavoriteRepoCreatorDialog dialog = FavoriteRepoCreatorDialog.FromFavoriteRepo( repo );
                if( dialog.ShowDialog() == DialogResult.OK )
                {
                    newFavorite = dialog.ToFavoriteRepo();
                }
            }
            else if( _selectedFavoriteItem is FavoriteReposDirectory directory )
            {
                using FavoriteReposDirectoryCreatorDialog dialog = FavoriteReposDirectoryCreatorDialog.FromFavoriteReposDirectory( directory );
                if( dialog.ShowDialog() == DialogResult.OK )
                {
                    newFavorite = dialog.ToFavoriteReposDirectory();
                }
            }
            else
            {
                LOG.Error( $"{nameof( EditFavoriteMenuItem_Click )} - Unknown favorite type: {_selectedFavoriteItem}" );
            }

            if( newFavorite != null )
            {
                if( !Favorites.Replace( _selectedFavoriteItem, newFavorite ) )
                {
                    LOG.Error( $"{nameof( EditFavoriteMenuItem_Click )} - Failed to replace old favorite: {_selectedFavoriteItem} - {newFavorite}" );
                    return;
                }

                UpdateFavoritesTree( newFavorite );
            }
        }

        private void RemoveFavoriteMenuItem_Click( object sender, EventArgs e )
        {
            if( _selectedFavoriteItem == null )
            {
                LOG.Error( $"{nameof( RemoveFavoriteMenuItem_Click )} - Selected favorite is null" );
                return;
            }

            FavoriteFolder? parent = Favorites.FindParent( _selectedFavoriteItem );

            if( !Favorites.Remove( _selectedFavoriteItem ) )
            {
                LOG.Error( $"{nameof( RemoveFavoriteMenuItem_Click )} - Unknown to remove favorite: {_selectedFavoriteItem}" );
                return;
            }

            UpdateFavoritesTree( parent );
        }

        private void UpdateFavoritesTree( Favorite? selectedFavorite )
        {
            FavoritesTree.SuspendLayout();

            FavoritesTree.Nodes.Clear();
            FavoritesTreeImageList.Images.Clear();

            AddToTreeView( FavoritesTree.Nodes, Favorites );

            FavoritesTree.ExpandAll();

            FavoritesTree.ResumeLayout();

            if( selectedFavorite is null )
            {
                FavoritesTree.SelectedNode = null;
            }
            else
            {
                FavoritesTree.SelectedNode = FindTreeNodeByFavorite( selectedFavorite );
            }
        }

        private TreeNode? FindTreeNodeByFavorite( Favorite findNode )
        {
            return FindTreeNodeByFavorite( findNode, FavoritesTree.Nodes );
        }

        private TreeNode? FindTreeNodeByFavorite( Favorite findNode, TreeNodeCollection nodes )
        {
            foreach( TreeNode node in nodes )
            {
                if( node.Tag == findNode )
                {
                    return node;
                }
                else
                {
                    TreeNode? foundNode = FindTreeNodeByFavorite( findNode, node.Nodes );
                    if( foundNode != null )
                    {
                        return foundNode;
                    }
                }
            }
            return null;
        }

        private void AddToTreeView( TreeNodeCollection parentNodes, Favorite favorite )
        {
            TreeNode node = parentNodes.Add( favorite.Name );
            node.Tag = favorite;

            Color favoriteColor = favorite.Color;
            String imageKey;
            Bitmap icon;

            if( favorite is FavoriteFolder )
            {
                imageKey = "FolderFolder";
                icon = Resources.FolderFolder;
            }
            else if( favorite is FavoriteRepo f )
            {
                if( f.IsDirectory )
                {
                    imageKey = "Folder";
                    icon = Resources.Folder;
                }
                else
                {
                    imageKey = "File";
                    icon = Resources.File;
                }
            }
            else if( favorite is FavoriteReposDirectory )
            {
                imageKey = "SymLink";
                icon = Resources.SymLink;
            }
            else
            {
                throw new ArgumentException( $"Unkown favorite type: {favorite}" );
            }

            imageKey = favoriteColor.ToString() + imageKey;
            if( !FavoritesTreeImageList.Images.ContainsKey( imageKey ) )
            {
                FavoritesTreeImageList.Images.Add( imageKey, Util.ColorBitmap( icon, favoriteColor ) );
            }
            node.ImageKey = node.SelectedImageKey = imageKey;

            if( favorite is FavoriteFolder folder )
            {
                foreach( Favorite child in folder.Children )
                {
                    AddToTreeView( node.Nodes, child );
                }
            }
        }

        private void UpdateInsertionMark( Favorite favorite, bool before )
        {
            if( favorite != null )
            {
                TreeNode? node = this.FindTreeNodeByFavorite( favorite );
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

        class FavoritesDraggingItem
        {
            public Favorite Favorite { get; private set; }
            public bool Before { get; private set; }

            public FavoritesDraggingItem( Favorite favorite, bool before )
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
                return item.Favorite != _owner.Favorites;
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
                    Favorite favorite = (Favorite)treeNode.Tag;
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
                Favorite dragFavorite = dragItem.Favorite;
                Favorite pointedFavorite = pointedItem.Favorite;

                bool allowDrop;

                if( pointedFavorite == _owner.Favorites )
                {
                    allowDrop = false;
                }
                else if( pointedFavorite == dragFavorite
                    || ( dragFavorite is FavoriteFolder ff
                      && ff.NestedContains( pointedFavorite ) ) )
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
                Favorite dragFavorite = dragItem.Favorite;
                Favorite pointedFavorite = pointedItem.Favorite;

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
