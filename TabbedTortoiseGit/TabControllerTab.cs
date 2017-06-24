using Common;
using log4net;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
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
        public String Repo { get; private set; }

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

            return tag;
        }

        private TabControllerTag( Tab tab, Process process, String repo )
        {
            Tab = tab;
            Process = process;
            Repo = repo;
            Modified = false;

            Tab.Resize += Tab_Resize;

            Process.Exited += Process_Exited;
            Process.EnableRaisingEvents = true;
        }

        public async Task WaitForStartup()
        {
            LOG.DebugFormat( "WaitForStartup - Start Wait for MainWindowHandle - Repo: {0} - PID: {1}", this.Repo, this.Process.Id );
            while( !this.Process.HasExited && this.Process.MainWindowHandle == IntPtr.Zero )
            {
                await Task.Delay( 10 );
            }
            LOG.DebugFormat( "WaitForStartup - End Wait for MainWindowHandle - Repo: {0} - PID: {1}", this.Repo, this.Process.Id );

            Native.RemoveBorder( this.Process.MainWindowHandle );
            Native.SetWindowParent( this.Process.MainWindowHandle, this.Tab );
            this.ResizeTab();
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

        public void Close()
        {
            this.Tab.Resize -= Tab_Resize;
            this.Tab.Parent = null;

            this.Process.EnableRaisingEvents = false;
            this.Process.Exited -= Process_Exited;

            if( !this.Process.HasExited )
            {
                this.Process.Kill();
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

        private void Tab_Resize( object sender, EventArgs e )
        {
            if( this.Tab.FindForm()?.WindowState != FormWindowState.Minimized )
            {
                ResizeTab();
            }
        }

        private void Process_Exited( object sender, EventArgs e )
        {
            this.Tab.UiBeginInvoke( (Action)( () => this.Tab.Parent = null ) );
        }
    }

    static class TabExtensions
    {
        public static TabControllerTag Controller( this Tab tab )
        {
            return tab?.Tag as TabControllerTag;
        }
    }
}
