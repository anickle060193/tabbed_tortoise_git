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

        private bool Dragging { get; set; }

        private readonly CommonOpenFileDialog _folderDialog = new CommonOpenFileDialog()
        {
            IsFolderPicker = true
        };

        private readonly FavoritesDragDropHelper _favoritesDragDropHelper;

        private TreeNode<FavoriteRepo> _root;
        private TreeNode<FavoriteRepo> _lastSelectedFavoriteFolder;
        private TreeNode<FavoriteRepo> _selectedFavoriteItem;

        private FavoritesManagerDialog( TreeNode<FavoriteRepo> favorites )
        {
            InitializeComponent();

            this.Icon = Resources.TortoiseIcon;

            this.Dragging = false;

            FavoritesTree.AfterSelect += FavoritesTree_AfterSelect;
            FavoritesTree.MouseUp += FavoritesTree_MouseUp;

            FavoritesList.MouseUp += FavoritesList_MouseUp;

            FavoritesContextMenu.Opening += FavoritesContextMenu_Opening;

            CreateFavoritesFolderMenuItem.Click += CreateFavoritesFolderMenuItem_Click;

            AddFavoriteFileMenuItem.Click += AddFavoriteFileMenuItem_Click;
            AddFavoriteFolderMenuItem.Click += AddFavoriteFolderMenuItem_Click;

            EditFavoriteItemMenuItem.Click += EditFavoriteItemMenuItem_Click;

            RemoveFavoriteItemMenuItem.Click += RemoveFavoriteItemMenuItem_Click;

            FindFavoriteFileDialog.FileOk += FindFavoriteFileDialog_FileOk;

            _favoritesDragDropHelper = new FavoritesDragDropHelper( this );
            _favoritesDragDropHelper.AddControl( FavoritesTree );
            _favoritesDragDropHelper.AddControl( FavoritesList );

            _root = favorites;
            UpdateFavoritesTree( _root );
        }

        private void FavoritesTree_AfterSelect( object sender, TreeViewEventArgs e )
        {
            if( !this.Dragging )
            {
                TreeNode<FavoriteRepo> node = (TreeNode<FavoriteRepo>)e.Node.Tag;
                UpdateFavoritesList( node );
            }
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
                _selectedFavoriteItem = (TreeNode<FavoriteRepo>)( item?.Tag ?? _lastSelectedFavoriteFolder );
                if( _selectedFavoriteItem != null )
                {
                    FavoritesContextMenu.Show( FavoritesList, e.Location );
                }
            }
        }

        private void FavoritesContextMenu_Opening( object sender, CancelEventArgs e )
        {
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
        }

        private void CreateFavoritesFolderMenuItem_Click( object sender, EventArgs e )
        {
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
                    _selectedFavoriteItem.Parent.Children.Insert( _selectedFavoriteItem.Index, newNode );
                }
                UpdateFavoritesTree( _lastSelectedFavoriteFolder );
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
            String repo = null;
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
            FavoriteRepo f = _selectedFavoriteItem.Value;

            FavoriteCreatorDialog dialog = FavoriteCreatorDialog.FromFavoriteRepo( f );
            if( dialog.ShowDialog() == DialogResult.OK )
            {
                TreeNode<FavoriteRepo> newNode = new TreeNode<FavoriteRepo>( dialog.ToFavoriteRepo() );

                while( _selectedFavoriteItem.Children.Count > 0 )
                {
                    TreeNode<FavoriteRepo> child = _selectedFavoriteItem.Children[ 0 ];
                    child.Parent.Remove( child );
                    newNode.Add( child );
                }

                _selectedFavoriteItem.Parent.Children[ _selectedFavoriteItem.Index ] = newNode;

                if( newNode.Value.IsFavoriteFolder )
                {
                    UpdateFavoritesTree( newNode );
                }
                else
                {
                    UpdateFavoritesTree( newNode.Parent );
                }
            }
        }

        private void RemoveFavoriteItemMenuItem_Click( object sender, EventArgs e )
        {
            TreeNode<FavoriteRepo> parent = _selectedFavoriteItem.Parent;
            parent.Remove( _selectedFavoriteItem );

            UpdateFavoritesTree( parent );
        }

        private void UpdateFavoritesTree( TreeNode<FavoriteRepo> selectNode )
        {
            FavoritesTree.SuspendLayout();
            FavoritesTree.Nodes.Clear();
            FavoritesTreeImageList.Images.Clear();

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
                _lastSelectedFavoriteFolder = selectNode;
            }
            else
            {
                _lastSelectedFavoriteFolder = selectNode.Parent;
            }
            FavoritesTree.SelectedNode = FindNodeByNode( _lastSelectedFavoriteFolder );
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
            FavoritesListImageList.Images.Clear();

            if( node != null )
            {
                foreach( TreeNode<FavoriteRepo> child in node.Children )
                {
                    ListViewItem item = FavoritesList.Items.Add( child.Value.Name );
                    item.Tag = child;

                    Color favoriteColor = child.Value.Color;
                    String imageKey = favoriteColor.ToString();
                    Bitmap icon;
                    if( child.Value.IsFavoriteFolder )
                    {
                        icon = Resources.FolderFolder;
                        imageKey += " FolderFolder";
                    }
                    else if( child.Value.IsDirectory )
                    {
                        icon = Resources.Folder;
                        imageKey += " Folder";
                    }
                    else
                    {
                        icon = Resources.File;
                        imageKey += " File";
                    }
                    if( !FavoritesListImageList.Images.ContainsKey( imageKey ) )
                    {
                        FavoritesListImageList.Images.Add( imageKey, Util.ColorBitmap( icon, favoriteColor ) );
                    }

                    item.ImageKey = imageKey;
                }
            }

            FavoritesList.ResumeLayout();
        }

        private void Add( TreeNodeCollection parentNodes, TreeNode<FavoriteRepo> node )
        {
            if( node.Value.IsFavoriteFolder )
            {
                Color favoriteColor = node.Value.Color;
                String imageKey = favoriteColor.ToString() + " FolderFolder";
                if( !FavoritesTreeImageList.Images.ContainsKey( imageKey ) )
                {
                    FavoritesTreeImageList.Images.Add( imageKey, Util.ColorBitmap( Resources.FolderFolder, favoriteColor ) );
                }
                TreeNode t = parentNodes.Add( node.Value.Name );
                t.ImageKey = t.SelectedImageKey = imageKey;
                t.Tag = node;

                foreach( TreeNode<FavoriteRepo> child in node.Children )
                {
                    Add( t.Nodes, child );
                }
            }
        }

        private void AddFavoriteItem( String path )
        {
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
                    UpdateFavoritesList( _selectedFavoriteItem );
                }
                else
                {
                    _selectedFavoriteItem.Parent.Children.Insert( _selectedFavoriteItem.Index, newNode );
                    UpdateFavoritesList( _selectedFavoriteItem.Parent );
                }
            }
        }

        class FavoritesDragDropHelper : DragDropHelper<Control, TreeNode<FavoriteRepo>>
        {
            private readonly FavoritesManagerDialog _owner;

            public FavoritesDragDropHelper( FavoritesManagerDialog owner )
            {
                _owner = owner;

                MoveOnDragDrop = true;
            }

            protected override bool AllowDrag( Control parent, TreeNode<FavoriteRepo> item, int index )
            {
                if( parent is TreeView )
                {
                    return item != _owner._root;
                }
                else if( parent is ListView )
                {
                    return item != null;
                }
                else
                {
                    throw new ArgumentException( "Parent must be either TreeView or ListView." );
                }
            }

            protected override bool GetItemFromPoint( Control parent, Point p, out TreeNode<FavoriteRepo> item, out int itemIndex )
            {
                if( parent is TreeView )
                {
                    TreeView favoritesTree = (TreeView)parent;
                    TreeNode treeNode = favoritesTree.GetNodeAt( p );
                    item = (TreeNode<FavoriteRepo>)treeNode?.Tag;
                    itemIndex = item?.NestedIndex ?? 0;
                    return item != null;
                }
                else if( parent is ListView )
                {
                    ListView favoritesList = (ListView)parent;
                    ListViewItem listViewItem = favoritesList.GetItemAt( p.X, p.Y );
                    if( listViewItem == null )
                    {
                        item = null;
                        itemIndex = -2;
                        return true;
                    }
                    else
                    {
                        item = (TreeNode<FavoriteRepo>)listViewItem.Tag;
                        itemIndex = item.Index;
                        return true;
                    }
                }
                else
                {
                    throw new ArgumentException( "Parent must be either TreeView or ListView." );
                }
            }

            protected override void OnDragStart( DragStartEventArgs<Control, TreeNode<FavoriteRepo>> e )
            {
                base.OnDragStart( e );

                _owner.Dragging = true;
            }

            protected override void OnDragMove( DragMoveEventArgs<Control, TreeNode<FavoriteRepo>> e )
            {
                if( e.DragParent is TreeView )
                {
                    TreeView favoritesTree = (TreeView)e.DragParent;
                    TreeNode node = favoritesTree.GetNodeAt( e.DragParent.PointToClient( e.DragCurrentPosition ) );
                    if( node != null )
                    {
                        favoritesTree.SelectedNode = node;
                    }
                }
                else if( e.DragParent is ListView )
                {
                    ListView favoritesList = (ListView)e.DragParent;
                    favoritesList.SelectedItems.Clear();
                    Point p = favoritesList.PointToClient( e.DragCurrentPosition );
                    ListViewItem listViewItem = favoritesList.GetItemAt( p.X, p.Y );
                    if( listViewItem != null )
                    {
                        listViewItem.Selected = true;
                    }
                }
                else
                {
                    throw new ArgumentException( "Parent must be either TreeView or ListView." );
                }
            }

            protected override void OnDragEnd( DragEndEventArgs<Control, TreeNode<FavoriteRepo>> e )
            {
                base.OnDragEnd( e );

                _owner.Dragging = false;
            }

            protected override bool MoveItem( Control dragParent, TreeNode<FavoriteRepo> dragItem, int dragItemIndex, Control pointedParent, TreeNode<FavoriteRepo> pointedItem, int pointedItemIndex )
            {
                if( dragParent == pointedParent )
                {
                    if( dragParent is TreeView )
                    {
                        if( dragItem.NestedContains( pointedItem )
                         || pointedItem == dragItem.Parent
                         || pointedItem == dragItem
                         || !pointedItem.Value.IsFavoriteFolder )
                        {
                            return false;
                        }

                        dragItem.Parent.Remove( dragItem );
                        pointedItem.Add( dragItem );

                        _owner.Dragging = false;
                        _owner.UpdateFavoritesTree( pointedItem );

                        return true;
                    }
                    else if( dragParent is ListView )
                    {
                        if( pointedItemIndex == -2 )
                        {
                            TreeNode<FavoriteRepo> parent = dragItem.Parent;
                            parent.Remove( dragItem );
                            parent.Add( dragItem );
                        }
                        else
                        {
                            int newIndex = dragItemIndex < pointedItemIndex ? pointedItemIndex - 1 : pointedItemIndex;
                            dragItem.Parent.Remove( dragItem );
                            pointedItem.Parent.Children.Insert( newIndex, dragItem );
                        }

                        _owner.Dragging = false;
                        _owner.UpdateFavoritesTree( dragItem.Parent );

                        return true;
                    }
                    else
                    {
                        throw new ArgumentException( "Parents must be either TreeView or ListView." );
                    }
                }
                else if( dragParent is ListView )
                {
                    if( dragItem.NestedContains( pointedItem )
                     || pointedItem == dragItem.Parent
                     || pointedItem == dragItem
                     || !pointedItem.Value.IsFavoriteFolder )
                    {
                        return false;
                    }

                    dragItem.Parent.Remove( dragItem );
                    pointedItem.Add( dragItem );

                    _owner.Dragging = false;
                    _owner.UpdateFavoritesTree( pointedItem );

                    return true;
                }

                return false;
            }
        }
    }
}
