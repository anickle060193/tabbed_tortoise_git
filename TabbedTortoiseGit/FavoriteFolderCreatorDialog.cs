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
    public partial class FavoriteFolderCreatorDialog : Form
    {
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

        public static FavoriteFolderCreatorDialog FromFavoriteFolder( FavoriteFolder favorite )
        {
            return new FavoriteFolderCreatorDialog()
            {
                FavoriteName = favorite.Name,
                FavoriteColor = favorite.Color,
            };
        }

        public FavoriteFolderCreatorDialog()
        {
            InitializeComponent();

            this.Icon = Resources.TortoiseIcon;

            this.FavoriteName = "";
            this.FavoriteColor = Color.Black;

            ChangeFavoriteColorButton.Click += ChangeFavoriteColorButton_Click;

            Ok.Click += Ok_Click;
        }

        public FavoriteFolder ToFavoriteFolder()
        {
            return new FavoriteFolder( this.FavoriteName, this.FavoriteColor );
        }

        private void ChangeFavoriteColorButton_Click( object? sender, EventArgs e )
        {
            if( FavoriteColorDialog.ShowDialog() == DialogResult.OK )
            {
                this.FavoriteColor = FavoriteColorDialog.Color;
            }
        }

        private void Ok_Click( object? sender, EventArgs e )
        {
            if( String.IsNullOrWhiteSpace( this.FavoriteName ) )
            {
                MessageBox.Show( "Favorite name cannot be empty.", "Invalid Favorite Name", MessageBoxButtons.OK, MessageBoxIcon.Error );
            }
            else
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }
    }
}
