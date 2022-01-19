using System;

namespace WizardsRepublic.Primitives
{
    public class Edge : IEquatable<Edge>
    {
        private Vertex u;
        private Vertex v;

        public Vertex U
        {
            get => u;
            protected set => u = value;
        }

        public Vertex V
        {
            get => v;
            protected set => v = value;
        }

        protected Edge(Vertex u, Vertex v)
        {
            this.U = u;
            this.V = v;
        }

        public override bool Equals(object obj)
        {
            if (obj is Edge e)
            {
                return Compare(e, this);
            }

            return false;
        }

        public bool Equals(Edge e)
        {
            return Compare(this, e);
        }

        public override int GetHashCode()
        {
            return U.GetHashCode() ^ V.GetHashCode();
        }
        
        private static bool Compare(Edge a, Edge b)
        {
            return (b.U == a.U || b.U == a.V)
                   && (b.V == a.U || b.V == a.V);
        }
    }
}