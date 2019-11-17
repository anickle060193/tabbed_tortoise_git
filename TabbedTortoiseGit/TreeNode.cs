#nullable enable

using Common;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace TabbedTortoiseGit
{
    public class TreeNode<T>
    {
        public T Value { get; private set; }

        [JsonIgnore]
        public TreeNode<T>? Parent { get; private set; }

        [JsonIgnore]
        public int Index
        {
            get
            {
                if( this.Parent != null )
                {
                    return this.Parent.Children.IndexOf( this );
                }
                else
                {
                    return -1;
                }
            }
        }

        [JsonIgnore]
        public int NestedCount
        {
            get
            {
                return this.Children.Count + this.Children.Sum( child => child.NestedCount );
            }
        }

        [JsonIgnore]
        public int NestedIndex
        {
            get
            {
                if( this.Parent == null )
                {
                    return 0;
                }
                else
                {
                    int index = this.Parent.NestedIndex + 1;
                    foreach( TreeNode<T> child in this.Parent.Children )
                    {
                        if( child == this )
                        {
                            break;
                        }
                        index += child.NestedCount + 1;
                    }

                    return index;
                }
            }
        }

        public TreeNodeCollection<T> Children { get; private set; }

        [JsonIgnore]
        public IEnumerable<TreeNode<T>> DepthFirst
        {
            get
            {
                yield return this;
                foreach( TreeNode<T> child in this.Children )
                {
                    foreach( TreeNode<T> childChild in child.DepthFirst )
                    {
                        yield return childChild;
                    }
                }
            }
        }

        [JsonIgnore]
        public IEnumerable<TreeNode<T>> BreadthFirst
        {
            get
            {
                Queue<TreeNode<T>> nodesToGo = new Queue<TreeNode<T>>();
                nodesToGo.Enqueue( this );
                while( nodesToGo.Count > 0 )
                {
                    TreeNode<T> current = nodesToGo.Dequeue();
                    yield return current;
                    foreach( TreeNode<T> child in current.Children )
                    {
                        nodesToGo.Enqueue( child );
                    }
                }
            }
        }

        [JsonIgnore]
        public TreeNode<T>? Previous
        {
            get
            {
                if( this.Index > 0 )
                {
                    return this.Parent?.Children[ this.Index - 1 ];
                }
                else
                {
                    return null;
                }
            }
        }

        [JsonIgnore]
        public TreeNode<T>? Next
        {
            get
            {
                if( this.Parent == null )
                {
                    return null;
                }
                else if( this.Index + 1 >= this.Parent.Children.Count )
                {
                    return null;
                }
                else
                {
                    return this.Parent.Children[ this.Index + 1 ];
                }
            }
        }

        public TreeNode( T value )
        {
            Children = new TreeNodeCollection<T>( this );

            Value = value;
        }

        [JsonConstructor]
        public TreeNode( T value, IEnumerable<TreeNode<T>> children ) : this( value )
        {
            if( children != null )
            {
                this.Children.AddRange( children );
            }
        }

        public void Add( TreeNode<T> node )
        {
            this.Children.Add( node );
        }

        public TreeNode<T> Add( T value )
        {
            return this.Children.Add( value );
        }

        public bool Remove( TreeNode<T> node )
        {
            return this.Children.Remove( node );
        }

        public bool NestedContains( TreeNode<T> node )
        {
            foreach( TreeNode<T> n in this.BreadthFirst )
            {
                if( n.Children.Contains( node ) )
                {
                    return true;
                }
            }
            return false;
        }

        public override string ToString()
        {
            return $"{Value} - Count: {Children.Count}";
        }

        public class TreeNodeCollection<S> : IList<TreeNode<S>>
        {
            private readonly List<TreeNode<S>> _children = new List<TreeNode<S>>();
            private readonly TreeNode<S> _owner;

            public TreeNodeCollection( TreeNode<S> owner )
            {
                _owner = owner;
            }

            public TreeNode<S> this[ int index ]
            {
                get
                {
                    if( index < 0 || index >= this.Count )
                    {
                        throw new ArgumentOutOfRangeException( nameof( index ) );
                    }

                    return _children[ index ];
                }

                set
                {
                    if( index < 0 || index >= this.Count )
                    {
                        throw new ArgumentOutOfRangeException( nameof( index ) );
                    }
                    if( value == null )
                    {
                        throw new ArgumentNullException( nameof( value ) );
                    }
                    if( this.Contains( value ) )
                    {
                        throw new ArgumentException( "Node already exists as child of this node.", nameof( value ) );
                    }
                    if( value.Parent != null )
                    {
                        throw new ArgumentException( "Node is already a child of another node.", nameof( value ) );
                    }

                    TreeNode<S> oldNode = _children[ index ];
                    oldNode.Parent = null;

                    TreeNode<S> newNode = value;
                    _children[ index ] = value;
                    value.Parent = _owner;
                }
            }

            public int Count
            {
                get
                {
                    return _children.Count;
                }
            }

            public bool IsReadOnly
            {
                get
                {
                    return false;
                }
            }

            public void Add( TreeNode<S> node )
            {
                this.Insert( this.Count, node );
            }

            public TreeNode<S> Add( S value )
            {
                TreeNode<S> node = new TreeNode<S>( value );
                this.Add( node );
                return node;
            }

            public void AddRange( IEnumerable<TreeNode<S>> nodes )
            {
                if( nodes == null )
                {
                    throw new ArgumentException( nameof( nodes ) );
                }

                foreach( TreeNode<S> node in nodes )
                {
                    this.Add( node );
                }
            }

            public void Clear()
            {
                while( this.Count > 0 )
                {
                    this.Remove( this[ 0 ] );
                }
            }

            public bool Contains( TreeNode<S> node )
            {
                if( node == null )
                {
                    throw new ArgumentNullException( nameof( node ) );
                }

                return _children.Contains( node );
            }

            public void CopyTo( TreeNode<S>[] array, int arrayIndex )
            {
                throw new InvalidOperationException();
            }

            public IEnumerator<TreeNode<S>> GetEnumerator()
            {
                return _children.GetEnumerator();
            }

            public int IndexOf( TreeNode<S> node )
            {
                if( node == null )
                {
                    throw new ArgumentNullException( nameof( node ) );
                }

                return _children.IndexOf( node );
            }

            public void Insert( int index, TreeNode<S> node )
            {
                if( index < 0 || index > this.Count )
                {
                    throw new ArgumentOutOfRangeException( nameof( index ) );
                }
                if( node == null )
                {
                    throw new ArgumentNullException( nameof( node ) );
                }
                if( this.Contains( node ) )
                {
                    throw new ArgumentException( "Node already exists as child of this node.", nameof( node ) );
                }
                if( node.Parent != null )
                {
                    throw new ArgumentException( "Node is already a child of another node.", nameof( node ) );
                }

                _children.Insert( index, node );
                node.Parent = _owner;
            }

            public bool Remove( TreeNode<S> node )
            {
                if( node == null )
                {
                    throw new ArgumentNullException( nameof( node ) );
                }

                int index = this.IndexOf( node );
                if( index != -1 )
                {
                    this.RemoveAt( index );
                    return true;
                }
                else
                {
                    return false;
                }
            }

            public void RemoveAt( int index )
            {
                if( index < 0 || index >= this.Count )
                {
                    throw new ArgumentOutOfRangeException( nameof( index ) );
                }

                TreeNode<S> node = this[ index ];
                node.Parent = null;
                _children.RemoveAt( index );
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return ( (IEnumerable)_children ).GetEnumerator();
            }
        }
    }
}
