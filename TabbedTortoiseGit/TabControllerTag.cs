using Common;
using log4net;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TabbedTortoiseGit.Properties;
using Tabs;

namespace TabbedTortoiseGit
{
    class TabControllerTag
    {
        private static readonly ILog LOG = LogManager.GetLogger( typeof( TabControllerTag ) );

        private bool _modified;

        public Tab Tab { get; private set; }
        public Process Process { get; private set; }
        public String RepoItem { get; private set; }
        public Color Color { get; private set; }
        public bool LoadingSubmodules { get; private set; }
        public List<String>? Submodules { get; private set; }

        public ProgressDialog? BackgroundFasterFetchDialog { get; set; }

        public bool Modified
        {
            get
            {
                return _modified;
            }

            set
            {
                if( _modified != value )
                {
                    _modified = value;
                    this.UpdateTabDisplay();
                }
            }
        }

        public static TabControllerTag CreateController( Process p, String repo )
        {
            Tab t = new Tab( repo );

            TabControllerTag tag = new TabControllerTag( t, p, repo );

            t.Tag = tag;

            tag.UpdateTabDisplay();
            tag.UpdateIcon();

            return tag;
        }

        private TabControllerTag( Tab tab, Process process, String repo )
        {
            Tab = tab;
            Process = process;
            RepoItem = repo;
            Modified = false;

            this.Color = Color.Empty;

            Tab.Resize += Tab_Resize;

            Process.Exited += Process_Exited;
            Process.EnableRaisingEvents = true;
        }

        public async Task WaitForStartup()
        {
            LOG.Debug( $"{nameof( WaitForStartup )} - Start Wait for MainWindowHandle - Repo: {this.RepoItem} - PID: {this.Process.Id}" );
            while( !this.Process.HasExited && this.Process.MainWindowHandle == IntPtr.Zero )
            {
                await Task.Delay( 10 );
            }
            LOG.Debug( $"{nameof( WaitForStartup )} - End Wait for MainWindowHandle - Repo: {this.RepoItem} - PID: {this.Process.Id}" );

            Native.RemoveBorder( this.Process.MainWindowHandle );
            Native.SetWindowParent( this.Process.MainWindowHandle, this.Tab );
            this.ResizeTab();
        }

        public async Task LoadSubmodules()
        {
            if( this.Submodules != null
             || this.LoadingSubmodules )
            {
                return;
            }

            this.LoadingSubmodules = true;

            LOG.Debug( $"{nameof( LoadSubmodules )} - Retrieving Submodules Started" );
            this.Submodules = await Task.Run( () => Git.GetSubmodules( this.RepoItem ) );
            LOG.Debug( $"{nameof( LoadSubmodules )} - Retrieving Submodules Done - {this.Submodules.Count} Submodules" );

            this.LoadingSubmodules = false;
        }

        public void UpdateTabDisplay()
        {
            if( Settings.Default.IndicateModifiedTabs && this.Modified )
            {
                this.Tab.Font = Settings.Default.ModifiedTabFont;
                this.Tab.ForeColor = Settings.Default.ModifiedTabFontColor;
            }
            else
            {
                this.Tab.Font = Settings.Default.NormalTabFont;
                this.Tab.ForeColor = Settings.Default.NormalTabFontColor;
            }
        }

        public void UpdateIcon()
        {
            FavoriteFolder favorites = Settings.Default.FavoriteRepos;

            Color tabColor = favorites.BreadthFirstSearch( ( f ) => f is FavoriteRepo r && this.RepoItem == r.Repo )?.Color
                          ?? favorites.BreadthFirstSearch( ( f ) => f is FavoriteReposDirectory d && this.RepoItem.StartsWith( d.Directory ) )?.Color
                          ?? Color.Black;

            if( tabColor != this.Color
             || this.Tab.Icon == null )
            {
                this.Color = tabColor;

                Bitmap icon;
                if( File.Exists( this.RepoItem ) )
                {
                    icon = Resources.File;
                }
                else
                {
                    icon = Resources.Folder;
                }

                if( tabColor == Color.Black )
                {
                    this.Tab.Icon = icon;
                }
                else
                {
                    this.Tab.Icon = Util.ColorBitmap( icon, tabColor );
                }
            }
        }

        private void EndProcess()
        {
            if( !this.Process.CloseMainWindow() )
            {
                this.Process.Kill();
            }
        }

        public void Close()
        {
            this.Tab.Resize -= Tab_Resize;
            this.Tab.Parent = null;

            this.Process.EnableRaisingEvents = false;
            this.Process.Exited -= Process_Exited;

            if( !this.Process.HasExited )
            {
                Task.Run( (Action)this.EndProcess );
            }
        }

        private void ResizeTab()
        {
            Size sizeDiff = Native.ResizeToParent( this.Process.MainWindowHandle, this.Tab );

            Form form = this.Tab.FindForm();

            if( form != null )
            {
                if( sizeDiff.Width > 0 )
                {
                    form.Width += sizeDiff.Width;
                    form.MinimumSize = new Size( form.Width, form.MinimumSize.Height );
                }

                if( sizeDiff.Height > 0 )
                {
                    form.Height += sizeDiff.Height;
                    form.MinimumSize = new Size( form.MinimumSize.Width, form.Height );
                }
            }
        }

        private void Tab_Resize( object? sender, EventArgs e )
        {
            if( this.Tab.FindForm()?.WindowState != FormWindowState.Minimized )
            {
                ResizeTab();
            }
        }

        private void Process_Exited( object? sender, EventArgs e )
        {
            this.Tab.UiBeginInvoke( (Action)( () => this.Tab.Parent = null ) );
        }
    }

    static class TabExtensions
    {
        public static TabControllerTag Controller( this Tab tab )
        {
            return (TabControllerTag)tab.Tag;
        }
    }
}
