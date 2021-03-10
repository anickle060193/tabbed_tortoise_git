using Common;
using GlobExpressions;
using log4net;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace TabbedTortoiseGit.Properties
{
    internal sealed partial class Settings
    {
        private static readonly ILog LOG = LogManager.GetLogger( typeof( Settings ) );

        public static void Restore()
        {
            LOG.Debug( "Restoring Settings" );
            
            var currentSettingsFile = ConfigurationManager.OpenExeConfiguration( ConfigurationUserLevel.PerUserRoamingAndLocal ).FilePath;
            LOG.Debug( $"Current Settings File: {currentSettingsFile}" );

            var localAppData = new DirectoryInfo( Environment.GetFolderPath( Environment.SpecialFolder.LocalApplicationData ) );
            var settingsFile = Glob.Files( localAppData, "Tabbed*TortoiseGit/Tabbed*TortoiseGit*/*/user.config" )
                .Where( ( f ) => f.FullName != currentSettingsFile )
                .OrderBy( ( f ) => f.LastWriteTime )
                .LastOrDefault();
            LOG.Debug( $"Previous Settings File: {settingsFile?.FullName}" );

            if( settingsFile != null )
            {
                LOG.Debug( "Copying previous settings file to current settings file" );
                Directory.CreateDirectory( Path.GetDirectoryName( currentSettingsFile )! );
                settingsFile.CopyTo( currentSettingsFile, true );

                LOG.Debug( "Reloading settings" );
                Settings.Default.Reload();
            }
        }

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

        public FavoriteFolder FavoriteRepos
        {
            get
            {
                FavoriteFolder? favoriteRepos = null;
                try
                {
                    favoriteRepos = JsonConvert.DeserializeObject<FavoriteFolder>( Settings.Default.FavoriteReposJsonString, new JsonSerializerSettings()
                    {
                        Converters = new [] { new FavoriteJsonConverter() }
                    } );
                }
                catch( JsonException e )
                {
                    LOG.Error( $"Failed to deserialize Favorite Repos setting - Favorited Repos:\n{Settings.Default.FavoriteReposJsonString}", e );
                }

                if( favoriteRepos == null )
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
                    Settings.Default.FavoriteReposJsonString = JsonConvert.SerializeObject( value, Formatting.Indented );
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
                Dictionary<KeyboardShortcuts, Shortcut>? keyboardShortcuts = null;
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
                List<CustomAction>? customActions = null;
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

        public FavoriteFolder DefaultFavoriteRepos
        {
            get
            {
                return new FavoriteFolder( "Favorites", Color.Black );
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

        private void Settings_SettingChanging( object? sender, SettingChangingEventArgs e )
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
            else if( e.SettingName == nameof( Settings.Default.FasterSubmoduleUpdateMaxProcesses ) )
            {
                int maxProcesses = (int)e.NewValue;
                if( maxProcesses <= 0 )
                {
                    LOG.Debug( $"{nameof( Settings_SettingChanging )} - Invalid Max Faster Submodule Update Processes: {maxProcesses}" );
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

        private void Settings_SettingsLoaded( object? sender, SettingsLoadedEventArgs e )
        {
            if( Settings.Default.UpgradeRequired )
            {
                LOG.Debug( "Upgrading settings" );
                Settings.Default.Upgrade();
                Settings.Default.UpgradeRequired = false;

                if( Settings.Default.LastVersion is null or "" )
                {
                    try
                    {
                        LOG.Debug( "Triggering automatic settings restore" );
                        Settings.Restore();
                        LOG.Debug( "Successfully restored settings" );
                    }
                    catch( Exception ex )
                    {
                        LOG.Error( "Failed to restore settings:", ex );
                    }
                }

                Settings.Default.LastVersion = Assembly.GetExecutingAssembly().GetName().Version?.ToString() ?? "Unknown";

                bool upgradedFavoriteReposString = false;
                try
                {
                    if( Settings.Default.GetPreviousVersion( "FavoriteReposString" ) is String reposString )
                    {
                        Dictionary<String, String> favoritedRepos = JsonConvert.DeserializeObject<Dictionary<String, String>>( reposString );

                        FavoriteFolder root = Settings.Default.DefaultFavoriteRepos;

                        if( favoritedRepos != null )
                        {
                            foreach( KeyValuePair<String, String> favorite in favoritedRepos )
                            {
                                root.Children.Add( new FavoriteRepo( favorite.Key, favorite.Value, true, Color.Black, null ) );
                            }
                        }

                        Settings.Default.FavoriteRepos = root;

                        upgradedFavoriteReposString = true;
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

                if( !upgradedFavoriteReposString )
                {
                    try
                    {
                        if( Settings.Default.GetPreviousVersion( "FavoritedRepos" ) is String reposString )
                        {
                            Dictionary<String, String> favoritedRepos = JsonConvert.DeserializeObject<Dictionary<String, String>>( reposString );

                            FavoriteFolder root = Settings.Default.DefaultFavoriteRepos;

                            if( favoritedRepos != null )
                            {
                                foreach( KeyValuePair<String, String> favorite in favoritedRepos )
                                {
                                    root.Children.Add( new FavoriteRepo( favorite.Key, favorite.Value, true, Color.Black, null ) );
                                }
                            }

                            Settings.Default.FavoriteRepos = root;

                            upgradedFavoriteReposString = true;
                        }
                    }
                    catch( SettingsPropertyNotFoundException ex )
                    {
                        LOG.Error( "Failed to upgrade FavoritedRepos setting", ex );
                    }
                }

                if( !upgradedFavoriteReposString )
                {
                    String favoriteReposString = Settings.Default.FavoriteReposJsonString;
                    if( !String.IsNullOrEmpty( favoriteReposString )
                     && !favoriteReposString.Contains( "\"Type\":" ) )
                    {
                        try
                        {
                            TreeNode<OldFavoriteRepo>? favoriteRepos = JsonConvert.DeserializeObject<TreeNode<OldFavoriteRepo>>( Settings.Default.FavoriteReposJsonString, OldFavoriteReposContractResolver.Settings );
                            if( favoriteRepos != null )
                            {
                                Favorite favorites = OldTreeNodeFavoriteToFavorite( favoriteRepos );
                                if( favorites is FavoriteFolder folder )
                                {
                                    Settings.Default.FavoriteRepos = folder;
                                    upgradedFavoriteReposString = true;
                                    LOG.Debug( "Upgraded tree-based FavoriteRepos to new Favorites" );
                                }
                                else
                                {
                                    FavoriteFolder f = Settings.Default.DefaultFavoriteRepos;
                                    f.Children.Add( favorites );

                                    Settings.Default.FavoriteRepos = f;
                                    upgradedFavoriteReposString = true;
                                    LOG.Debug( "Upgraded tree-based FavoriteRepos to new Favorites" );
                                }
                            }
                        }
                        catch( JsonException ex )
                        {
                            LOG.Error( $"Failed to upgrade FavoriteReposJsonString setting to new subclassed FavoriteRepos - Favorite Repos Json String:\n{favoriteReposString}", ex );
                        }
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
                            if( Settings.Default.GetPreviousVersion( pair.Key ) is Shortcut oldShortcut )
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
                LOG.Debug( $"{nameof( Settings_SettingsLoaded )} - Invalid Max Fast Submodule Update Processes: {Settings.Default.FastSubmoduleUpdateMaxProcesses} -> {TTG.DefaultMaxProcesses}" );
                Settings.Default.FastSubmoduleUpdateMaxProcesses = TTG.DefaultMaxProcesses;
            }

            if( Settings.Default.FasterSubmoduleUpdateMaxProcesses <= 0 )
            {
                LOG.Debug( $"{nameof( Settings_SettingsLoaded )} - Invalid Max Faster Submodule Update Processes: {Settings.Default.FasterSubmoduleUpdateMaxProcesses} -> {TTG.DefaultMaxProcesses}" );
                Settings.Default.FasterSubmoduleUpdateMaxProcesses = TTG.DefaultMaxProcesses;
            }

            if( Settings.Default.FastFetchMaxProcesses <= 0 )
            {
                LOG.Debug( $"{nameof( Settings_SettingsLoaded )} - Invalid Max Fast Fetch Processes: {Settings.Default.FastFetchMaxProcesses} -> {TTG.DefaultMaxProcesses}" );
                Settings.Default.FastFetchMaxProcesses = TTG.DefaultMaxProcesses;
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

        private Favorite OldTreeNodeFavoriteToFavorite( TreeNode<OldFavoriteRepo> favorite )
        {
            if( favorite.Value.IsFavoriteFolder )
            {
                return new FavoriteFolder( favorite.Value.Name, favorite.Value.Color, favorite.Children.Select( OldTreeNodeFavoriteToFavorite ) );
            }
            else
            {
                return new FavoriteRepo( favorite.Value.Name, favorite.Value.Repo, favorite.Value.IsDirectory, favorite.Value.Color, favorite.Value.References );
            }
        }

        private class OldFavoriteRepo
        {
            public String Name { get; private set; }
            public String Repo { get; private set; }
            public bool IsDirectory { get; private set; }
            public Color Color { get; private set; }
            public IReadOnlyList<String> References { get; private set; }

            public bool IsFavoriteFolder { get; private set; }

            [JsonConstructor]
            public OldFavoriteRepo( String name, String repo, bool isDirectory, bool isFavoriteFolder, Color color, IEnumerable<String>? references )
            {
                Name = name ?? "";
                Color = color;

                IsFavoriteFolder = isFavoriteFolder;
                if( !IsFavoriteFolder )
                {
                    Repo = repo ?? "";
                    IsDirectory = isDirectory;
                    References = references?.ToList().AsReadOnly() ?? new List<String>().AsReadOnly();
                }
                else
                {
                    Repo = "";
                    IsDirectory = false;
                    References = new List<String>().AsReadOnly();
                }
            }

            public override bool Equals( object? obj )
            {
                return this.Equals( obj as FavoriteRepo );
            }

            public bool Equals( OldFavoriteRepo? o )
            {
                if( o is null )
                {
                    return false;
                }

                if( this.Name != o.Name )
                {
                    return false;
                }

                if( this.Repo != o.Repo )
                {
                    return false;
                }

                if( this.IsDirectory != o.IsDirectory )
                {
                    return false;
                }

                if( this.IsFavoriteFolder != o.IsFavoriteFolder )
                {
                    return false;
                }

                return true;
            }

            public static bool operator ==( OldFavoriteRepo? a, OldFavoriteRepo? b )
            {
                if( Object.ReferenceEquals( a, b ) )
                {
                    return true;
                }

                if( a is null || b is null )
                {
                    return false;
                }

                return a.Equals( b );
            }

            public static bool operator !=( OldFavoriteRepo a, OldFavoriteRepo b )
            {
                return !( a == b );
            }

            public override int GetHashCode()
            {
                unchecked
                {
                    int hash = 23;
                    hash = ( hash * 29 ) ^ ( this.Name?.GetHashCode() ?? 0 );
                    hash = ( hash * 31 ) ^ ( this.Repo?.GetHashCode() ?? 0 );
                    hash = ( hash * 37 ) ^ this.IsDirectory.GetHashCode();
                    hash = ( hash * 41 ) ^ this.IsFavoriteFolder.GetHashCode();
                    return hash;
                }
            }
        }

        class OldFavoriteReposContractResolver : DefaultContractResolver
        {
            public static readonly OldFavoriteReposContractResolver Instance = new OldFavoriteReposContractResolver();

            public static JsonSerializerSettings Settings
            {
                get
                {
                    return new JsonSerializerSettings()
                    {
                        ContractResolver = Instance,
                        Formatting = Formatting.Indented
                    };
                }
            }

            protected override JsonProperty CreateProperty( MemberInfo member, MemberSerialization memberSerialization )
            {
                JsonProperty property = base.CreateProperty( member, memberSerialization );

                if( property.DeclaringType == typeof( OldFavoriteRepo ) )
                {
                    if( property.PropertyName == nameof( OldFavoriteRepo.Repo ) )
                    {
                        property.ShouldSerialize = ShouldNotSerializeIfFavoriteFolder;
                        property.DefaultValue = false;
                    }
                    else if( property.PropertyName == nameof( OldFavoriteRepo.IsDirectory ) )
                    {
                        property.ShouldSerialize = ShouldNotSerializeIfFavoriteFolder;
                        property.DefaultValue = false;
                    }
                    else if( property.PropertyName == nameof( OldFavoriteRepo.References ) )
                    {
                        property.ShouldSerialize = ( instance ) =>
                        {
                            OldFavoriteRepo favoriteRepo = (OldFavoriteRepo)instance;
                            return !favoriteRepo.IsFavoriteFolder && favoriteRepo.References.Count > 0;
                        };
                    }
                }
                else if( property.DeclaringType == typeof( TreeNode<OldFavoriteRepo> ) )
                {
                    if( property.PropertyName == nameof( TreeNode<OldFavoriteRepo>.Children ) )
                    {
                        property.ShouldSerialize = ( instance ) =>
                        {
                            TreeNode<OldFavoriteRepo> favorite = (TreeNode<OldFavoriteRepo>)instance;
                            return favorite.Children.Count > 0;
                        };
                    }
                }

                return property;
            }

            private bool ShouldNotSerializeIfFavoriteFolder( Object instance )
            {
                return !( (OldFavoriteRepo)instance ).IsFavoriteFolder;
            }
        }
    }
}
