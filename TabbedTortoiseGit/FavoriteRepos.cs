using Common;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TabbedTortoiseGit
{
    class FavoriteRepo
    {
        public String Name { get; private set; }
        public String Repo { get; private set; }

        public FavoriteRepo( String name, String repo )
        {
            Name = name;
            Repo = repo;
        }

        public override string ToString()
        {
            return "{{ {0} : {1} }}".XFormat( Name, Repo );
        }
    }

    class FavoriteRepos
    {
        public Dictionary<String, FavoriteRepos> SubFavorites { get; private set; }
        public List<FavoriteRepo> Favorites { get; private set; }

        private FavoriteRepos()
        {
            SubFavorites = new Dictionary<String, FavoriteRepos>();
            Favorites = new List<FavoriteRepo>();
        }

        private FavoriteRepos( JToken token ) : this()
        {
            foreach( KeyValuePair<String, JToken> entry in (JObject)token )
            {
                if( entry.Value.Type == JTokenType.String )
                {
                    FavoriteRepo r = new FavoriteRepo( entry.Key, (String)( (JValue)entry.Value ) );
                    Favorites.Add( r );
                }
                else
                {
                    SubFavorites.Add( entry.Key, new FavoriteRepos( entry.Value ) );
                }
            }
        }

        public static FavoriteRepos Parse( String json )
        {
            try
            {
                JToken token = JToken.Parse( json );
                return new FavoriteRepos( token );
            }
            catch( Exception e )
            {

            }
            return new FavoriteRepos();
        }
    }
}
