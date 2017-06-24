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
    public partial class FavoriteCreatorDialog : Form
    {
        private String _favoriteRepo;
        private Color _favoriteColor;

        public String FavoriteRepo
        {
            get
            {
                return _favoriteRepo;
            }

            set
            {
                _favoriteRepo = value;
                if( String.IsNullOrWhiteSpace( _favoriteRepo ) )
                {
                    this.Text = "Favorite Creator";
                }
                else
                {
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

        public FavoriteCreatorDialog()
        {
            InitializeComponent();

            this.Icon = Resources.TortoiseIcon;

            this.FavoriteRepo = "";
            this.FavoriteName = "";
            this.FavoriteColor = Color.Black;

            this.ChangeFavoriteColorButton.Click += ChangeFavoriteColorButton_Click;

            this.Ok.Click += Ok_Click;
        }

        private void ChangeFavoriteColorButton_Click( object sender, EventArgs e )
        {
            if( FavoriteColorDialog.ShowDialog() == DialogResult.OK )
            {
                this.FavoriteColor = FavoriteColorDialog.Color;
            }
        }

        public new DialogResult ShowDialog()
        {
            return this.ShowDialog( "" );
        }

        public DialogResult ShowDialog( String repo )
        {
            return this.ShowDialog( repo, "", Color.Black );
        }

        public DialogResult ShowDialog( String repo, String name, Color color )
        {
            this.FavoriteRepo = repo;
            this.FavoriteName = name;
            this.FavoriteColor = color;
            return base.ShowDialog();
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
