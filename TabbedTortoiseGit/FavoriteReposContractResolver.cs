using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Reflection;

namespace TabbedTortoiseGit
{
    class FavoriteReposContractResolver : DefaultContractResolver
    {
        public static readonly FavoriteReposContractResolver Instance = new FavoriteReposContractResolver();

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

            if( property.DeclaringType == typeof( FavoriteRepo ) )
            {
                if( property.PropertyName == nameof( FavoriteRepo.Repo ) )
                {
                    property.ShouldSerialize = ShouldNotSerializeIfFavoriteFolder;
                    property.DefaultValue = false;
                }
                else if( property.PropertyName == nameof( FavoriteRepo.IsDirectory ) )
                {
                    property.ShouldSerialize = ShouldNotSerializeIfFavoriteFolder;
                    property.DefaultValue = false;
                }
                else if( property.PropertyName == nameof( FavoriteRepo.References ) )
                {
                    property.ShouldSerialize = ( instance ) =>
                    {
                        FavoriteRepo favoriteRepo = (FavoriteRepo)instance;
                        return !favoriteRepo.IsFavoriteFolder && favoriteRepo.References.Count > 0;
                    };
                }
            }
            else if( property.DeclaringType == typeof( TreeNode<FavoriteRepo> ) )
            {
                if( property.PropertyName == nameof( TreeNode<FavoriteRepo>.Children ) )
                {
                    property.ShouldSerialize = ( instance ) =>
                    {
                        TreeNode<FavoriteRepo> favorite = (TreeNode<FavoriteRepo>)instance;
                        return favorite.Children.Count > 0;
                    };
                }
            }

            return property;
        }

        private bool ShouldNotSerializeIfFavoriteFolder( Object instance )
        {
            return !( (FavoriteRepo)instance ).IsFavoriteFolder;
        }
    }
}
