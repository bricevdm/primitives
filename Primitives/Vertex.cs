using System;
using UnityEngine;

namespace WizardsRepublic.Primitives
{
    public class Vertex : IEquatable<Vertex>
    {
        public Vector3 Position { get; }

        public Vertex(Vector3 position)
        {
            Position = position;
        }

        public override bool Equals(object obj)
        {
            if (obj is Vertex v)
            {
                return Position == v.Position;
            }

            return false;
        }

        public bool Equals(Vertex other)
        {
            return other != null && Position == other.Position;
        }

        public override int GetHashCode()
        {
            return Position.GetHashCode();
        }
    }
    
    public class Vertex<T> : Vertex
    {
        public T Item { get; }

        public Vertex(Vector3 position, T item) : base(position)
        {
            Item = item;
        }
    }
}