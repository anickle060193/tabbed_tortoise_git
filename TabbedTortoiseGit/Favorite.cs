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
using System.Collections;

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

        [JsonIgnore]
        public FavoriteFolder? Parent { get; set; }

        [JsonIgnore]
        public FavoriteFolder? Root
        {
            get
            {
                FavoriteFolder? parent = this.Parent;
                while( parent?.Parent != null )
                {
                    parent = parent?.Parent;
                }
                return parent;
            }
        }

        [JsonIgnore]
        public Favorite? Previous
        {
            get
            {
                if( this.Index > 0 )
                {
                    return this.Parent?.Children[ this.Index - 1 ];
                }
                else
                {
                    return null;
                }
            }
        }

        [JsonIgnore]
        public Favorite? Next
        {
            get
            {
                if( this.Parent == null )
                {
                    return null;
                }
                else if( this.Index + 1 >= this.Parent.Children.Count )
                {
                    return null;
                }
                else
                {
                    return this.Parent.Children[ this.Index + 1 ];
                }
            }
        }

        [JsonIgnore]
        public int Index
        {
            get
            {
                if( this.Parent != null )
                {
                    return this.Parent.Children.IndexOf( this );
                }
                else
                {
                    return -1;
                }
            }
        }

        [JsonIgnore]
        public int NestedIndex
        {
            get
            {
                if( this.Parent == null )
                {
                    return 0;
                }
                else
                {
                    int index = this.Parent.NestedIndex + 1;
                    foreach( Favorite child in this.Parent.Children )
                    {
                        if( child == this )
                        {
                            break;
                        }

                        index++;

                        if( child is FavoriteFolder cf )
                        {
                            index += cf.NestedCount;
                        }
                    }

                    return index;
                }
            }
        }

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
        public FavoriteCollection Children { get; private set; }

        [JsonIgnore]
        public int NestedCount
        {
            get
            {
                return this.Children.Count + this.Children.Sum( child => ( child as FavoriteFolder )?.NestedCount ?? 0 );
            }
        }

        public FavoriteFolder( String name, Color color ): this( name, color, Enumerable.Empty<Favorite>() )
        {
        }

        [JsonConstructor]
        public FavoriteFolder( String name, Color color, IEnumerable<Favorite> children ) : base( name, color, FavoriteType.Folder )
        {
            this.Children = new FavoriteCollection( this );
            this.Children.AddRange( children );
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

        public FavoriteFolder? FindParent( Favorite favorite )
        {
            return this.BreadFirstSearch( ( f ) => f is FavoriteFolder ff && ff.Children.Contains( favorite ) ) as FavoriteFolder;
        }

        public bool NestedContains( Favorite favorite )
        {
            return this.Children.Contains( favorite )
                || this.Children.OfType<FavoriteFolder>().Any( ( c ) => c.NestedContains( favorite ) );
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

        public bool InsertBefore( Favorite reference, Favorite newFavorite )
        {
            int index = this.Children.IndexOf( reference );
            if( index >= 0 )
            {
                this.Children.Insert( index, newFavorite );
                return true;
            }
            else
            {
                foreach( Favorite child in this.Children )
                {
                    if( child is FavoriteFolder folder
                     && folder.InsertBefore( reference, newFavorite ) )
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

        public class FavoriteCollection : IList<Favorite>
        {
            private readonly List<Favorite> _children = new List<Favorite>();
            private readonly FavoriteFolder _owner;

            public FavoriteCollection( FavoriteFolder owner )
            {
                _owner = owner;
            }

            public Favorite this[ int index ]
            {
                get
                {
                    if( index < 0 || index >= this.Count )
                    {
                        throw new ArgumentOutOfRangeException( nameof( index ) );
                    }

                    return _children[ index ];
                }

                set
                {
                    if( index < 0 || index >= this.Count )
                    {
                        throw new ArgumentOutOfRangeException( nameof( index ) );
                    }
                    if( value == null )
                    {
                        throw new ArgumentNullException( nameof( value ) );
                    }
                    if( this.Contains( value ) )
                    {
                        throw new ArgumentException( "Node already exists as child of this node.", nameof( value ) );
                    }
                    if( value.Parent != null )
                    {
                        throw new ArgumentException( "Node is already a child of another node.", nameof( value ) );
                    }

                    Favorite oldNode = _children[ index ];
                    oldNode.Parent = null;

                    _children[ index ] = value;
                    value.Parent = _owner;
                }
            }

            public int Count
            {
                get
                {
                    return _children.Count;
                }
            }

            public bool IsReadOnly
            {
                get
                {
                    return false;
                }
            }

            public void Add( Favorite node )
            {
                this.Insert( this.Count, node );
            }

            public void AddRange( IEnumerable<Favorite> nodes )
            {
                if( nodes == null )
                {
                    throw new ArgumentException( nameof( nodes ) );
                }

                foreach( Favorite node in nodes )
                {
                    this.Add( node );
                }
            }

            public void Clear()
            {
                while( this.Count > 0 )
                {
                    this.Remove( this[ 0 ] );
                }
            }

            public bool Contains( Favorite node )
            {
                if( node == null )
                {
                    throw new ArgumentNullException( nameof( node ) );
                }

                return _children.Contains( node );
            }

            public void CopyTo( Favorite[] array, int arrayIndex )
            {
                throw new InvalidOperationException();
            }

            public IEnumerator<Favorite> GetEnumerator()
            {
                return _children.GetEnumerator();
            }

            public int IndexOf( Favorite node )
            {
                if( node == null )
                {
                    throw new ArgumentNullException( nameof( node ) );
                }

                return _children.IndexOf( node );
            }

            public void Insert( int index, Favorite node )
            {
                if( index < 0 || index > this.Count )
                {
                    throw new ArgumentOutOfRangeException( nameof( index ) );
                }
                if( node == null )
                {
                    throw new ArgumentNullException( nameof( node ) );
                }
                if( this.Contains( node ) )
                {
                    throw new ArgumentException( "Node already exists as child of this node.", nameof( node ) );
                }
                if( node.Parent != null )
                {
                    throw new ArgumentException( "Node is already a child of another node.", nameof( node ) );
                }

                _children.Insert( index, node );
                node.Parent = _owner;
            }

            public bool Remove( Favorite node )
            {
                if( node == null )
                {
                    throw new ArgumentNullException( nameof( node ) );
                }

                int index = this.IndexOf( node );
                if( index != -1 )
                {
                    this.RemoveAt( index );
                    return true;
                }
                else
                {
                    return false;
                }
            }

            public void RemoveAt( int index )
            {
                if( index < 0 || index >= this.Count )
                {
                    throw new ArgumentOutOfRangeException( nameof( index ) );
                }

                Favorite node = this[ index ];
                node.Parent = null;
                _children.RemoveAt( index );
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return ( (IEnumerable)_children ).GetEnumerator();
            }
        }
    }

    public class FavoriteReposDirectory : Favorite
    {
        public String Directory { get; private set; }

        [JsonConstructor]
        public FavoriteReposDirectory( String name, String directory, Color color ): base( name, color, FavoriteType.ReposDirectory )
        {
            this.Directory = directory;
        }

        public List<Favorite> GetRepos()
        {
            return System.IO.Directory
                .GetDirectories( this.Directory )
                .Where( ( dir ) => Repository.IsValid( dir ) )
                .Select( ( dir ) =>
                {
                    String name = dir.Replace( this.Directory, "" ).TrimStart( Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar );
                    return new FavoriteReposDirectoryRepo( name, dir, this.Color );
                } )
                .ToList<Favorite>();
        }

        public override string ToString()
        {
            return $"{nameof( FavoriteReposDirectory )}( {base.ToString()} Directory={this.Directory} )";
        }
    }

    public class FavoriteReposDirectoryRepo : Favorite
    {
        public String Repo { get; private set; }

        [JsonConstructor]
        public FavoriteReposDirectoryRepo( String name, String repo, Color color ) : base( name, color, FavoriteType.Repo )
        {
            this.Repo = repo;
        }

        public override string ToString()
        {
            return $"{nameof( FavoriteReposDirectoryRepo )}( {base.ToString()} Repo={this.Repo} )";
        }
    }
}
