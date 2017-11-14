using TripWay.Library;
using Xunit;

namespace TripWay.Test
{
    public class UnitTest1
    {
        [Fact]
        public void Given_A_Graph_With_Vertices_And_Edges_I_Should_Find_The_Path_To_Go_Throught_All_Edges()
        {
            Graph graph = new Graph("Test Graph");
            
            var effeilTowerVertex = new Vertex("Effeil Tower");
            var trocaderoVertex =  new Vertex("Trocadero");
            var arcDeTriomphe = new Vertex("Arc de Triomphe");
            var montmartre = new Vertex("Montmartre");
            
            graph.AddVertex(effeilTowerVertex);
            graph.AddVertex(trocaderoVertex);
            graph.AddVertex(arcDeTriomphe);
            graph.AddVertex(montmartre);

            var effeilTowerToTrocaderoEdge = new WeightedEdge(effeilTowerVertex, trocaderoVertex, 2);
            var effeilTowerToArcDeTriomphe = new WeightedEdge(effeilTowerVertex, arcDeTriomphe, 4);
            var trocaderoToArcDeTriomphe = new WeightedEdge(trocaderoVertex, arcDeTriomphe, 2);
            var arcDeTriompheToMontmartre = new WeightedEdge(arcDeTriomphe, montmartre, 8);
            
            graph.AddEdge(effeilTowerToTrocaderoEdge);  
            graph.AddEdge(effeilTowerToArcDeTriomphe);            
            graph.AddEdge(trocaderoToArcDeTriomphe);            
            graph.AddEdge(arcDeTriompheToMontmartre);

            var result = graph.MinimumSpanningTree(effeilTowerVertex);
            Assert.True(result.Count > 0);

        }
    }
}