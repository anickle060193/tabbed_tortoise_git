#nullable enable

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
    public partial class FavoriteCreatorDialog : Form
    {
        private String _favoriteRepo = "";
        private Color _favoriteColor;

        public bool IsFavoritesFolder { get; private set; }

        public String FavoriteRepo
        {
            get
            {
                if( IsFavoritesFolder )
                {
                    return "";
                }
                else
                {
                    return _favoriteRepo;
                }
            }

            set
            {
                if( IsFavoritesFolder || String.IsNullOrWhiteSpace( value ) )
                {
                    _favoriteRepo = "";
                    this.Text = "Favorite Creator";
                }
                else
                {
                    _favoriteRepo = value;
                    this.Text = "Favorite Creator - " + _favoriteRepo;
                }
            }
        }

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

        public IEnumerable<String> FavoriteReferences
        {
            get
            {
                if( IsFavoritesFolder )
                {
                    return Enumerable.Empty<String>();
                }
                else
                {
                    return ReferencesListBox.Items.Cast<String>();
                }
            }

            set
            {
                ReferencesListBox.Items.Clear();

                if( !IsFavoritesFolder )
                {
                    String[] references = value.ToArray();
                    ReferencesListBox.Items.AddRange( references );
                }
            }
        }

        public static FavoriteCreatorDialog FromFavoriteRepo( FavoriteRepo favorite )
        {
            return new FavoriteCreatorDialog( favorite.IsFavoriteFolder )
            {
                FavoriteRepo = favorite.Repo,
                FavoriteName = favorite.Name,
                FavoriteColor = favorite.Color,
                FavoriteReferences = favorite.References
            };
        }

        public FavoriteCreatorDialog( bool isFavoriteFolder )
        {
            InitializeComponent();

            this.Icon = Resources.TortoiseIcon;

            this.IsFavoritesFolder = isFavoriteFolder;

            this.FavoriteRepo = "";
            this.FavoriteName = "";
            this.FavoriteColor = Color.Black;
            this.FavoriteReferences = Enumerable.Empty<String>();

            SelectReferencesButton.Click += SelectReferencesButton_Click;
            RemoveReferencesButton.Click += RemoveReferencesButton_Click;

            ChangeFavoriteColorButton.Click += ChangeFavoriteColorButton_Click;

            Ok.Click += Ok_Click;

            if( IsFavoritesFolder )
            {
                ReferencesGroup.Visible = false;

                TableLayout.RowStyles[ 1 ] = new RowStyle( SizeType.Absolute, 0.0f );
                TableLayout.AutoSize = true;
                TableLayout.AutoSizeMode = AutoSizeMode.GrowAndShrink;

                this.MinimumSize = new Size( 0, 0 );
                this.AutoSize = true;
                this.AutoSizeMode = AutoSizeMode.GrowAndShrink;
                this.FormBorderStyle = FormBorderStyle.Fixed3D;
            }
        }

        public FavoriteRepo ToFavoriteRepo()
        {
            bool isDirectory = !IsFavoritesFolder && Directory.Exists( FavoriteRepo );
            return new FavoriteRepo( FavoriteName, FavoriteRepo, isDirectory, IsFavoritesFolder, FavoriteColor, FavoriteReferences );
        }

        private void RemoveReferencesButton_Click( object sender, EventArgs e )
        {
            foreach( String branch in ReferencesListBox.SelectedItems.Cast<String>().ToList() )
            {
                ReferencesListBox.Items.Remove( branch );
            }
        }

        private void SelectReferencesButton_Click( object sender, EventArgs e )
        {
            using ReferencesDialog d = new ReferencesDialog( this.FavoriteRepo );
            if( d.ShowDialog() == DialogResult.OK )
            {
                ReferencesListBox.Items.AddRange( d.SelectedReferences );
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
                MessageBox.Show( "Favorite name cannot be empty.", "Invalid Favorite Name", MessageBoxButtons.OK );
            }
            else
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }
    }
}
