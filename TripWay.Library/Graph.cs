using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using Priority_Queue;

namespace TripWay.Library
{
    public class Graph
    {
        private IList<WeightedEdge> edges;
        private IList<Vertex> vertices;
        private string name;

        public Graph(string name)
        {
            this.name = name;
            this.edges = new List<WeightedEdge>();
            this.vertices = new List<Vertex>();
        }

        public IList<Vertex> Vertices => this.vertices;

        public Func<string,Vertex> FindVertex => vertexToFind => this.vertices.FirstOrDefault(v => v.Name == vertexToFind);

        public void AddEdge(WeightedEdge edge)
        {
            this.edges.Add(edge);
        }

        public void AddVertex(Vertex vertex)
        {
            this.vertices.Add(vertex);
        }

        public IList<WeightedEdge> MinimumSpanningTree(Vertex startVertex)
        {
            SimplePriorityQueue<WeightedEdge> pq2 = new SimplePriorityQueue<WeightedEdge>();
            IList<WeightedEdge> result = new List<WeightedEdge>();
            Dictionary<Vertex, bool> visited = new Dictionary<Vertex, bool>();

            Action<Vertex> visit = vertex =>
            {
                visited[vertex] = true;
                var fromEdges = edges.Where(edge => edge.From == vertex);

                foreach (var edge in fromEdges)
                {
                    if (!visited.ContainsKey(edge.To))
                        pq2.Enqueue(edge, edge.Weight);
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

        public Tuple<Dictionary<Vertex, WeightedEdge>, Dictionary<Vertex, int>> Dijkstra(Vertex startingVertex, int initialStartDistance)
        {
            var distances = new Dictionary<Vertex, int>();
            distances[startingVertex] = initialStartDistance;
            var priorityQueue =  new SimplePriorityQueue<DijkstraNode>();
            Dictionary<Vertex,WeightedEdge> result = new Dictionary<Vertex,WeightedEdge>();

            priorityQueue.Enqueue(new DijkstraNode(){Vertex = startingVertex, Distance= initialStartDistance},initialStartDistance);


            while(priorityQueue.Any())
            {
                var nextVertex = priorityQueue.Dequeue().Vertex;
                if(!distances.ContainsKey(nextVertex))
                    continue;
                
                var distanceNextVertex = distances[nextVertex];

                foreach (var edge in this.edges.Where(e => e.From == nextVertex))
                {
                    var distanceToVertex = distances.ContainsKey(edge.To) ? distances[edge.To] : 0;

                    if(distanceToVertex == 0 || distanceToVertex > edge.Weight + distanceNextVertex)
                    {
                        distances[edge.To] = edge.Weight + distanceNextVertex;
                        result.Add(edge.To,edge);
                        priorityQueue.Enqueue(new DijkstraNode(){Vertex=edge.To, Distance=edge.Weight+distanceNextVertex},edge.Weight+distanceNextVertex);
                    }
                }
            }

            return new Tuple<Dictionary<Vertex, WeightedEdge>, Dictionary<Vertex, int>>(result, distances);
        }

        internal class DijkstraNode
        {
            public Vertex Vertex { get; set; }
            public int Distance { get; set; }

            public override bool Equals(object obj)
            {
                var convertedObj = obj as DijkstraNode;
                if (convertedObj != null)
                    return this.Distance == convertedObj.Distance;

                return false;
            }

            public override int GetHashCode()
            {
                using (var md5 = MD5.Create())
                {
                    var hash = md5.ComputeHash(Encoding.UTF8.GetBytes($"{this.Vertex.Name}{this.Distance}"));
                    return BitConverter.ToInt32(hash, 0);
                }
            }

            public static bool operator <(DijkstraNode lhs, DijkstraNode rhs)
            {
                return lhs.Distance < rhs.Distance;
            }
            
            public static bool operator >(DijkstraNode lhs, DijkstraNode rhs)
            {
                return lhs.Distance > rhs.Distance;
            }
        }
    }
}