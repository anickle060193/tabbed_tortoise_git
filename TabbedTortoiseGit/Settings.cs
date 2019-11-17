#nullable enable

using Common;
using log4net;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

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

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue( "" )]
        [EditorBrowsable( EditorBrowsableState.Never )]
        [Obsolete( "User KeyboardShortcuts instead.", true )]
        [NoSettingsVersionUpgrade]
        public Shortcut NewTabShortcut
        {
            get { throw new NotSupportedException( "NewTabShortcut is obsolete. Use KeyboardShortcuts." ); }
            set { throw new NotSupportedException( "NewTabShortcut is obsolete. Use KeyboardShortcuts." ); }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue( "" )]
        [EditorBrowsable( EditorBrowsableState.Never )]
        [Obsolete( "User KeyboardShortcuts instead.", true )]
        [NoSettingsVersionUpgrade]
        public Shortcut NextTabShortcut
        {
            get { throw new NotSupportedException( "NextTabShortcut is obsolete. Use KeyboardShortcuts." ); }
            set { throw new NotSupportedException( "NextTabShortcut is obsolete. Use KeyboardShortcuts." ); }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue( "" )]
        [EditorBrowsable( EditorBrowsableState.Never )]
        [Obsolete( "User KeyboardShortcuts instead.", true )]
        [NoSettingsVersionUpgrade]
        public Shortcut PreviousTabShortcut
        {
            get { throw new NotSupportedException( "PreviousTabShortcut is obsolete. Use KeyboardShortcuts." ); }
            set { throw new NotSupportedException( "PreviousTabShortcut is obsolete. Use KeyboardShortcuts." ); }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue( "" )]
        [EditorBrowsable( EditorBrowsableState.Never )]
        [Obsolete( "User KeyboardShortcuts instead.", true )]
        [NoSettingsVersionUpgrade]
        public Shortcut CloseTabShortcut
        {
            get { throw new NotSupportedException( "CloseTabShortcut is obsolete. Use KeyboardShortcuts." ); }
            set { throw new NotSupportedException( "CloseTabShortcut is obsolete. Use KeyboardShortcuts." ); }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue( "" )]
        [EditorBrowsable( EditorBrowsableState.Never )]
        [Obsolete( "User KeyboardShortcuts instead.", true )]
        [NoSettingsVersionUpgrade]
        public Shortcut ReopenClosedTabShortcut
        {
            get { throw new NotSupportedException( "ReopenClosedTabShortcut is obsolete. Use KeyboardShortcuts." ); }
            set { throw new NotSupportedException( "ReopenClosedTabShortcut is obsolete. Use KeyboardShortcuts." ); }
        }

        public TreeNode<FavoriteRepo> FavoriteRepos
        {
            get
            {
                TreeNode<FavoriteRepo> favoriteRepos = null;
                try
                {
                    favoriteRepos = JsonConvert.DeserializeObject<TreeNode<FavoriteRepo>>( Settings.Default.FavoriteReposJsonString, FavoriteReposContractResolver.Settings );
                }
                catch( JsonException e )
                {
                    LOG.Error( $"Failed to deserialize Favorite Repos setting - Favorited Repos:\n{Settings.Default.FavoriteReposJsonString}", e );
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
                    Settings.Default.FavoriteReposJsonString = JsonConvert.SerializeObject( value, FavoriteReposContractResolver.Settings );
                }
                catch( JsonException e )
                {
                    LOG.Error( "Failed to serialize FavoriteRepos", e );
                }
            }
        }

        public Dictionary<KeyboardShortcuts, Shortcut> KeyboardShortcuts
        {
            get
            {
                Dictionary<KeyboardShortcuts, Shortcut> keyboardShortcuts = null;
                try
                {
                    String keyboardShortcutsString = Settings.Default.KeyboardShortcutsString;
                    keyboardShortcuts = JsonConvert.DeserializeObject<Dictionary<KeyboardShortcuts, Shortcut>>( keyboardShortcutsString );
                }
                catch( JsonException e )
                {
                    LOG.Error( $"Failed to deserialize KeyboardShortcuts setting - KeyboardShortcuts: {Settings.Default.KeyboardShortcutsString}", e );
                }
                return keyboardShortcuts ?? new Dictionary<KeyboardShortcuts, Shortcut>();
            }

            set
            {
                try
                {
                    Settings.Default.KeyboardShortcutsString = JsonConvert.SerializeObject( value, Formatting.Indented );
                }
                catch( JsonException e )
                {
                    LOG.Error( "Failed to serialize KeyboardShortcuts.", e );
                }
            }
        }

        public List<CustomAction> CustomActions
        {
            get
            {
                List<CustomAction> customActions = null;
                try
                {
                    String customActionsString = Settings.Default.CustomActionsString;
                    customActions = JsonConvert.DeserializeObject<List<CustomAction>>( customActionsString );
                }
                catch( JsonException e )
                {
                    LOG.Error( $"Failed to deserialize CustomActions setting - CustomActions: {Settings.Default.CustomActionsString}", e );
                }
                return customActions ?? new List<CustomAction>();
            }

            set
            {
                try
                {
                    Settings.Default.CustomActionsString = JsonConvert.SerializeObject( value, Formatting.Indented );
                }
                catch( JsonException e )
                {
                    LOG.Error( "Failed to serialize CustomActions.", e );
                }
            }
        }

        public TreeNode<FavoriteRepo> DefaultFavoriteRepos
        {
            get
            {
                return new TreeNode<FavoriteRepo>( new FavoriteRepo( "Favorites", "", false, true, Color.Black, null ) );
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
                    LOG.Debug( $"{nameof( Settings_SettingChanging )} - Invalid Max Recent Repos: {maxRecentRepos}" );
                    e.Cancel = true;
                }
            }
            else if( e.SettingName == nameof( Settings.Default.FastSubmoduleUpdateMaxProcesses ) )
            {
                int maxProcesses = (int)e.NewValue;
                if( maxProcesses <= 0 )
                {
                    LOG.Debug( $"{nameof( Settings_SettingChanging )} - Invalid Max Fast Submodule Update Processes: {maxProcesses}" );
                    e.Cancel = true;
                }
            }
            else if( e.SettingName == nameof( Settings.Default.FastFetchMaxProcesses ) )
            {
                int maxProcesses = (int)e.NewValue;
                if( maxProcesses <= 0 )
                {
                    LOG.Debug( $"{nameof( Settings_SettingChanging )} - Invalid Max Fast Fetch Processes: {maxProcesses}" );
                    e.Cancel = true;
                }
            }
            else if( e.SettingName == nameof( Settings.Default.CheckForModifiedTabsInterval ) )
            {
                int interval = (int)e.NewValue;
                if( interval < 1000 )
                {
                    LOG.Debug( $"{nameof( Settings_SettingChanging )} - Invalid Check for Modified Tabs Interval: {interval}" );
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
                                root.Add( new FavoriteRepo( favorite.Key, favorite.Value, true, false, Color.Black, null ) );
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
                                    root.Add( new FavoriteRepo( favorite.Key, favorite.Value, true, false, Color.Black, null ) );
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

                if( Settings.Default.KeyboardShortcutsString == "" )
                {
                    Dictionary<String, KeyboardShortcuts> shortcutsMapping = new Dictionary<String, KeyboardShortcuts>()
                    {
                        { "NewTabShortcut",             TabbedTortoiseGit.KeyboardShortcuts.NewTab          },
                        { "NextTabShortcut",            TabbedTortoiseGit.KeyboardShortcuts.NextTab         },
                        { "PreviousTabShortcut",        TabbedTortoiseGit.KeyboardShortcuts.PreviousTab     },
                        { "CloseTabShortcut",           TabbedTortoiseGit.KeyboardShortcuts.CloseTab        },
                        { "ReopenClosedTabShortcut",    TabbedTortoiseGit.KeyboardShortcuts.ReopenClosedTab }
                    };

                    Dictionary<KeyboardShortcuts, Shortcut> shortcuts = new Dictionary<KeyboardShortcuts, Shortcut>();

                    foreach( KeyValuePair<String, KeyboardShortcuts> pair in shortcutsMapping )
                    {
                        try
                        {
                            Shortcut oldShortcut = Settings.Default.GetPreviousVersion( pair.Key ) as Shortcut;
                            if( oldShortcut != null )
                            {
                                shortcuts[ pair.Value ] = oldShortcut;
                            }
                        }
                        catch( SettingsPropertyNotFoundException ex )
                        {
                            LOG.Error( $"Failed to upgrade {pair.Key}.", ex );
                        }
                    }

                    Settings.Default.KeyboardShortcuts = shortcuts;
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
                Settings.Default.TabContextMenuGitActions = new List<String>( GitAction.ACTIONS.Keys );
            }

            if( Settings.Default.MaxRecentRepos <= 0 )
            {
                LOG.Debug( $"{nameof( Settings_SettingsLoaded )} - Invalid Max Recent Repos: {Settings.Default.MaxRecentRepos}" );
                Settings.Default.MaxRecentRepos = 10;
            }

            if( Settings.Default.FastSubmoduleUpdateMaxProcesses <= 0 )
            {
                LOG.Debug( $"{nameof( Settings_SettingsLoaded )} - Invalid Max Fast Submodule Update Processes: {Settings.Default.FastSubmoduleUpdateMaxProcesses}" );
                Settings.Default.FastSubmoduleUpdateMaxProcesses = 6;
            }

            if( Settings.Default.FastFetchMaxProcesses <= 0 )
            {
                LOG.Debug( $"{nameof( Settings_SettingsLoaded )} - Invalid Max Fast Fetch Processes: {Settings.Default.FastFetchMaxProcesses}" );
                Settings.Default.FastFetchMaxProcesses = 6;
            }

            if( Settings.Default.NormalTabFont == null )
            {
                Settings.Default.NormalTabFont = SystemFonts.DefaultFont;
            }

            if( Settings.Default.NormalTabFontColor.IsEmpty )
            {
                Settings.Default.NormalTabFontColor = SystemColors.ControlText;
            }

            if( Settings.Default.CheckForModifiedTabsInterval < 1000 )
            {
                LOG.Debug( $"{nameof( Settings_SettingsLoaded )} - Invalid Check for Modified Tabs Interval: {Settings.Default.CheckForModifiedTabsInterval}" );
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

            if( Settings.Default.KeyboardShortcutsString == null )
            {
                Settings.Default.KeyboardShortcutsString = "";
            }

            if( String.IsNullOrEmpty( Settings.Default.CustomActionsString ) )
            {
                Settings.Default.CustomActions = new List<CustomAction>()
                {
                    new CustomAction( "Open Console Here", "cmd.exe", "", "%r", false, false, false )
                };
            }

            Settings.Default.Save();
        }
    }
}
