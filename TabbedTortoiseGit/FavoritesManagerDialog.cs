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
        public static bool ShowFavoritesManager()
        {
            using FavoritesManagerDialog dialog = new FavoritesManagerDialog( Settings.Default.FavoriteRepos );
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

        public FavoriteFolder Favorites { get; }

        private readonly CommonOpenFileDialog _folderDialog = new CommonOpenFileDialog()
        {
            IsFolderPicker = true
        };

        //private readonly FavoritesDragDropHelper _favoritesDragDropHelper;
        //private Favorite? _selectedFavoriteItem;

        private FavoritesManagerDialog( FavoriteFolder favorites )
        {
            InitializeComponent();

            this.Icon = Resources.TortoiseIcon;

            //FavoritesTree.MouseUp += FavoritesTree_MouseUp;

            //FavoritesContextMenu.Opening += FavoritesContextMenu_Opening;

            //CreateFavoritesFolderMenuItem.Click += CreateFavoritesFolderMenuItem_Click;

            //AddFavoriteFileMenuItem.Click += AddFavoriteFileMenuItem_Click;
            //AddFavoriteFolderMenuItem.Click += AddFavoriteFolderMenuItem_Click;

            //EditFavoriteItemMenuItem.Click += EditFavoriteItemMenuItem_Click;

            //RemoveFavoriteItemMenuItem.Click += RemoveFavoriteItemMenuItem_Click;

            //FindFavoriteFileDialog.FileOk += FindFavoriteFileDialog_FileOk;

            //_favoritesDragDropHelper = new FavoritesDragDropHelper( this );
            //_favoritesDragDropHelper.AddControl( FavoritesTree );

            Favorites = favorites;
            UpdateFavoritesTree( Favorites );
        }

        //private void FavoritesTree_MouseUp( object sender, MouseEventArgs e )
        //{
        //    if( e.Button == MouseButtons.Right )
        //    {
        //        TreeNode node = FavoritesTree.GetNodeAt( e.Location );
        //        FavoritesTree.SelectedNode = node;
        //        _selectedFavoriteItem = node?.Tag as Favorite ?? Favorites;
        //        if( _selectedFavoriteItem != null )
        //        {
        //            FavoritesContextMenu.Show( FavoritesTree, e.Location );
        //        }
        //    }
        //}

        //private void FavoritesContextMenu_Opening( object sender, CancelEventArgs e )
        //{
        //    if( _selectedFavoriteItem == null )
        //    {
        //        throw new InvalidOperationException( "No selected favorite item." );
        //    }

        //    if( _selectedFavoriteItem == Favorites )
        //    {
        //        EditFavoriteItemMenuItem.Enabled = false;
        //        RemoveFavoriteItemMenuItem.Enabled = false;
        //    }
        //    else
        //    {
        //        EditFavoriteItemMenuItem.Enabled = true;
        //        RemoveFavoriteItemMenuItem.Enabled = true;
        //    }

        //    if( _selectedFavoriteItem is FavoriteFolder )
        //    {
        //        CreateFavoritesFolderMenuItem.Text = "Add Folder";

        //        AddFavoriteFileMenuItem.Text = "Add Favorite File";
        //        AddFavoriteFolderMenuItem.Text = "Add Favorite Folder";
        //    }
        //    else
        //    {
        //        CreateFavoritesFolderMenuItem.Text = "Insert Folder";

        //        AddFavoriteFileMenuItem.Text = "Insert Favorite File";
        //        AddFavoriteFolderMenuItem.Text = "Insert Favorite Folder";
        //    }
        //}

        //private void CreateFavoritesFolderMenuItem_Click( object sender, EventArgs e )
        //{
        //    if( _selectedFavoriteItem == null )
        //    {
        //        throw new InvalidOperationException( "No selected favorite item." );
        //    }
        //    else if( !( _selectedFavoriteItem is FavoriteFolder ) )
        //    {
        //        throw new InvalidOperationException( "Canot add favorite item to non-folder." );
        //    }

        //    FavoriteFolder selectedFolder = (FavoriteFolder)_selectedFavoriteItem;

        //    using FavoriteFolderCreatorDialog dialog = new FavoriteFolderCreatorDialog();
        //    if( dialog.ShowDialog() == DialogResult.OK )
        //    {
        //        FavoriteFolder newNode = dialog.ToFavoriteFolder();
        //        if( _selectedFavoriteItem.Value.IsFavoriteFolder )
        //        {
        //            _selectedFavoriteItem.Add( newNode );
        //        }
        //        else
        //        {
        //            _selectedFavoriteItem.Parent!.Children.Insert( _selectedFavoriteItem.Index, newNode );
        //        }
        //        UpdateFavoritesTree( newNode );
        //    }
        //}

        //private void AddFavoriteFileMenuItem_Click( object sender, EventArgs e )
        //{
        //    if( FindFavoriteFileDialog.ShowDialog() == DialogResult.OK )
        //    {
        //        if( Git.IsInRepo( FindFavoriteFileDialog.FileName ) )
        //        {
        //            AddFavoriteItem( FindFavoriteFileDialog.FileName );
        //        }
        //    }
        //}

        //private void FindFavoriteFileDialog_FileOk( object sender, CancelEventArgs e )
        //{
        //    if( !Git.IsInRepo( FindFavoriteFileDialog.FileName  ))
        //    {
        //        MessageBox.Show( "File is not in a Git repo.", "Not a Git Repo", MessageBoxButtons.OK, MessageBoxIcon.Error );
        //        e.Cancel = true;
        //    }
        //}

        //private void AddFavoriteFolderMenuItem_Click( object sender, EventArgs e )
        //{
        //    String? repo = null;
        //    while( repo == null )
        //    {
        //        if( _folderDialog.ShowDialog() != CommonFileDialogResult.Ok )
        //        {
        //            return;
        //        }

        //        if( !Git.IsInRepo( _folderDialog.FileName ) )
        //        {
        //            MessageBox.Show( "Directory is not a Git repo.", "Invalid Directory", MessageBoxButtons.OK );
        //        }
        //        else
        //        {
        //            repo = _folderDialog.FileName;
        //        }
        //    }

        //    AddFavoriteItem( repo );
        //}

        //private void EditFavoriteItemMenuItem_Click( object sender, EventArgs e )
        //{
        //    if( _selectedFavoriteItem == null )
        //    {
        //        throw new InvalidOperationException( "No selected favorite item." );
        //    }

        //    Favorite f = _selectedFavoriteItem.Value;

        //    using FavoriteFolderCreatorDialog dialog = FavoriteFolderCreatorDialog.FromFavorite( f );
        //    if( dialog.ShowDialog() == DialogResult.OK )
        //    {
        //        TreeNode<Favorite> newNode = new TreeNode<Favorite>( dialog.ToFavoriteFolder() );

        //        while( _selectedFavoriteItem.Children.Count > 0 )
        //        {
        //            TreeNode<Favorite> child = _selectedFavoriteItem.Children[ 0 ];
        //            child.Parent!.Remove( child );
        //            newNode.Add( child );
        //        }

        //        _selectedFavoriteItem.Parent!.Children[ _selectedFavoriteItem.Index ] = newNode;

        //        UpdateFavoritesTree( newNode );
        //    }
        //}

        //private void RemoveFavoriteItemMenuItem_Click( object sender, EventArgs e )
        //{
        //    if( _selectedFavoriteItem == null )
        //    {
        //        throw new InvalidOperationException( "No selected favorite item." );
        //    }

        //    TreeNode<Favorite> parent = _selectedFavoriteItem.Parent!;
        //    parent.Remove( _selectedFavoriteItem );

        //    UpdateFavoritesTree( parent );
        //}

        private void UpdateFavoritesTree( Favorite selectNode )
        {
            FavoritesTree.SuspendLayout();

            FavoritesTree.Nodes.Clear();
            FavoritesTreeImageList.Images.Clear();

            AddToTreeView( FavoritesTree.Nodes, Favorites );

            FavoritesTree.ExpandAll();

            FavoritesTree.ResumeLayout();

            FavoritesTree.SelectedNode = FindTreeNodeByFavorite( selectNode );
        }

        //private void UpdateInsertionMark( TreeNode<Favorite> favorite, bool before )
        //{
        //    if( favorite != null )
        //    {
        //        TreeNode? node = this.FindNodeByNode( favorite );
        //        if( node != null )
        //        {
        //            if( before )
        //            {
        //                Native.PostMessage( FavoritesTree.Handle, 0x111A, (IntPtr)0, node.Handle );
        //                return;
        //            }
        //            else
        //            {
        //                Native.PostMessage( FavoritesTree.Handle, 0x111A, (IntPtr)1, node.Handle );
        //                return;
        //            }
        //        }
        //    }
        //    ClearInsertionMark();
        //}

        //private void ClearInsertionMark()
        //{
        //    Native.PostMessage( FavoritesTree.Handle, 0x111A, (IntPtr)0, IntPtr.Zero );
        //}

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

            if( favorite is FavoriteFolder
             || favorite is FavoriteReposDirectory )
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

        //private void AddFavoriteItem( String path )
        //{
        //    if( _selectedFavoriteItem == null )
        //    {
        //        throw new InvalidOperationException( "No selected favorite item." );
        //    }

        //    using FavoriteFolderCreatorDialog dialog = new FavoriteFolderCreatorDialog( false )
        //    {
        //        FavoriteRepo = path
        //    };
        //    if( dialog.ShowDialog() == DialogResult.OK )
        //    {
        //        TreeNode<FavoriteRepo> newNode = new TreeNode<FavoriteRepo>( dialog.ToFavoriteFolder() );
        //        if( _selectedFavoriteItem.Value.IsFavoriteFolder )
        //        {
        //            _selectedFavoriteItem.Add( newNode );
        //        }
        //        else
        //        {
        //            _selectedFavoriteItem.Parent!.Children.Insert( _selectedFavoriteItem.Index, newNode );
        //        }

        //        UpdateFavoritesTree( newNode );
        //    }
        //}

        //class FavoritesDraggingItem
        //{
        //    public TreeNode<FavoriteRepo> Favorite { get; private set; }
        //    public bool Before { get; private set; }

        //    public FavoritesDraggingItem( TreeNode<FavoriteRepo> favorite, bool before )
        //    {
        //        Favorite = favorite;
        //        Before = before;
        //    }
        //}

        //class FavoritesDragDropHelper : DragDropHelper<TreeView, FavoritesDraggingItem>
        //{
        //    private readonly FavoritesManagerDialog _owner;

        //    public FavoritesDragDropHelper( FavoritesManagerDialog owner )
        //    {
        //        _owner = owner;

        //        MoveOnDragDrop = true;
        //    }

        //    protected override bool AllowDrag( TreeView parent, FavoritesDraggingItem item, int index )
        //    {
        //        return item.Favorite != _owner.Favorites;
        //    }

        //    private bool IsBefore( Rectangle bounds, Point p )
        //    {
        //        if( p.Y < bounds.Top + bounds.Height / 2 )
        //        {
        //            return true;
        //        }
        //        else
        //        {
        //            return false;
        //        }
        //    }

        //    protected override bool GetItemFromPoint( TreeView parent, Point p, out FavoritesDraggingItem? item, out int itemIndex )
        //    {
        //        TreeNode? treeNode = parent.GetNodeAt( p );

        //        if( treeNode == null )
        //        {
        //            item = null;
        //            itemIndex = -1;
        //            return false;
        //        }
        //        else
        //        {
        //            TreeNode<FavoriteRepo> favorite = (TreeNode<FavoriteRepo>)treeNode.Tag;
        //            item = new FavoritesDraggingItem( favorite, IsBefore( treeNode.Bounds, p ) );
        //            itemIndex = favorite.NestedIndex;
        //            return true;
        //        }
        //    }

        //    protected override bool ItemsEqual( TreeView parent1, FavoritesDraggingItem item1, int itemIndex1, TreeView parent2, FavoritesDraggingItem item2, int itemIndex2 )
        //    {
        //        return item1.Favorite == item2.Favorite;
        //    }

        //    protected override void OnDragEnd( DragEndEventArgs<TreeView, FavoritesDraggingItem> e )
        //    {
        //        base.OnDragEnd( e );

        //        _owner.ClearInsertionMark();
        //    }

        //    protected override bool AllowDrop( TreeView dragParent, FavoritesDraggingItem dragItem, int dragItemIndex, TreeView pointedParent, FavoritesDraggingItem pointedItem, int pointedItemIndex )
        //    {
        //        TreeNode<FavoriteRepo> dragFavorite = dragItem.Favorite;
        //        TreeNode<FavoriteRepo> pointedFavorite = pointedItem.Favorite;

        //        bool allowDrop;

        //        if( pointedFavorite == _owner.Favorites )
        //        {
        //            allowDrop = false;
        //        }
        //        else if( pointedFavorite == dragFavorite
        //              || dragFavorite.NestedContains( pointedFavorite ) )
        //        {
        //            allowDrop = false;
        //        }
        //        else if( pointedItem.Before
        //              && pointedFavorite.Previous == dragFavorite )
        //        {
        //            allowDrop = false;
        //        }
        //        else if( !pointedItem.Before
        //              && pointedFavorite.Next == dragFavorite )
        //        {
        //            allowDrop = false;
        //        }
        //        else
        //        {
        //            allowDrop = true;
        //        }

        //        if( allowDrop )
        //        {
        //            _owner.UpdateInsertionMark( pointedFavorite, pointedItem.Before );
        //        }
        //        else
        //        {
        //            _owner.ClearInsertionMark();
        //        }

        //        return allowDrop;
        //    }

        //    protected override void MoveItem( TreeView dragParent, FavoritesDraggingItem dragItem, int dragItemIndex, TreeView pointedParent, FavoritesDraggingItem pointedItem, int pointedItemIndex )
        //    {
        //        TreeNode<FavoriteRepo> dragFavorite = dragItem.Favorite;
        //        TreeNode<FavoriteRepo> pointedFavorite = pointedItem.Favorite;

        //        if( pointedItem.Before )
        //        {
        //            dragFavorite.Parent!.Remove( dragFavorite );
        //            pointedFavorite.Parent!.Children.Insert( pointedFavorite.Index, dragFavorite );
        //        }
        //        else
        //        {
        //            dragFavorite.Parent!.Remove( dragFavorite );
        //            pointedFavorite.Parent!.Children.Insert( pointedFavorite.Index + 1, dragFavorite );
        //        }

        //        _owner.UpdateFavoritesTree( dragFavorite );
        //    }
        //}
    }
}
