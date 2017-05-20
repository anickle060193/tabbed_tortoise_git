using log4net;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Diagnostics;

namespace TabbedTortoiseGit.Properties
{
    internal sealed partial class Settings
    {
        private static readonly ILog LOG = LogManager.GetLogger( typeof( Settings ) );

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue( "" )]
        [Obsolete( "User FavoriteRepos instead." )]
        [NoSettingsVersionUpgrade]
        public String FavoritedRepos
        {
            get { throw new NotSupportedException( "FavoirtedRepos is obsolete." ); }
            set { throw new NotSupportedException( "FavoirtedRepos is obsolete." ); }
        }

        public Dictionary<String,String> FavoriteRepos
        {
            get
            {
                Dictionary<String, String> favoriteRepos = null;
                try
                {
                    favoriteRepos = JsonConvert.DeserializeObject<Dictionary<String, String>>( Settings.Default.FavoriteReposString );
                }
                catch( JsonReaderException e )
                {
                    LOG.ErrorFormat( "Failed to parse Favorite Repos setting - Favorited Repos: {0}", Settings.Default.FavoriteReposString );
                    LOG.Error( e );
                }

                if( favoriteRepos == null )
                {
                    return new Dictionary<String, String>();
                }
                else
                {
                    return favoriteRepos;
                }
            }

            set
            {
                Settings.Default.FavoriteReposString = JsonConvert.SerializeObject( value );
            }
        }

        public Settings()
        {
            this.SettingsLoaded += Settings_SettingsLoaded;
        }

        private void Settings_SettingsLoaded( object sender, SettingsLoadedEventArgs e )
        {
            if( Settings.Default.UpgradeRequired )
            {
                LOG.Debug( "Upgrading settings" );
                Settings.Default.Upgrade();
                Settings.Default.UpgradeRequired = false;

                try
                {
                    Object oldValue = Settings.Default.GetPreviousVersion( "FavoritedRepos" );
                    if( oldValue != null && oldValue is String )
                    {
                        Settings.Default.FavoriteReposString = (String)oldValue;
                    }
                }
                catch( Exception ex )
                {
                    LOG.Error( "Failed to upgrade FavoritedRepos setting", ex );
                }
            }

            if( Settings.Default.DefaultRepos == null )
            {
                Settings.Default.DefaultRepos = new List<String>();
            }

            if( Settings.Default.FavoriteReposString == null )
            {
                Settings.Default.FavoriteReposString = "";
            }

            if( Settings.Default.RecentRepos == null )
            {
                Settings.Default.RecentRepos = new List<String>();
            }

            if( Settings.Default.TabContextMenuGitActions == null )
            {
                Settings.Default.TabContextMenuGitActions = new List<String>( TortoiseGit.ACTIONS.Keys );
            }

            Settings.Default.Save();
        }
    }
}
