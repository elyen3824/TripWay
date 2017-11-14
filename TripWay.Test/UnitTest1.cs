using TripWay.Library;
using Xunit;

namespace TripWay.Test
{
    public class UnitTest1
    {
        [Fact]
        public void Given_A_Graph_With_Vertices_And_Edges_I_Should_Find_The_Path_To_Go_Throught_All_Edges()
        {
            Graph<WeightedEdge> graph = new Graph<WeightedEdge>("Test Graph");
            graph.AddVertex(new Vertex("Effeil Tower"));
            graph.AddEdge(new WeightedEdge(0,0,0));            
        }
    }
}