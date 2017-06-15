﻿using Common;
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
        public TreeNode<T> Parent { get; private set; }

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

        public TreeNodeCollection<T> Children { get; private set; }

        public TreeNode( T value )
        {
            Children = new TreeNodeCollection<T>( this );

            Value = value;
        }

        [JsonConstructor]
        public TreeNode( T value, IEnumerable<TreeNode<T>> children ) : this( value )
        {
            this.Children.AddRange( children );
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

        public TreeNode<T> FindValue( T value )
        {
            if( this.Value.Equals( value ) )
            {
                return this;
            }
            else
            {
                foreach( TreeNode<T> child in Children )
                {
                    TreeNode<T> foundNode = child.FindValue( value );
                    if( foundNode != null )
                    {
                        return foundNode;
                    }
                }

                return null;
            }
        }

        public override string ToString()
        {
            return "{0} - Count: {1}".XFormat( Value, Children.Count );
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