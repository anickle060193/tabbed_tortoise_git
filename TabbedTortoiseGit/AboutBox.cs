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

namespace TabbedTortoiseGit
{
    partial class AboutBox : Form
    {
        public AboutBox()
        {
            InitializeComponent();
            this.Text = String.Format( "About {0}", AssemblyTitle );
            this.ProductNameLabel.Text = AssemblyProduct;
            this.VersionLabel.Text = String.Format( "Version {0}", AssemblyVersion );
            this.DescriptionText.Text = AssemblyDescription;

            ViewGithub.Click += ViewGithub_Click;
            OpenDebugLog.Click += OpenDebugLog_Click;
        }

        public static void ShowAbout()
        {
            new AboutBox().ShowDialog();
        }

        private void ViewGithub_Click( object sender, EventArgs e )
        {
            Process.Start( "https://github.com/anickle060193/tabbed_tortoise_git" );
        }

        private void OpenDebugLog_Click( object sender, EventArgs e )
        {
            FileAppender rootAppender = ( (Hierarchy)LogManager.GetRepository() ).Root.Appenders.OfType<FileAppender>().FirstOrDefault();
            if( rootAppender != null )
            {
                Util.OpenInExplorer( rootAppender.File );
            }
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
                return Assembly.GetExecutingAssembly().GetName().Version.ToString();
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
