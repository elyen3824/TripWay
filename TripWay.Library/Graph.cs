using System;
using System.Collections.Generic;

namespace TripWay.Library
{
    public class Graph<T>
    {
        private IList<T> Edges;
        private IList<Vertex> Vertices;
        private string name;

        public Graph(string name)
        {
            this.name = name;
        }

        public void AddEdge(T edge)
        {
            this.Edges.Add(edge);
        }

        public void AddVertex(Vertex vertex)
        {
            this.Vertices.Add(vertex);
        }
    }
}