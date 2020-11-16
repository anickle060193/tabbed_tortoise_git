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
        public bool TreatUninitializedSubmodulesAsModified { get; private set; }

        public RetrieveSubmodulesProgressTask( String repo, bool modifiedOnly, bool treatUninitializedSubmodulesAsModified )
        {
            this.Repo = repo;
            this.ModifiedOnly = modifiedOnly;
            this.TreatUninitializedSubmodulesAsModified = treatUninitializedSubmodulesAsModified;
        }

        public override string Description
        {
            get
            {
                return "Retrieve Submodules";
            }
        }

        public override String? InitialOutput
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
                submodules = await Git.GetModifiedSubmodules( this.Repo, submodules, this.TreatUninitializedSubmodulesAsModified );
                Output( $"{submodules.Count} modified submodules found" );
            }

            IEnumerable<ProcessProgressTask> tasks = submodules.Select( this.GetTaskForSubmodule );

            OnProgressCompleted( new ProgressCompletedEventArgs( tasks ) );
        }

        abstract protected ProcessProgressTask GetTaskForSubmodule( String submodule );
    }
}
