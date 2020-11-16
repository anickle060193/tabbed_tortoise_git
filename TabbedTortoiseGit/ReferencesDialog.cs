using LibGit2Sharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TabbedTortoiseGit.Properties;

namespace TabbedTortoiseGit
{
    public partial class ReferencesDialog : Form
    {
        class DisplayReference : IFormattable, IComparable<DisplayReference>
        {
            public String Reference { get; private set; }
            public String ShortReference { get; private set; }

            public DisplayReference( String reference, String shortReference )
            {
                Reference = reference;
                ShortReference = shortReference;
            }

            public override String ToString()
            {
                return ShortReference;
            }

            public string ToString( String? format, IFormatProvider? formatProvider )
            {
                if( format == "long" )
                {
                    return Reference;
                }
                else
                {
                    return ShortReference;
                }
            }

            public int CompareTo( DisplayReference? other )
            {
                return String.Compare( this.Reference, other?.Reference );
            }
        }

        private readonly String _repo;

        private String? _currentBranch;

        public String[] SelectedReferences
        {
            get
            {
                return _selectedReferences.Select( r => r.Reference ).ToArray();
            }
        }

        private IList<DisplayReference> SelectedReferencesList
        {
            get
            {
                return _selectedReferences.ToList();
            }
        }

        private readonly SortedSet<DisplayReference> _selectedReferences = new SortedSet<DisplayReference>();

        public ReferencesDialog( String repo )
        {
            InitializeComponent();

            this.Icon = Resources.TortoiseIcon;

            _repo = repo;

            this.Text = _repo + " - Select References";

            ReferencesTreeView.AfterSelect += ReferencesTreeView_AfterSelect;

            ReferencesFilterText.TextChanged += ReferencesFilterText_TextChanged;

            ReferencesListBox.MouseDoubleClick += ReferencesListBox_MouseDoubleClick;

            AddSelectedReferencesButton.Click += AddSelectedReferencesButton_Click;

            SelectedReferencesListBox.KeyUp += SelectedReferencesListBox_KeyUp;

            RemoveSelectedReferencesButton.Click += RemoveSelectedReferencesButton_Click;

            AddCurrentBranchButton.Click += AddCurrentBranchButton_Click;

            Ok.Click += Ok_Click;

            InitializeReferences();
        }

        private void ReferencesTreeView_AfterSelect( object? sender, TreeViewEventArgs e )
        {
            UpdateDisplayedReferences();
        }

        private void ReferencesFilterText_TextChanged( object? sender, EventArgs e )
        {
            UpdateDisplayedReferences();
        }

        private void ReferencesListBox_MouseDoubleClick( object? sender, MouseEventArgs e )
        {
            int index = ReferencesListBox.IndexFromPoint( e.Location );
            if( index != ListBox.NoMatches )
            {
                DisplayReference reference = (DisplayReference)ReferencesListBox.Items[ index ];
                _selectedReferences.Add( reference );
                SelectedReferencesListBox.DataSource = SelectedReferencesList;
            }
        }

        private void AddSelectedReferencesButton_Click( object? sender, EventArgs e )
        {
            foreach( DisplayReference reference in ReferencesListBox.SelectedItems.Cast<DisplayReference>() )
            {
                _selectedReferences.Add( reference );
            }
            SelectedReferencesListBox.DataSource = SelectedReferencesList;
            ReferencesListBox.SelectedItems.Clear();
        }

        private void SelectedReferencesListBox_KeyUp( object? sender, KeyEventArgs e )
        {
            if( e.KeyCode == Keys.Delete
             || e.KeyCode == Keys.Back )
            {
                RemoveFromSelectedReferences();
                e.Handled = true;
            }
        }

        private void RemoveSelectedReferencesButton_Click( object? sender, EventArgs e )
        {
            RemoveFromSelectedReferences();
        }

        private void AddCurrentBranchButton_Click( object? sender, EventArgs e )
        {
            if( _currentBranch != null )
            {
                _selectedReferences.Add( new DisplayReference( _currentBranch, _currentBranch ) );
                SelectedReferencesListBox.DataSource = SelectedReferencesList;
            }
        }

        private void Ok_Click( object? sender, EventArgs e )
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void InitializeReferences()
        {
            using( Repository repository = new Repository( Git.GetBaseRepoDirectory( _repo ) ) )
            {
                Branch currentBranch = repository.Head;
                if( currentBranch != null )
                {
                    _currentBranch = repository.Head.CanonicalName;
                    if( _currentBranch == "(no branch)" )
                    {
                        _currentBranch = null;
                    }
                }
                else
                {
                    _currentBranch = null;
                }

                AddCurrentBranchButton.Enabled = ( _currentBranch != null );

                foreach( Reference r in repository.Refs )
                {
                    String[] splitRef = r.CanonicalName.Split( '/' );
                    AddReference( r.CanonicalName, splitRef, 0, ReferencesTreeView.Nodes );
                }
            }

            if( ReferencesTreeView.Nodes.Count > 0 )
            {
                TreeNode firstNode = ReferencesTreeView.Nodes[ 0 ];
                firstNode.Expand();
                ReferencesTreeView.SelectedNode = firstNode;
            }
        }

        private void AddReference( String reference, String[] splitRef, int index, TreeNodeCollection parentNodes )
        {
            String splitRefPart = splitRef[ index ];
            TreeNode? node = parentNodes.Find( splitRefPart, false ).FirstOrDefault();
            if( node == null )
            {
                node = parentNodes.Add( splitRefPart, splitRefPart );
                node.Tag = new List<DisplayReference>();
            }

            List<DisplayReference> refs = (List<DisplayReference>)node.Tag;
            DisplayReference displayRef = new DisplayReference( reference, String.Join( "/", splitRef, index + 1, splitRef.Length - index - 1 ) );
            refs.Add( displayRef );

            if( index + 1 < splitRef.Length - 1 )
            {
                AddReference( reference, splitRef, index + 1, node.Nodes );
            }
        }

        private void RemoveFromSelectedReferences()
        {
            foreach( DisplayReference reference in SelectedReferencesListBox.SelectedItems.Cast<DisplayReference>() )
            {
                _selectedReferences.Remove( reference );
            }
            SelectedReferencesListBox.DataSource = SelectedReferencesList;
        }

        private void UpdateDisplayedReferences()
        {
            ReferencesListBox.Items.Clear();

            if( ReferencesTreeView.SelectedNode != null )
            {
                IEnumerable<DisplayReference> references = (List<DisplayReference>)ReferencesTreeView.SelectedNode.Tag;

                String filter = ReferencesFilterText.Text.Trim().ToLower();
                if( !String.IsNullOrEmpty( filter ) )
                {
                    references = references.Where( r => r.ShortReference.ToLower().Contains( filter ) );
                }

                ReferencesListBox.Items.AddRange( references.ToArray() );
            }
        }
    }
}
