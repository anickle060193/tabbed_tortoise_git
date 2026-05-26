using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using TabbedTortoiseGit.Properties;

namespace TabbedTortoiseGit
{
    public partial class ChangelogDialog : Form
    {

        [GeneratedRegex( @"^\#\s+(?<text>.*)$" )]
        private static partial Regex HeaderRegex();
        private static readonly Regex HEADER_REGEX = HeaderRegex();

        [GeneratedRegex( @"^\*\s+(?<text>.*)$" )]
        private static partial Regex BulletRegex();
        private static readonly Regex BULLET_REGEX = BulletRegex();

        public static void ShowChangelog()
        {
            using ChangelogDialog dialog = new ChangelogDialog();
            dialog.ShowDialog();
        }

        private ChangelogDialog()
        {
            InitializeComponent();

            this.ShowChangelogOnUpdateCheck.CheckedChanged += ShowChangelogOnUpdateCheck_CheckedChanged;
            this.OkButton.Click += OkButton_Click;

            this.ShowChangelogOnUpdateCheck.Checked = Settings.Default.ShowChangelogOnUpdate;

            this.LoadChangelog();
        }

        private void ShowChangelogOnUpdateCheck_CheckedChanged( object? sender, EventArgs e )
        {
            Settings.Default.ShowChangelogOnUpdate = ShowChangelogOnUpdateCheck.Checked;
            Settings.Default.Save();
        }

        private void OkButton_Click( object? sender, EventArgs e )
        {
            this.Close();
        }

        private void LoadChangelog()
        {
            foreach( String line in Resources.Changelog.Replace( "\r", "" ).Split( [ '\n' ] ) )
            {
                if( HEADER_REGEX.Match( line ) is Match headerMatch
                 && headerMatch.Success )
                {
                    ChangelogText.SelectionFont = new Font( ChangelogText.Font, FontStyle.Bold );
                    ChangelogText.SelectedText = headerMatch.Groups[ "text" ].Value;
                }
                else if( BULLET_REGEX.Match( line ) is Match bulletText
                      && bulletText.Success )
                {
                    ChangelogText.SelectionBullet = true;
                    ChangelogText.SelectedText = bulletText.Groups[ "text" ].Value;
                }
                else
                {
                    ChangelogText.AppendText( line );
                }

                ChangelogText.AppendText( Environment.NewLine );
                ChangelogText.SelectionLength = 0;
                ChangelogText.SelectionBullet = false;
            }
        }
    }
}
