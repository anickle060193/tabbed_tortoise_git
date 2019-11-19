#nullable enable

using Microsoft.WindowsAPICodePack.Dialogs;
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
    public partial class FavoriteReposDirectoryCreatorDialog : Form
    {
        private readonly CommonOpenFileDialog _favoriteReposFolderDialog = new CommonOpenFileDialog()
        {
            IsFolderPicker = true
        };

        private Color _favoriteColor;

        public String FavoriteName
        {
            get
            {
                return FavoriteNameText.Text;
            }

            set
            {
                FavoriteNameText.Text = value;
            }
        }

        public String FavoriteDirectory
        {
            get
            {
                return FavoriteDirectoryText.Text;
            }

            set
            {
                FavoriteDirectoryText.Text = value;
            }
        }

        public Color FavoriteColor
        {
            get
            {
                return _favoriteColor;
            }

            set
            {
                _favoriteColor = value;
                ChangeFavoriteColorButton.BackColor = _favoriteColor;
                FavoriteColorDialog.Color = _favoriteColor;
            }
        }

        public static FavoriteReposDirectoryCreatorDialog FromFavoriteReposDirectory( FavoriteReposDirectory favorite )
        {
            return new FavoriteReposDirectoryCreatorDialog()
            {
                FavoriteName = favorite.Name,
                FavoriteDirectory = favorite.Directory,
                FavoriteColor = favorite.Color,
            };
        }

        public FavoriteReposDirectoryCreatorDialog()
        {
            InitializeComponent();

            this.Icon = Resources.TortoiseIcon;

            this.FavoriteName = "";
            this.FavoriteDirectory = "";
            this.FavoriteColor = Color.Black;

            BrowseButton.Click += BrowseButton_Click;

            ChangeFavoriteColorButton.Click += ChangeFavoriteColorButton_Click;

            Ok.Click += Ok_Click;
        }

        public FavoriteReposDirectory ToFavoriteReposDirectory()
        {
            return new FavoriteReposDirectory( this.FavoriteName, this.FavoriteDirectory, this.FavoriteColor );
        }

        private void BrowseButton_Click( object sender, EventArgs e )
        {
            _favoriteReposFolderDialog.DefaultDirectory = this.FavoriteDirectory;

            if( _favoriteReposFolderDialog.ShowDialog() == CommonFileDialogResult.Ok )
            {
                String directory = _favoriteReposFolderDialog.FileName;
                this.FavoriteDirectory = directory;

                if( !String.IsNullOrWhiteSpace( directory )
                 && String.IsNullOrWhiteSpace( this.FavoriteName ) )
                {
                    this.FavoriteName = Path.GetFileName( directory );
                }
            }
        }

        private void ChangeFavoriteColorButton_Click( object sender, EventArgs e )
        {
            if( FavoriteColorDialog.ShowDialog() == DialogResult.OK )
            {
                this.FavoriteColor = FavoriteColorDialog.Color;
            }
        }

        private void Ok_Click( object sender, EventArgs e )
        {
            if( String.IsNullOrWhiteSpace( this.FavoriteName ) )
            {
                MessageBox.Show( "Favorite name cannot be empty.", "Invalid Favorite Name", MessageBoxButtons.OK, MessageBoxIcon.Error );
            }
            else if( !Directory.Exists( this.FavoriteDirectory ) )
            {
                MessageBox.Show( "Favorite repos folder location does not exist.", "Invalid Favorite Repos Folder", MessageBoxButtons.OK, MessageBoxIcon.Error );
            }
            else
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }
    }
}
