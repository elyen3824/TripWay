using System.Collections.Generic;
using TripWay.Library;
using VisitPath.Model;
namespace VisitPath.Command
{
    public interface ICalculateSpanningTreeCommand
    {
        IEnumerable<WeightedEdge> CalculateSpanningTree(MinimumSpanningTreeData data);
    }
}