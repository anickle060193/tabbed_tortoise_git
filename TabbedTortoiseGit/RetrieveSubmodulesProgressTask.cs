using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TabbedTortoiseGit
{
    abstract class RetrieveSubmodulesProgressTask : ProgressTask
    {
        public String Repo { get; private set; }
        public bool ModifiedOnly { get; private set; }

        public RetrieveSubmodulesProgressTask( String repo, bool modifiedOnly )
        {
            this.Repo = repo;
            this.ModifiedOnly = modifiedOnly;
        }

        public override string Description
        {
            get
            {
                return "Retrieve Submodules";
            }
        }

        public override string InitialOutput
        {
            get
            {
                return null;
            }
        }

        public override void Cancel()
        {
        }

        public override async void RunTask()
        {
            Output( "Retrieving submodules" );
            List<String> submodules = await Git.GetSubmodules( this.Repo );
            Output( $"{submodules.Count} submodules found" );

            if( this.ModifiedOnly )
            {
                Output( "Retrieving modified submodules" );
                submodules = await Git.GetModifiedSubmodules( this.Repo, submodules );
                Output( $"{submodules.Count} modified submodules found" );
            }

            IEnumerable<ProcessProgressTask> tasks = submodules.Select( this.GetTaskForSubmodule );

            OnProgressCompleted( new ProgressCompletedEventArgs( tasks ) );
        }

        abstract protected ProcessProgressTask GetTaskForSubmodule( String submodule );
    }
}
