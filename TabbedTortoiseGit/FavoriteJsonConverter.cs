using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace TabbedTortoiseGit
{
    class FavoriteJsonConverter : JsonConverter
    {
        public override bool CanRead => true;
        public override bool CanWrite => false;

        public override bool CanConvert( Type objectType )
        {
            return objectType == typeof( Favorite );
        }

        public override object? ReadJson( JsonReader reader, Type objectType, object? existingValue, JsonSerializer serializer )
        {
            if( reader.TokenType == JsonToken.Null )
            {
                return null;
            }

            JObject o = JObject.Load( reader );

            FavoriteType? type = o[ nameof( Favorite.Type ) ]?.ToObject<FavoriteType>();

            if( type is null )
            {
                throw new JsonSerializationException( $"{nameof( Favorite )} does not have a {nameof( Favorite.Type )} property" );
            }

            return type switch
            {
                FavoriteType.Repo => o.ToObject<FavoriteRepo>( serializer ),
                FavoriteType.Folder => o.ToObject<FavoriteFolder>( serializer ),
                FavoriteType.ReposDirectory => o.ToObject<FavoriteReposDirectory>( serializer ),
                _ => throw new JsonSerializationException( $"Unknown {nameof( FavoriteType )}: {type}" ),
            };
        }

        public override void WriteJson( JsonWriter writer, object? value, JsonSerializer serializer )
        {
            throw new NotImplementedException( $"Should use default serialization for {nameof( Favorite )}." );
        }
    }
}
