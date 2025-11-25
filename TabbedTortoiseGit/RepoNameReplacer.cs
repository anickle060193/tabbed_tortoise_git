using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TabbedTortoiseGit
{
    public record class RepoNameReplacer
    {
        private static readonly ILog LOG = LogManager.GetLogger( nameof( RepoNameReplacer ) );

        public required string Pattern { get; init; } = "";
        public required string Replacement { get; init; } = "";

        public string Replace( string repoName )
        {
            if( string.IsNullOrEmpty( this.Pattern ) )
            {
                return repoName;
            }

            try
            {
                return Regex.Replace( repoName, this.Pattern, this.Replacement );
            }
            catch( Exception ex )
            {
                LOG.Warn( $"Failed to run repo name replacer: \"{this.Pattern}\" => \"{this.Replacement}\"", ex );
            }

            return repoName;
        }
    }
}
