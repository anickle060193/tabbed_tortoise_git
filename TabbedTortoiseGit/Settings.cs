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
        [Obsolete( "User FavoriteRepos instead.", true )]
        [NoSettingsVersionUpgrade]
        public String FavoritedRepos
        {
            get { throw new NotSupportedException( "FavoritedRepos is obsolete. Use FavoriteRepos." ); }
            set { throw new NotSupportedException( "FavoritedRepos is obsolete. Use FavoriteRepos." ); }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue( "" )]
        [Obsolete( "User StartupRepos instead.", true )]
        [NoSettingsVersionUpgrade]
        public List<String> DefaultRepos
        {
            get { throw new NotSupportedException( "DefaultRepos is obsolete. Use StartupRepos." ); }
            set { throw new NotSupportedException( "DefaultRepos is obsolete. Use StartupRepos." ); }
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
            this.SettingChanging += Settings_SettingChanging;
        }

        private void Settings_SettingChanging( object sender, SettingChangingEventArgs e )
        {
            if( e.SettingName == "MaxRecentRepos" )
            {
                int maxRecentRepos = (int)e.NewValue;
                if( maxRecentRepos <= 0 )
                {
                    LOG.DebugFormat( "Settings Changing - Invalid Max Recent Repos: {0}", maxRecentRepos );
                    e.Cancel = true;
                }
            }
            else if( e.SettingName == "FastSubmoduleUpdateMaxProcesses" )
            {
                int maxProcesses = (int)e.NewValue;
                if( maxProcesses <= 0 )
                {
                    LOG.DebugFormat( "Settings Changing - Invalid Max Fast Submodule Update Processes: {0}", maxProcesses );
                    e.Cancel = true;
                }
            }
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
                        LOG.Debug( "Upgraded FavoritedRepos to FavoriteReposString" );
                    }
                }
                catch( SettingsPropertyNotFoundException ex )
                {
                    LOG.Error( "Failed to upgrade FavoritedRepos setting", ex );
                }

                try
                {
                    Object oldValue = Settings.Default.GetPreviousVersion( "DefaultRepos" );
                    if( oldValue != null && oldValue is List<String> )
                    {
                        Settings.Default.StartupRepos = (List<String>)oldValue;
                        LOG.Debug( "Upgraded DefaultRepos to StartupRepos" );
                    }
                }
                catch( SettingsPropertyNotFoundException ex )
                {
                    LOG.Error( "Failed to upgrade DefaultRepos setting", ex );
                }
            }

            if( Settings.Default.StartupRepos == null )
            {
                Settings.Default.StartupRepos = new List<String>();
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

            if( Settings.Default.MaxRecentRepos <= 0 )
            {
                LOG.DebugFormat( "Settings Load - Invalid Max Recent Repos: {0}", Settings.Default.MaxRecentRepos );
                Settings.Default.MaxRecentRepos = 10;
            }

            if( Settings.Default.FastSubmoduleUpdateMaxProcesses <= 0 )
            {
                LOG.DebugFormat( "Settings Load - Invalid Max Fast Submodule Update Processes: {0}", Settings.Default.FastSubmoduleUpdateMaxProcesses );
                Settings.Default.FastSubmoduleUpdateMaxProcesses = 6;
            }

            Settings.Default.Save();
        }
    }
}
