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

namespace TabbedTortoiseGit
{
    public class FavoriteRepo
    {
        public String Name { get; private set; }
        public String Repo { get; private set; }
        public bool IsDirectory { get; private set; }
        public Color Color { get; private set; }
        public IReadOnlyList<String> References { get; private set; }

        public bool IsFavoriteFolder { get; private set; }

        [JsonConstructor]
        public FavoriteRepo( String name, String repo, bool isDirectory, bool isFavoriteFolder, Color color, IEnumerable<String> references )
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

        public override bool Equals( object obj )
        {
            return this.Equals( obj as FavoriteRepo );
        }

        public bool Equals( FavoriteRepo o )
        {
            if( (Object)o == null )
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

        public static bool operator ==( FavoriteRepo a, FavoriteRepo b )
        {
            if( Object.ReferenceEquals( a, b ) )
            {
                return true;
            }

            if( (Object)a == null || (Object)b == null )
            {
                return false;
            }

            return a.Equals( b );
        }

        public static bool operator !=( FavoriteRepo a, FavoriteRepo b )
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
}
