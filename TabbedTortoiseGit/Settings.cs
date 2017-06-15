using log4net;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Diagnostics;
using System.Drawing;

namespace TabbedTortoiseGit.Properties
{
    internal sealed partial class Settings
    {
        private static readonly ILog LOG = LogManager.GetLogger( typeof( Settings ) );

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue( "" )]
        [EditorBrowsable( EditorBrowsableState.Never )]
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
        [EditorBrowsable( EditorBrowsableState.Never )]
        [Obsolete( "User FavoriteReposJsonString instead.", true )]
        [NoSettingsVersionUpgrade]
        public String FavoriteReposString
        {
            get { throw new NotSupportedException( "FavoriteReposString is obsolete. Use FavoriteReposJsonString." ); }
            set { throw new NotSupportedException( "FavoriteReposString is obsolete. Use FavoriteReposJsonString." ); }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue( "" )]
        [EditorBrowsable( EditorBrowsableState.Never )]
        [Obsolete( "User StartupRepos instead.", true )]
        [NoSettingsVersionUpgrade]
        public List<String> DefaultRepos
        {
            get { throw new NotSupportedException( "DefaultRepos is obsolete. Use StartupRepos." ); }
            set { throw new NotSupportedException( "DefaultRepos is obsolete. Use StartupRepos." ); }
        }

        public TreeNode<FavoriteRepo> FavoriteRepos
        {
            get
            {
                TreeNode<FavoriteRepo> favoriteRepos = null;
                try
                {
                    favoriteRepos = JsonConvert.DeserializeObject<TreeNode<FavoriteRepo>>( Settings.Default.FavoriteReposJsonString );
                }
                catch( JsonException e )
                {
                    LOG.ErrorFormat( "Failed to deserialize Favorite Repos setting - Favorited Repos:\n{0}", Settings.Default.FavoriteReposJsonString );
                    LOG.Error( e );
                }

                if( favoriteRepos == null || favoriteRepos.Value != Settings.Default.DefaultFavoriteRepos.Value )
                {
                    return Settings.Default.DefaultFavoriteRepos;
                }
                else
                {
                    return favoriteRepos;
                }
            }

            set
            {
                try
                {
                    Settings.Default.FavoriteReposJsonString = JsonConvert.SerializeObject( value );
                }
                catch( JsonException e )
                {
                    LOG.Error( "Failed to serialize FavoriteRepos", e );
                }
            }
        }

        public TreeNode<FavoriteRepo> DefaultFavoriteRepos
        {
            get
            {
                return new TreeNode<FavoriteRepo>( new FavoriteRepo( "Favorites", "", false, true ) );
            }
        }

        public Font DefaultModifiedTabFont
        {
            get
            {
                return new Font( SystemFonts.DefaultFont, FontStyle.Bold );
            }
        }

        public Color DefaultModifiedTabFontColor
        {
            get
            {
                return Color.DarkBlue;
            }
        }

        public Settings()
        {
            this.SettingsLoaded += Settings_SettingsLoaded;
            this.SettingChanging += Settings_SettingChanging;
        }

        private void Settings_SettingChanging( object sender, SettingChangingEventArgs e )
        {
            if( e.SettingName == nameof( Settings.Default.MaxRecentRepos ) )
            {
                int maxRecentRepos = (int)e.NewValue;
                if( maxRecentRepos <= 0 )
                {
                    LOG.DebugFormat( "Settings Changing - Invalid Max Recent Repos: {0}", maxRecentRepos );
                    e.Cancel = true;
                }
            }
            else if( e.SettingName == nameof( Settings.Default.FastSubmoduleUpdateMaxProcesses ) )
            {
                int maxProcesses = (int)e.NewValue;
                if( maxProcesses <= 0 )
                {
                    LOG.DebugFormat( "Settings Changing - Invalid Max Fast Submodule Update Processes: {0}", maxProcesses );
                    e.Cancel = true;
                }
            }
            else if( e.SettingName == nameof( Settings.Default.FastFetchMaxProcesses ) )
            {
                int maxProcesses = (int)e.NewValue;
                if( maxProcesses <= 0 )
                {
                    LOG.DebugFormat( "Settings Changing - Invalid Max Fast Fetch Processes: {0}", maxProcesses );
                    e.Cancel = true;
                }
            }
            else if( e.SettingName == nameof( Settings.Default.CheckForModifiedTabsInterval ) )
            {
                int interval = (int)e.NewValue;
                if( interval < 1000 )
                {
                    LOG.DebugFormat( "Settings Changing - Invalid Check for Modified Tabs Interval: {0}", interval );
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

                bool upgradedRepoString = false;
                try
                {
                    String reposString = Settings.Default.GetPreviousVersion( "FavoriteReposString" ) as String;
                    if( reposString != null )
                    {
                        Dictionary<String, String> favoritedRepos = JsonConvert.DeserializeObject<Dictionary<String, String>>( reposString );

                        TreeNode<FavoriteRepo> root = Settings.Default.DefaultFavoriteRepos;

                        if( favoritedRepos != null )
                        {
                            foreach( KeyValuePair<String, String> favorite in favoritedRepos )
                            {
                                root.Add( new FavoriteRepo( favorite.Key, favorite.Value, false, false ) );
                            }
                        }

                        Settings.Default.FavoriteRepos = root;

                        upgradedRepoString = true;
                    }
                }
                catch( SettingsPropertyNotFoundException ex )
                {
                    LOG.Error( "Failed to upgrade FavoriteReposString setting", ex );
                }
                catch( JsonException ex )
                {
                    LOG.Error( "Failed to upgrade FavoriteReposString setting", ex );
                }

                if( !upgradedRepoString )
                {
                    try
                    {
                        String reposString = Settings.Default.GetPreviousVersion( "FavoritedRepos" ) as String;
                        if( reposString != null )
                        {
                            Dictionary<String, String> favoritedRepos = JsonConvert.DeserializeObject<Dictionary<String, String>>( reposString );

                            TreeNode<FavoriteRepo> root = Settings.Default.DefaultFavoriteRepos;

                            if( favoritedRepos != null )
                            {
                                foreach( KeyValuePair<String, String> favorite in favoritedRepos )
                                {
                                    root.Add( new FavoriteRepo( favorite.Key, favorite.Value, false, false ) );
                                }
                            }

                            Settings.Default.FavoriteRepos = root;

                            upgradedRepoString = true;
                        }
                    }
                    catch( SettingsPropertyNotFoundException ex )
                    {
                        LOG.Error( "Failed to upgrade FavoritedRepos setting", ex );
                    }
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

            if( Settings.Default.FavoriteReposJsonString == null )
            {
                Settings.Default.FavoriteReposJsonString = "";
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

            if( Settings.Default.FastFetchMaxProcesses <= 0 )
            {
                LOG.DebugFormat( "Settings Load - Invalid Max Fast Fetch Processes: {0}", Settings.Default.FastFetchMaxProcesses );
                Settings.Default.FastFetchMaxProcesses = 6;
            }

            if( Settings.Default.CheckForModifiedTabsInterval < 1000 )
            {
                LOG.DebugFormat( "Settings Load - Invalid Check for Modified Tabs Interval: {0}", Settings.Default.CheckForModifiedTabsInterval );
                Settings.Default.CheckForModifiedTabsInterval = 1000;
            }

            if( Settings.Default.ModifiedTabFont == null )
            {
                Settings.Default.ModifiedTabFont = Settings.Default.DefaultModifiedTabFont;
            }

            if( Settings.Default.ModifiedTabFontColor.IsEmpty )
            {
                Settings.Default.ModifiedTabFontColor = Settings.Default.DefaultModifiedTabFontColor;
            }

            Settings.Default.Save();
        }
    }
}
