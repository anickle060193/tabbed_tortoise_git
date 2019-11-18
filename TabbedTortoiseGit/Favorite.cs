#nullable enable

using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using LibGit2Sharp;
using System.IO;
using Newtonsoft.Json.Converters;

namespace TabbedTortoiseGit
{
    [JsonConverter( typeof( StringEnumConverter ) )]
    public enum FavoriteType
    {
        Repo,
        Folder,
        ReposDirectory
    }

    public abstract class Favorite
    {
        public String Name { get; private set; }
        public Color Color { get; private set; }
        public FavoriteType Type { get; private set; }

        public Favorite( String name, Color color, FavoriteType type )
        {
            this.Name = name;
            this.Color = color;
            this.Type = type;
        }

        public override string ToString()
        {
            return $"Name={this.Name}, Color={this.Color}, Type={this.Type}";
        }
    }

    public class FavoriteRepo : Favorite
    {
        public String Repo { get; private set; }
        public bool IsDirectory { get; private set; }
        public IReadOnlyList<String> References { get; private set; }

        [JsonConstructor]
        public FavoriteRepo( String name, String repo, bool isDirectory, Color color, IEnumerable<String>? references ) : base( name, color, FavoriteType.Repo )
        {
            this.Repo = repo;
            this.IsDirectory = isDirectory;
            this.References = references?.ToList().AsReadOnly() ?? new List<String>().AsReadOnly();
        }

        public override string ToString()
        {
            return $"{nameof( FavoriteRepo )}( {base.ToString()} Repo={this.Repo}, IsDirectory={this.IsDirectory}, References={this.References} )";
        }
    }

    public class FavoriteFolder : Favorite
    {
        public List<Favorite> Children { get; private set; }

        public FavoriteFolder( String name, Color color ): this( name, color, Enumerable.Empty<Favorite>() )
        {
        }

        [JsonConstructor]
        public FavoriteFolder( String name, Color color, IEnumerable<Favorite> children ) : base( name, color, FavoriteType.Folder )
        {
            this.Children = children.ToList();
        }

        public Favorite? BreadFirstSearch( Func<Favorite, bool> selector )
        {
            Queue<Favorite> toSearch = new Queue<Favorite>( new[] { this } );

            while( toSearch.Count > 0 )
            {
                Favorite f = toSearch.Dequeue();

                if( selector( f ) )
                {
                    return f;
                }

                if( f is FavoriteFolder folder )
                {
                    foreach( Favorite child in folder.Children )
                    {
                        toSearch.Enqueue( child );
                    }
                }
            }

            return null;
        }

        public bool Remove( Favorite favorite )
        {
            if( this.Children.Remove( favorite ) )
            {
                return true;
            }
            else
            {
                foreach( Favorite child in this.Children )
                {
                    if( child is FavoriteFolder folder
                     && folder.Remove( favorite ) )
                    {
                        return true;
                    }
                }
                return false;
            }
        }

        public bool Replace( Favorite oldFavorite, Favorite newFavorite )
        {
            int index = this.Children.IndexOf( oldFavorite );
            if( index >= 0 )
            {
                this.Children[ index ] = newFavorite;
                return true;
            }
            else
            {
                foreach( Favorite child in this.Children )
                {
                    if( child is FavoriteFolder folder
                     && folder.Replace( oldFavorite, newFavorite ) )
                    {
                        return true;
                    }
                }
                return false;
            }
        }

        public override string ToString()
        {
            return $"{nameof( FavoriteFolder )}( {base.ToString()} Children={this.Children} )";
        }
    }

    public class FavoriteReposDirectory : Favorite
    {
        public String Directory { get; private set; }

        [JsonIgnore]
        public List<Favorite> Children
        {
            get
            {
                return System.IO.Directory
                    .GetDirectories( this.Directory )
                    .Where( ( dir ) => Repository.IsValid( dir ) )
                    .Select( ( dir ) => new FavoriteRepo( Native.GetRelativePath( this.Directory, dir ), dir, true, this.Color, null ) )
                    .ToList<Favorite>();
            }
        }

        [JsonConstructor]
        public FavoriteReposDirectory( String name, String directory, Color color ): base( name, color, FavoriteType.ReposDirectory )
        {
            this.Directory = directory;
        }

        public override string ToString()
        {
            return $"{nameof( FavoriteReposDirectory )}( {base.ToString()} Directory={this.Directory} )";
        }
    }
}
