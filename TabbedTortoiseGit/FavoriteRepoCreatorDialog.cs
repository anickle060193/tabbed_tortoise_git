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
    public partial class FavoriteRepoCreatorDialog : Form
    {
        private readonly CommonOpenFileDialog _favoriteRepoDialog = new CommonOpenFileDialog()
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

        public String FavoriteRepo
        {
            get
            {
                return FavoriteRepoText.Text;
            }

            set
            {
                FavoriteRepoText.Text = value;
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
                return ReferencesListBox.Items.Cast<String>();
            }

            set
            {
                ReferencesListBox.Items.Clear();
                ReferencesListBox.Items.AddRange( value.ToArray() );
            }
        }

        public static FavoriteRepoCreatorDialog FromFavoriteRepo( FavoriteRepo favorite )
        {
            return new FavoriteRepoCreatorDialog()
            {
                FavoriteRepo = favorite.Repo,
                FavoriteName = favorite.Name,
                FavoriteColor = favorite.Color,
                FavoriteReferences = favorite.References
            };
        }

        public FavoriteRepoCreatorDialog()
        {
            InitializeComponent();

            this.Icon = Resources.TortoiseIcon;

            this.FavoriteRepo = "";
            this.FavoriteName = "";
            this.FavoriteColor = Color.Black;
            this.FavoriteReferences = Enumerable.Empty<String>();

            BrowseButton.Click += BrowseButton_Click;

            SelectReferencesButton.Click += SelectReferencesButton_Click;
            RemoveReferencesButton.Click += RemoveReferencesButton_Click;

            ChangeFavoriteColorButton.Click += ChangeFavoriteColorButton_Click;

            Ok.Click += Ok_Click;
        }

        public FavoriteRepo ToFavoriteRepo()
        {
            bool isDirectory = Directory.Exists( FavoriteRepo );
            return new FavoriteRepo( FavoriteName, FavoriteRepo, isDirectory, FavoriteColor, FavoriteReferences );
        }

        private void BrowseButton_Click( object sender, EventArgs e )
        {
            if( Directory.Exists( this.FavoriteRepo ) )
            {
                _favoriteRepoDialog.DefaultDirectory = this.FavoriteRepo;
            }
            else
            {
                _favoriteRepoDialog.DefaultFileName = this.FavoriteRepo;
            }

            if( _favoriteRepoDialog.ShowDialog() == CommonFileDialogResult.Ok )
            {
                String directory = _favoriteRepoDialog.FileName;
                this.FavoriteRepo = directory;

                if( !String.IsNullOrWhiteSpace( directory )
                 && String.IsNullOrWhiteSpace( this.FavoriteName ) )
                {
                    this.FavoriteName = Path.GetFileName( directory );
                }
            }
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
                MessageBox.Show( "Favorite name cannot be empty.", "Invalid Favorite Name", MessageBoxButtons.OK, MessageBoxIcon.Error );
            }
            else if( !Directory.Exists( this.FavoriteRepo )
                  && !File.Exists( this.FavoriteRepo ) )
            {
                MessageBox.Show( "Favorite repo location does not exist.", "Invalid Favorite Repo", MessageBoxButtons.OK, MessageBoxIcon.Error );
            }
            else if( !Git.IsInRepo( this.FavoriteRepo ) )
            {
                MessageBox.Show( "Favorite repo location is not a repo.", "Invalid Favorite Repo", MessageBoxButtons.OK, MessageBoxIcon.Error );
            }
            else
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }
    }
}
