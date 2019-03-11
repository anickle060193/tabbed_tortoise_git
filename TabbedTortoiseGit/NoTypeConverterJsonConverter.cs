using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TabbedTortoiseGit
{
    public class ForceJsonConverter<T> : JsonConverter
    {
        public override bool CanConvert( Type objectType )
        {
            return typeof( T ) == objectType;
        }

        private JsonSerializer CreateNoTypeSerializer()
        {
            JsonSerializerSettings settings = new JsonSerializerSettings()
            {
                DefaultValueHandling = DefaultValueHandling.Populate,
            };
            settings.ContractResolver = new ForceContractResolver();
            return JsonSerializer.CreateDefault( settings );
        }

        public override object ReadJson( JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer )
        {
            return CreateNoTypeSerializer().Deserialize( reader, objectType );
        }

        public override void WriteJson( JsonWriter writer, object value, JsonSerializer serializer )
        {
            CreateNoTypeSerializer().Serialize( writer, value );
        }

        class ForceContractResolver : DefaultContractResolver
        {
            protected override JsonContract CreateContract( Type objectType )
            {
                if( typeof( T ) == objectType )
                {
                    JsonObjectContract contract = this.CreateObjectContract( objectType );
                    contract.Converter = null;
                    return contract;
                }
                else
                {
                    return base.CreateContract( objectType );
                }
            }
        }
    }
}
