using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TabbedTortoiseGit.Properties;

namespace TabbedTortoiseGit
{
    public partial class FavoritesManagerDialog : Form
    {
        public static void ShowFavoritesManager()
        {
            new FavoritesManagerDialog().ShowDialog();
        }

        private FavoritesManagerDialog()
        {
            InitializeComponent();
            InitializeFromSettings();

            FavoritesTreeView.AfterSelect += FavoritesTreeView_AfterSelect;
            FavoritesTreeView.MouseUp += FavoritesTreeView_MouseUp;

            FavoritesList.MouseUp += FavoritesList_MouseUp;

            RemoveFavoritesListItemMenuItem.Click += RemoveFavoritesListItemMenuItem_Click;

            Ok.Click += Ok_Click;
        }

        private void RemoveFavoritesListItemMenuItem_Click( object sender, EventArgs e )
        {
            throw new NotImplementedException();
        }

        private void FavoritesTreeView_AfterSelect( object sender, TreeViewEventArgs e )
        {
            FavoritesList.Items.Clear();

            if( e.Node.Tag is FavoriteRepos )
            {
                FavoriteRepos fs = (FavoriteRepos)e.Node.Tag;
                foreach( FavoriteRepo r in fs.Favorites )
                {
                    ListViewItem item = new ListViewItem( r.Name );
                    item.SubItems.Add( r.Repo );
                    item.ImageKey = "Folder";
                    FavoritesList.Items.Add( item );
                }
            }
        }

        private void InitializeFromSettings()
        {
            FavoriteRepos rs = FavoriteRepos.Parse( @"{
    ""TortoiseGit"" : ""C:_tortoise_git"",
    ""Dev"" : ""C_dev_src"",
    ""Test Folder"" : {
        ""Test Favorite"" : ""test_favorite_value"",
        ""Favorite2"" : ""c_fav_2"",
        ""Test Subfolder"" : {
            ""Test Subfavorite"" : ""test_sub_favorite_value"",
            ""SubFav2"" : ""c_sub_fav_2""
        }
    }
}" );

            TreeNode favs = FavoritesTreeView.Nodes.Add( "Favorites" );
            favs.ImageKey = "FolderFolder";
            favs.SelectedImageKey = "FolderFolder";
            favs.Tag = rs;
            foreach( KeyValuePair<String, FavoriteRepos> r in rs.SubFavorites )
            {
                TreeNode sub = FavoritesTreeView.Nodes.Add( r.Key );
                sub.ImageKey = "FolderFolder";
                sub.SelectedImageKey = "FolderFolder";
                AddToTree( sub, r.Value );
            }
        }

        private void AddToTree( TreeNode root, FavoriteRepos repos )
        {
            foreach( KeyValuePair<String, FavoriteRepos> rs in repos.SubFavorites )
            {
                TreeNode node = root.Nodes.Add( rs.Key );
                node.ImageKey = "FolderFolder";
                node.SelectedImageKey = "FolderFolder";
                AddToTree( node, rs.Value );
            }
            root.Tag = repos;
        }

        private void FavoritesTreeView_MouseUp( object sender, MouseEventArgs e )
        {
            if( e.Button == MouseButtons.Right )
            {
                TreeNode node = FavoritesTreeView.GetNodeAt( e.Location );
                if( node != null )
                {
                    FavoritesTreeViewItemContextMenu.Tag = node;
                    FavoritesTreeViewItemContextMenu.Show( FavoritesTreeView, e.Location );
                }
                else
                {
                    FavoritesTreeViewContextMenu.Show( FavoritesTreeView, e.Location );
                }
            }
        }

        private void FavoritesList_MouseUp( object sender, MouseEventArgs e )
        {
            if( e.Button == MouseButtons.Right )
            {
                ListViewItem item = FavoritesList.GetItemAt( e.X, e.Y );
                if( item != null )
                {
                    FavoritesListItemContextMenu.Tag = item;
                    FavoritesListItemContextMenu.Show( FavoritesList, e.Location );
                }
                else
                {
                    FavoritesListContextMenu.Show( FavoritesList, e.Location );
                }
            }
        }

        private void Ok_Click( object sender, EventArgs e )
        {
            this.Close();
        }

        private void Add( TreeNodeCollection nodes, JToken token )
        {
            foreach( KeyValuePair<String, JToken> entry in (JObject)token )
            {
                if( entry.Value.Type == JTokenType.String )
                {
                    FavoriteRepo r = new FavoriteRepo( entry.Key, (String)( (JValue)entry.Value ) );
                    nodes.Add( r.Name ).Tag = r;
                }
                else
                {
                    Add( nodes.Add( entry.Key ).Nodes, entry.Value );
                }
            }
        }
    }
}
