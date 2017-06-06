using Common;
using log4net;
using Microsoft.Win32;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace TabbedTortoiseGit
{
    static class TTG
    {
        private static readonly ILog LOG = LogManager.GetLogger( typeof( TTG ) );

        private static readonly String RUN_ON_STARTUP_KEY_PATH = @"Software\Microsoft\Windows\CurrentVersion\Run";
        private static readonly String RUN_ON_STARTUP_KEY_NAME = "Tabbed TortoiseGit";

        public static bool RunOnStartup
        {
            get
            {
                try
                {
                    using( RegistryKey run = Registry.CurrentUser.OpenSubKey( RUN_ON_STARTUP_KEY_PATH, false ) )
                    {
                        return run.GetValue( RUN_ON_STARTUP_KEY_NAME ) != null;
                    }
                }
                catch( Exception e )
                {
                    LOG.Error( "An error occurred getting the current state of the 'Run on Startup' registry item.", e );
                }
                return false;
            }

            set
            {
                try
                {
                    using( RegistryKey run = Registry.CurrentUser.OpenSubKey( RUN_ON_STARTUP_KEY_PATH, true ) )
                    {
                        if( value )
                        {
                            String exe = new Uri( Assembly.GetExecutingAssembly().CodeBase ).LocalPath;
                            run.SetValue( RUN_ON_STARTUP_KEY_NAME, "\"{0}\" --startup".XFormat( exe ) );
                        }
                        else
                        {
                            if( run.GetValue( RUN_ON_STARTUP_KEY_NAME ) != null )
                            {
                                run.DeleteValue( RUN_ON_STARTUP_KEY_NAME );
                            }
                        }
                    }
                }
                catch( Exception e )
                {
                    LOG.Error( "An error occurred setting the current state of the 'Run on Startup' registry item.", e );
                }
            }
        }

        class TagRef
        {
            public String Ref { get; set; }
        }

        public static async Task<UpdateCheck> IsUpToDate()
        {
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create( "https://api.github.com/repos/anickle060193/tabbed_tortoise_git/git/refs/tags" );
                request.ContentType = "text/json";
                request.Method = "GET";
                request.Accept = "application/vnd.github.v3+json";
                AssemblyName a = Assembly.GetExecutingAssembly().GetName();
                Version currentVersion = a.Version;
                request.UserAgent = "{0} {1}".XFormat( a.Name, currentVersion );
                using( WebResponse response = await request.GetResponseAsync() )
                using( StreamReader reader = new StreamReader( response.GetResponseStream() ) )
                {
                    String responseText = reader.ReadToEnd();
                    List<TagRef> responseObject = JsonConvert.DeserializeObject<List<TagRef>>( responseText );
                    Version newestVersion = responseObject.Select( o => Version.Parse( o.Ref.Replace( "refs/tags/", "" ) ) ).Max();
                    
                    if( newestVersion > currentVersion )
                    {
                        String updateUrl = "https://github.com/anickle060193/tabbed_tortoise_git/raw/{0}/Setup/Output/Setup.msi".XFormat( newestVersion );
                        return new UpdateCheck( newestVersion, updateUrl );
                    }
                    else
                    {
                        return null;
                    }
                }
            }
            catch( Exception e )
            {
                LOG.Error( "An error occured while trying to check if application is up to date.", e );
            }

            return null;
        }
    }

    public class UpdateCheck
    {
        public Version NewerVersion { get; private set; }
        public String UpdateUrl { get; private set; }

        public UpdateCheck( Version newerVersion, String updateUrl )
        {
            NewerVersion = newerVersion;
            UpdateUrl = updateUrl;
        }
    }
}
