
using TripWay.Library;

namespace VisitPath.Controllers
{
    internal class MSTGraphCommand:IGraphCommand
    {
        private Graph graph;
        private GraphController.GraphData data;

        public MSTGraphCommand(GraphController.GraphData data)
        {
            this.data = data;
            InitGraph();
        }

        private void InitGraph()
        {
            graph = new Graph("Visit");
            foreach(var vertex in data.Vertices)
            {
                graph.AddVertex(new Vertex(vertex));
            }
            foreach (var edge in data.Edges)
            {
                var vertexFrom = graph.FindVertex(edge.FromVertex);
                var vertexTo = graph.FindVertex(edge.ToVertex);

                graph.AddEdge(new WeightedEdge(vertexFrom, vertexTo, edge.Distance));
            }
        }

        public object Execute()
        {   var initialVertex = graph.FindVertex(data.InitialVertex);
            return graph.MinimumSpanningTree(initialVertex);
        }

    }
}