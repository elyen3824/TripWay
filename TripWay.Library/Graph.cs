using System;
using System.Collections.Generic;
using System.Linq;
using Priority_Queue;

namespace TripWay.Library
{
    public class Graph
    {
        private IList<WeightedEdge> Edges;
        private IList<Vertex> Vertices;
        private string name;

        public Graph(string name)
        {
            this.name = name;
            this.Edges = new List<WeightedEdge>();
            this.Vertices = new List<Vertex>();
        }

        public void AddEdge(WeightedEdge edge)
        {
            this.Edges.Add(edge);
        }

        public void AddVertex(Vertex vertex)
        {
            this.Vertices.Add(vertex);
        }

        public IList<WeightedEdge> MinimumSpanningTree(Vertex startVertex)
        {
            SimplePriorityQueue<WeightedEdge> pq2 = new SimplePriorityQueue<WeightedEdge>();
            IList<WeightedEdge> result =  new List<WeightedEdge>();
            Dictionary<Vertex,bool> visited = new Dictionary<Vertex,bool>();

            Action<Vertex> visit = vertex =>
            {
                visited[vertex] = true;
                var edges = Edges.Where(edge => edge.From == vertex);

                foreach (var edge in edges)
                {
                    if (!visited.ContainsKey(edge.To))
                        pq2.Enqueue(edge,edge.Weight);
                }
            };

            visit(startVertex);
            
            while (pq2.Any())
            {
                WeightedEdge edgeInQueue = pq2.Dequeue();
                if (visited.ContainsKey(edgeInQueue.To))
                   continue;
                result.Add(edgeInQueue);
                visit(edgeInQueue.To);
            }

            return result;
        }
    }
}