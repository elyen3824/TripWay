using System.Collections.Generic;
using System.Linq;
using TripWay.Library;
using VisitPath.Model;

namespace VisitPath.Command.Concrete
{
    public class CalculateSpanningTreeCommand : ICalculateSpanningTreeCommand
    {
        public IEnumerable<WeightedEdge> CalculateSpanningTree(MinimumSpanningTreeData data)
        {
            var graph = new Graph(data.GraphName);
            foreach (var vertex in data.Vertices)
            {
                graph.AddVertex(vertex);
            }
            foreach (var edge in data.Edges)
            {
                graph.AddEdge(edge);
            }

            return graph.MinimumSpanningTree(graph.FindVertex(data.Start));
        }
    }
}