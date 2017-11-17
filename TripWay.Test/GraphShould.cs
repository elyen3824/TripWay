using TripWay.Library;
using Xunit;

namespace TripWay.Test
{
    public class GraphShould
    {
        private Graph graph;
        private Vertex effeilTowerVertex;
        private Vertex trocaderoVertex;
        private Vertex arcDeTriomphe;
        private Vertex montmartre;
        private WeightedEdge effeilTowerToTrocaderoEdge;
        private WeightedEdge effeilTowerToArcDeTriomphe;
        private WeightedEdge trocaderoToArcDeTriomphe;
        private WeightedEdge arcDeTriompheToMontmartre;

        public GraphShould()
        {
            graph = new Graph("Test Graph");
            InitVertices(graph);
            InitEdges(graph);
        }

        private void InitVertices(Graph graph)
        {
            effeilTowerVertex = new Vertex("Effeil Tower");
            trocaderoVertex = new Vertex("Trocadero");
            arcDeTriomphe = new Vertex("Arc de Triomphe");
            montmartre = new Vertex("Montmartre");

            graph.AddVertex(effeilTowerVertex);
            graph.AddVertex(trocaderoVertex);
            graph.AddVertex(arcDeTriomphe);
            graph.AddVertex(montmartre);
        }

        private void InitEdges(Graph graph)
        {
            effeilTowerToTrocaderoEdge = new WeightedEdge(effeilTowerVertex, trocaderoVertex, 2);
            effeilTowerToArcDeTriomphe = new WeightedEdge(effeilTowerVertex, arcDeTriomphe, 4);
            trocaderoToArcDeTriomphe = new WeightedEdge(trocaderoVertex, arcDeTriomphe, 2);
            arcDeTriompheToMontmartre = new WeightedEdge(arcDeTriomphe, montmartre, 8);

            graph.AddEdge(effeilTowerToTrocaderoEdge);
            graph.AddEdge(effeilTowerToArcDeTriomphe);
            graph.AddEdge(trocaderoToArcDeTriomphe);
            graph.AddEdge(arcDeTriompheToMontmartre);

        }

        [Fact]
        public void Find_The_Minimum_Spanning_Tree_Path_To_Go_Throught_All_Edges_Using_Less_Weighted_Edges()
        {
            var result = graph.MinimumSpanningTree(effeilTowerVertex);

            Assert.True(result.Count == 3);
            Assert.True(result[0] == effeilTowerToTrocaderoEdge);
            Assert.True(result[1] == trocaderoToArcDeTriomphe);
            Assert.True(result[2] == arcDeTriompheToMontmartre);
        }

        [Fact]
        public void Find_The_Shortest_Path_To_Go_Throught_All_Edges()
        {
            var result = graph.Dijkstra(effeilTowerVertex);

            Assert.True(result.Count == 3);
            Assert.True(result[0] == effeilTowerToTrocaderoEdge);
            Assert.True(result[1] == trocaderoToArcDeTriomphe);
            Assert.True(result[2] == arcDeTriompheToMontmartre);
        }
    }
}