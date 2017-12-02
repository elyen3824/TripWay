using System.Collections.Generic;
using System.Runtime.Serialization;
using TripWay.Library;

namespace VisitPath.Model
{
    [DataContract]
    public class MinimumSpanningTreeData
    {
        [DataMember]
        public string GraphName { get; set; }
        [DataMember]
        public IEnumerable<Vertex> Vertices { get; set; }

        [DataMember]
        public IEnumerable<WeightedEdge> Edges { get; set; }
        
        [DataMember]
        public string Start { get; set; }
    }
}