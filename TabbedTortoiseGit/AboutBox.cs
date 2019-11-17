#nullable enable

using Common;
using log4net;
using log4net.Appender;
using log4net.Repository.Hierarchy;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;
using TabbedTortoiseGit.Properties;

namespace TabbedTortoiseGit
{
    partial class AboutBox : Form
    {
        private static readonly ILog LOG = LogManager.GetLogger( typeof( AboutBox ) );

        public static void ShowAbout()
        {
            new AboutBox().ShowDialog();
        }

        private Version _newestVersion;

        private AboutBox()
        {
            InitializeComponent();

            this.Icon = Resources.TortoiseIcon;

            this.Text = $"About {AssemblyTitle}";
            this.ProductNameLabel.Text = AssemblyProduct;
            this.VersionLabel.Text = $"Version {AssemblyVersion}";
            this.DescriptionText.Text = AssemblyDescription;

            this.Load += AboutBox_Load;

            UpdateButton.Click += UpdateButton_Click;
            ViewGithub.Click += ViewGithub_Click;
        }

        private async void AboutBox_Load( object sender, EventArgs e )
        {
            _newestVersion = await TTG.IsUpToDate();
            if( _newestVersion != null )
            {
                LOG.Debug( $"Newer Version Available - New: {_newestVersion} - Current: {AssemblyVersion}" );

                UpdateCheckLabel.Text = $"Version {_newestVersion.ToString( 3 )} is available.";
                UpdateButton.Enabled = true;
            }
            else
            {
                UpdateCheckLabel.Text = AssemblyTitle + " is up to date.";
                LOG.Debug( $"Update to Date - Version: {AssemblyVersion}" );
            }
        }

        private async void UpdateButton_Click( object sender, EventArgs e )
        {
            LOG.Debug( $"{nameof( UpdateButton_Click )} - Newest Version: {_newestVersion.ToString( 3 )}" );
            if( DialogResult.Yes == MessageBox.Show( "This will exit Tabbed TortoiseGit. Continue?", "New Update", MessageBoxButtons.YesNo ) )
            {
                LOG.Debug( "Update Prompt - OK" );
                if( await TTG.UpdateApplication( _newestVersion ) )
                {
                    LOG.Debug( "Update - Exiting Application" );
                    Application.Exit();
                }
                else
                {
                    LOG.Debug( "Update - Error occurred" );
                    MessageBox.Show( "There was an error updating Tabbed TortoiseGit. Try again later." );
                }
            }
        }

        private void ViewGithub_Click( object sender, EventArgs e )
        {
            Process.Start( "https://github.com/anickle060193/tabbed_tortoise_git" );
        }

        #region Assembly Attribute Accessors

        public string AssemblyTitle
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes( typeof( AssemblyTitleAttribute ), false );
                if( attributes.Length > 0 )
                {
                    AssemblyTitleAttribute titleAttribute = (AssemblyTitleAttribute)attributes[ 0 ];
                    if( titleAttribute.Title != "" )
                    {
                        return titleAttribute.Title;
                    }
                }
                return System.IO.Path.GetFileNameWithoutExtension( Assembly.GetExecutingAssembly().CodeBase );
            }
        }

        public string AssemblyVersion
        {
            get
            {
                return Assembly.GetExecutingAssembly().GetName().Version.ToString( 3 );
            }
        }

        public string AssemblyDescription
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes( typeof( AssemblyDescriptionAttribute ), false );
                if( attributes.Length == 0 )
                {
                    return "";
                }
                return ( (AssemblyDescriptionAttribute)attributes[ 0 ] ).Description;
            }
        }

        public string AssemblyProduct
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes( typeof( AssemblyProductAttribute ), false );
                if( attributes.Length == 0 )
                {
                    return "";
                }
                return ( (AssemblyProductAttribute)attributes[ 0 ] ).Product;
            }
        }

        public string AssemblyCopyright
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes( typeof( AssemblyCopyrightAttribute ), false );
                if( attributes.Length == 0 )
                {
                    return "";
                }
                return ( (AssemblyCopyrightAttribute)attributes[ 0 ] ).Copyright;
            }
        }

        public string AssemblyCompany
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes( typeof( AssemblyCompanyAttribute ), false );
                if( attributes.Length == 0 )
                {
                    return "";
                }
                return ( (AssemblyCompanyAttribute)attributes[ 0 ] ).Company;
            }
        }
        #endregion
    }
}
